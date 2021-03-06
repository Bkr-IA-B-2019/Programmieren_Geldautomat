﻿using Geldautomat.database;
using Geldautomat.database.exceptions;
using Geldautomat.database.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Geldautomat
{
    /// <summary>
    /// Singleton class to store data
    /// </summary>
    class Usermanager
    {
        /// <summary>
        /// Random for generation
        /// </summary>
        private readonly Random random = new Random();

        /// <summary>
        /// Holds the instance to the class
        /// </summary>
        private static Usermanager instance;

        /// <summary>
        /// The account that the user is logged in as
        /// </summary>
        public Account LoggedInAs { get; private set; }

        /// <summary>
        /// Holds the database connection util
        /// </summary>
        public IDatabase Database = Config.USED_DATABASE;

        private Usermanager(){}

        /// <summary>
        /// Returns a singleton instance of the class
        /// </summary>
        public static Usermanager Instance
        {
            get
            {
                if (instance == null)
                    instance = new Usermanager();
                return instance;
            }
        }

        /// <summary>
        /// Generates the sha256 hash for the given text
        /// </summary>
        /// <param name="raw">The raw text</param>
        /// <returns>The compouted sha256-string</returns>
        private string GenerateSHA256Hash(string raw)
        {
            // Creates the generator
            using(SHA256 gen = SHA256.Create())
            {
                // Generatest the hash as a byte[]
                byte[] byteHash = gen.ComputeHash(Encoding.UTF8.GetBytes(raw));

                // Will hold the full hash
                StringBuilder sb = new StringBuilder();

                // Converts the byte-hash into a string using hex
                for (int i = 0; i < byteHash.Length; i++)
                    sb.Append(byteHash[i].ToString("x2"));

                return sb.ToString();
            }
        }

        /// <summary>
        /// Generates a random string for the given length and the given charset
        /// </summary>
        /// <param name="length">How long the generated string should be</param>
        /// <param name="charset">What charset to use for the string</param>
        /// <returns>The random string</returns>
        private string GeneratesRandomString(int length,string charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ß_.,+'*\"\\!§$%&/()=?}][{{³²€@")
        {
            // Holds the final string
            StringBuilder sb = new StringBuilder();

            // Generates a string of the given lenght
            for (int i = 0; i < length; i++)
                sb.Append(charset[this.random.Next(0, charset.Length)]);

            return sb.ToString();
        }

        /// <summary>
        /// Tries to login the user using the given id and pin
        /// </summary>
        /// <returns>Null if the login was successfull; otherwise the error message. This can directly be displayed to the user.</returns>
        public string Login(int id,int pin)
        {
            try
            {
                // Gets the account
                Account acc = this.Database.GetAccountByID(id);

                // Checks if the account got found
                if (acc == null)
                    return "Falsche ID oder PIN.";

                // Generates the presumed pass hash
                string presumedPinHash = GenerateSHA256Hash(pin.ToString() + acc.PinSalt);

                // Checks if the pass-hashes match
                if (presumedPinHash.Equals(acc.PinHash))
                {
                    // Saves as the logged in Account
                    this.LoggedInAs = acc;

                    // Returnes the successfull login
                    return null;
                }

                return "Falsche ID oder PIN.";
            }
            catch(DatabaseException e)
            {
                return e.Message;
            }
        }
    
        /// <summary>
        /// Tries to register the user with the given credentials.
        /// Expects the credentials to be valid (eg. not empty names)
        /// </summary>
        /// <param name="firstname">The firstname to register for the user</param>
        /// <param name="lastname">The lastname to register for the user</param>
        /// <param name="pin">The pin that the user wants to use</param>
        /// <param name="optError">Gets set if an error occures and the method returns null. Sets the error messagethat can be displayed to the user</param>
        /// <returns>If the registration was successful the account; otherwise null</returns>
        public Account Register(string firstname,string lastname,int pin,ref string optError)
        {
            // Generates a random salt
            string salt = this.GeneratesRandomString(20);

            // Hashes the users pin
            string hashedPin = this.GenerateSHA256Hash(pin.ToString() + salt);
            try
            {
                // Registers the account
                return this.Database.CreateNewAccount(new Account(firstname, lastname, 0, hashedPin, salt));
            }
            catch (DatabaseException e)
            {
                optError = e.Message;
                return null;
            }
        }

        /// <summary>
        /// Registers a new account. If that is successfull, automatically loggsin the new user.
        /// </summary>
        /// <param name="firstname">The firstname to register for the user</param>
        /// <param name="lastname">The lastname to register for the user</param>
        /// <param name="pin">The pin that the user wants to use</param>
        /// <returns>If the registration was successfull null; otherwise the error message that can be displayed to the user.</returns>
        public string RegisterAndLogIn(string firstname,string lastname,int pin)
        {
            // Will hold the error message, if any error occures
            string optError = null;

            // Tries to register the account
            Account acc = this.Register(firstname, lastname, pin, ref optError);

            // Checks if something went wrong
            if (acc == null)
                return optError;

            // Sets the account as logged in
            this.LoggedInAs = acc;

            return null;
        }

        /// <summary>
        /// Creates a transaction with the given price. Creates a new transaction and updates the users account.
        /// </summary>
        /// <param name="price">The price that the product has</param>
        /// <param name="subtract">If the transaction shuld remove or add money to the account</param>
        /// <returns>If the transaction was successfull null; Otherwise the error message.</returns>
        public string CreateTransaction(decimal price,bool subtract)
        {
            // Creates the transaction
            Transaction pseudoTransaction = new Transaction(price, subtract, this.LoggedInAs);

            try
            {
                // Tries to insert the transaction
                this.Database.CreateNewTransaction(pseudoTransaction);

                // Updates the users account
                this.LoggedInAs.Money += price * (subtract ? -1 : 1);

                // Inserts the account into the database
                this.Database.UpdateAccount(this.LoggedInAs);

                return null;
            }catch(DatabaseException e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Generates a random product from the preset config products
        /// </summary>
        /// <returns>The randomly generated product</returns>
        public string GetRandomProduct()
        {
            return Config.BUY_PRODUCTS[this.random.Next(Config.BUY_PRODUCTS.Length)];
        }

        /// <summary>
        /// Generates a random price for a product
        /// </summary>
        /// <returns>The generated price</returns>
        public float GetRandomPrice()
        {
            // Generates the base price
            float price = this.random.Next(1,21);

            // Some proct structures that need to be present at every f*cking product for some reason
            float[] centPriceStructure = { .99f,.95f,0,.5f };

            // Adds a random cent-price structure
            price += centPriceStructure[this.random.Next(centPriceStructure.Length)];

            return price;
        }

        /// <summary>
        /// Logs the program out of the currently logged in account
        /// </summary>
        public void Logout()
        {
            this.LoggedInAs = null;
        }
    }
}
