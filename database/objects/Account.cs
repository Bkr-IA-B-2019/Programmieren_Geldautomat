using System;

namespace Geldautomat.database.objects
{
    public class Account
    {
        /// <summary>
        /// The unique id for the account (Used for the database)
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The date and time of the account creation
        /// </summary>
        public DateTime CreateDateTime { get; private set; }
        
        /// <summary>
        /// First and lastname of the account holder
        /// </summary>
        public string Firstname;
        public string Lastname;

        /// <summary>
        /// The amount of money that the account holder currently possesses
        /// </summary>
        public decimal Money;

        /// <summary>
        /// The pin (Password) of the account holder
        /// </summary>
        public string PinHash;

        /// <summary>
        /// Used when a new pseudo account is created.
        /// This account must first be pushed to the database to get an id assigned
        /// </summary>
        public Account(string firstname, string lastname, decimal money, string pinHash)
        {
            Firstname = firstname;
            Lastname = lastname;
            Money = money;
            PinHash = pinHash;
            this.CreateDateTime = DateTime.Now;
        }

        /// <summary>
        /// Used when the database grabs an account
        /// </summary>
        public Account(int id, DateTime createDateTime)
        {
            this.Id = id;
            this.CreateDateTime = createDateTime;
        }

        /// <summary>
        /// Used to convert an pseudoaccount into a real account
        /// </summary>
        public Account(int id,Account pseudoAccount)
        {
            this.Id = id;
            this.CreateDateTime = pseudoAccount.CreateDateTime;
            this.Firstname = pseudoAccount.Firstname;
            this.Lastname = pseudoAccount.Lastname;
            this.Money = pseudoAccount.Money;
            this.PinHash = pseudoAccount.PinHash;
        }
    }
}
