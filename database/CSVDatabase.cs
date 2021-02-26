using Geldautomat.database.exceptions;
using Geldautomat.database.objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Geldautomat.database
{
    class CSVDatabase : IDatabase
    {
        #region Static-Settings

        /// <summary>
        /// The seperator the seperate datatypes
        /// </summary>
        private const char SEPERATOR = ',';


        /// <summary>
        /// Indicator for an account on the database
        /// </summary>
        private const char INDICATOR_ACCOUNT = 'A';

        /// <summary>
        /// Indicator for an transaction on the database
        /// </summary>
        private const char INDICATOR_TRANSACTION = 'T';

        #endregion

        #region Delegated methodes

        /// <summary>
        /// Tries to parse a line into the required object.
        /// </summary>
        /// <param name="line">The line that holds the object (Encoded by the objects definition)</param>
        /// <returns>The object if the parsing was successfull; otherwise null</returns>
        public delegate T LineParser<T>(string line);

        /// <summary>
        /// Encoded an object that can be parsed later on by a corresponding LineParser
        /// </summary>
        /// <param name="rawObject">The object that should be encoded</param>
        /// <returns>A string that holds the encoded object</returns>
        public delegate string ObjectEncoder<T>(T rawObject);

        #endregion


        /// <summary>
        /// The path to the database file
        /// </summary>
        public string FilePath { get; private set; }

        public CSVDatabase()
        {
            FilePath = Config.CSV_FILE_NAME;
        }

        #region Parsefunctions

        /// <summary>
        /// Parses an account from a given string that could be read from a file
        /// </summary>
        /// <param name="line">The line containing the data</param>
        /// <returns>The parsed account if successfull; otherwise null</returns>
        private Account AccountParser(string line)
        {
            // Splits the line into the single parts
            string[] parts = line.Split(SEPERATOR);

            // Checks if that length is not correct
            if (parts.Length != 7)
                return null;

            // Tries to parse the id
            if (!int.TryParse(parts[0], out int id))
                return null;

            // Gets further values
            string pinSalt = parts[1].AsUTF8FromBase64();
            string firstname = parts[4].AsUTF8FromBase64();
            string lastname = parts[5].AsUTF8FromBase64();

            // Checks if an error occured while loading the data
            if (pinSalt == null || firstname == null || lastname == null)
                return null;

            // Gets the money
            if (!decimal.TryParse(parts[3], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal money))
                return null;

            // Tries to load the creation time
            if (!DateTime.TryParse(parts[6], out DateTime createTime))
                return null;

            // Returns the loaded account
            return new Account(id, createTime)
            {
                Firstname = firstname,
                Lastname = lastname,
                Money = money,
                PinHash = parts[2],
                PinSalt = pinSalt
            };
        }


        /// <summary>
        /// Converts an account to a line that can be loaded again later
        /// </summary>
        /// <param name="acc">The account</param>
        /// <returns>A line that can be loaded back to an account</returns>
        private string AccountEncoder(Account acc)
        {
            return $"{acc.Id},{acc.PinSalt.AsBase64()},{acc.PinHash},{acc.Money.ToString(CultureInfo.InvariantCulture)},{acc.Firstname.AsBase64()},{acc.Lastname.AsBase64()},{acc.CreateDateTime.ToString()}";
        }


        /// <summary>
        /// Parses an transaction from the given string that could be read from a file (As a line)
        /// </summary>
        /// <param name="line">The line with the encoded data</param>
        /// <returns>The parsed transaction if successfull; otherwise null</returns>
        private Transaction TransactionParser(string line)
        {
            // Splits the line into the single parts
            string[] parts = line.Split(SEPERATOR);

            // Checks if that length is not correct
            if (parts.Length != 5)
                return null;

            // Tries to parse the id
            if (!int.TryParse(parts[0], out int id))
                return null;

            // Tries to parse the money
            if (!decimal.TryParse(parts[1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal money))
                return null;

            // Tries to parse if the transaction was an addition or subtraction
            if (!bool.TryParse(parts[2], out bool subtract))
                return null;

            // Tries to parse the account id
            if (!int.TryParse(parts[3], out int accountId))
                return null;

            // Tries to load the transaction-time
            if (!DateTime.TryParse(parts[4], out DateTime time))
                return null;

            // Returns the loaded transaction
            return new Transaction(id, money, subtract, accountId, time);
        }

        /// <summary>
        /// Converts an transaction to a line that can be loaded again later
        /// </summary>
        /// <param name="trans">The transaction</param>
        /// <returns>A line that can be loaded back to an transaction</returns>
        private string TransactionEncoder(Transaction trans)
        {
            return $"{trans.Id},{trans.TranslatedMoney.ToString(CultureInfo.InvariantCulture)},{trans.Subtracted},{trans.AccountId},{trans.DateTime}";
        }

        #endregion

        #region Database-access functions

        /// <summary>
        /// Gets the highest id that is currently beeing used an returns the next
        /// </summary>
        /// <param name="doParse">LineParser for the object</param>
        /// <param name="getId">Function to get the id (Unique) of an object</param>
        /// <param name="indicator">The indicator to show that a line on the database actually is from the object's type</param>
        /// <exception cref="DatabaseException">Forwarded from CVDatabase.LoadAllOf</exception>
        /// <returns>The next free account id</returns>
        private int GetNextIDFor<T>(LineParser<T> doParse, Func<T,int> getId, char indicator)
        {
            // Loads all accounts
            T[] accs = this.GetAllMatching(o=>true,doParse,indicator);

            // Checks if no accounts are found
            if (accs == null || accs.Length == 0)
                return 0;

            // Gets the highest id from the objects on the database
            int highestId = accs.Select(getId).Aggregate((a, b) => a > b ? a : b);

            // Returns the next highest id
            return highestId + 1;
        }

        /// <summary>
        /// Inserts the given pseudoObject into the database and returns the newly created one (With the real id and so on)
        /// </summary>
        /// <param name="pseudoValue">The pseudoObject that should be inserted</param>
        /// <param name="doConvert">Function to convert a pseudoObject into a real one with the id given</param>
        /// <param name="doEncode">Encoder to generated the line for the database</param>
        /// <param name="indicator">The indicator of that object</param>
        /// <param name="doParse">LineParser for the object</param>
        /// <param name="getId">Function to get the id (Unique) of an object</param>
        /// <exception cref="DatabaseException">If anything went wrong with the insert</exception>
        /// <returns>The real object (Made from the pseudo and id)</returns>
        private T InsertNewIntoDatabase<T>(T pseudoValue,Func<int,T,T> doConvert,Func<T,int> getId,ObjectEncoder<T> doEncode,LineParser<T> doParse,char indicator)
        {
            // Gets the next id for the object
            int id = this.GetNextIDFor(doParse, getId, indicator);

            // Converts the pseudoObject into a real one
            T realObject = doConvert(id,pseudoValue);

            try
            {
                // Inserts the new object into the database
                using (StreamWriter sr = new StreamWriter(this.FilePath, true, Encoding.UTF8))
                    sr.WriteLine(indicator + doEncode(realObject));

                // Returns the newly inserted object
                return realObject;
            }
            catch
            {
                throw new DatabaseException("Fehler beim sichern des Wertes in der Datanbank ("+indicator+").");
            }
        }

        /// <summary>
        /// Searches in the database for an object of the given indicator and retuns the first object
        /// that matches the given test condition
        /// </summary>
        /// <param name="doTest">The testing condition</param>
        /// <param name="doParse">Lineparser for the object</param>
        /// <param name="indicator">Line indicator for the object</param>
        /// <exception cref="DatabaseException">If anything went wrong with the loading of the database</exception>
        /// <returns>The first loaded object where the condition is true; if not found, the default value</returns>
        private T GetFirstMatching<T>(Func<T,bool> doTest,LineParser<T> doParse,char indicator)
        {
            try
            {
                // Opens the reader
                using (StreamReader sr = new StreamReader(this.FilePath))
                {
                    // Reads all lines
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Checks if the line not an account
                        if (line.Length <= 0 || line[0] != indicator)
                            continue;

                        // Tries to load the line
                        T loadedObject = doParse(line.Substring(1, line.Length - 1));

                        // Checks if the loading failed
                        if (loadedObject == null)
                            throw new DatabaseException("Datenbankdatei ist invalid formatiert.");

                        // Checks if the value matches
                        if (doTest(loadedObject))
                            return loadedObject;
                    }

                    // Returns 
                    return default;
                }
            }
            catch
            {
                throw new DatabaseException("Fehler beim laden der Datenbank.");
            }
        }

        /// <summary>
        /// Searches in the database for all objects that match the given condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doTest">The testing condition</param>
        /// <param name="doParse">Lineparser for the object</param>
        /// <param name="indicator">Line indicator for the object</param>
        /// <exception cref="DatabaseException">If anything went wrong with the loading of the databse</exception>
        /// <returns>An array with all objects that match the given condition</returns>
        private T[] GetAllMatching<T>(Func<T,bool> doTest,LineParser<T> doParse,char indicator)
        {
            try
            {
                // Opens the reader
                using (StreamReader sr = new StreamReader(this.FilePath))
                {
                    // Will hold all loaded values
                    List<T> loaded = new List<T>();

                    // Reads all lines
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Checks if the line not an account
                        if (line.Length <= 0 || line[0] != indicator)
                            continue;

                        // Tries to load the line
                        T loadedObject = doParse(line.Substring(1, line.Length - 1));

                        // Checks if the loading failed
                        if (loadedObject == null)
                            throw new DatabaseException("Datenbankdatei ist invalid formatiert.");

                        // Checks if the object matches the condition
                        if(doTest(loadedObject))
                            // Appends the all loaded
                            loaded.Add(loadedObject);
                    }

                    // Returns all loaded accounts
                    return loaded.ToArray();
                }
            }
            catch
            {
                throw new DatabaseException("Fehler beim laden der Datei.");
            }
        }

        /// <summary>
        /// Updates the given object on the database
        /// </summary>
        /// <param name="value">The new value of the object</param>
        /// <param name="doTest">Method to test if two object are equal (Eg. have the same id). Used to check which value on the database shuld be overriden</param>
        /// <param name="doParse">Lineparser for the object</param>
        /// <param name="doEncode">Encoder for the object</param>
        /// <param name="indicator">The indicator for the object</param>
        /// <exception cref="DatabaseException">If anything went wrong with the database</exception>
        private void UpdateObject<T>(T value,Func<T,T,bool> doTest,LineParser<T> doParse,ObjectEncoder<T> doEncode,char indicator)
        {
            try
            {
                // Will hold all lines
                List<string> lines = new List<string>();

                // Loads all lines
                string ln;
                using (StreamReader sr = new StreamReader(this.FilePath, Encoding.UTF8))
                    while ((ln = sr.ReadLine()) != null)
                    {
                        // Appends the line
                        lines.Add(ln);

                        // Checks if the line isn't of the searched type
                        if (ln.Length <= 0 || ln[0] != indicator)
                            continue;

                        // Loads the object
                        T obj = doParse(ln.Substring(1, ln.Length - 1));

                        // Checks if the object could not be parsed
                        if (obj == null)
                            throw new DatabaseException("Datenbank-Datei is invalid.");

                        // Checks if the objects do not match
                        if (!doTest(obj,value))
                            continue;

                        // Removes the line and appends the new object
                        lines.RemoveAt(lines.Count - 1);
                        lines.Add(INDICATOR_ACCOUNT + doEncode(value));
                    }

                // Saves all read lines back to the database
                using (StreamWriter sw = new StreamWriter(this.FilePath, false, Encoding.UTF8))
                    foreach (string line in lines)
                        sw.WriteLine(line);
            }
            catch
            {
                throw new DatabaseException("Fehler beim laden der Datenbank");
            }
        }

        #endregion

        /// <summary>
        /// Ensures that the required database file exists
        /// </summary>
        private void EnsureFileExistence()
        {
            // Checks if the file does not exist
            if (!File.Exists(this.FilePath))
                // Creates the file
                File.Create(this.FilePath).Close();
        }

        #region IDatabase inhert

        public void Close()
        {
            // Not needed
        }

        public Account CreateNewAccount(Account pseudoAccount)
        {
            this.EnsureFileExistence();

            // Inserts the new account into the database.
            // DB-Exception will be passed forward
            return this.InsertNewIntoDatabase(
                pseudoAccount,
                (id,pseud)=>new Account(id,pseud),
                i=>i.Id,
                this.AccountEncoder,
                this.AccountParser,
                INDICATOR_ACCOUNT
            );           
        }

        public Transaction CreateNewTransaction(Transaction pseudoTransaction)
        {
            // Inserts the new transaction into the database.
            // DB-Exception will be passed forward
            return this.InsertNewIntoDatabase(
                pseudoTransaction,
                (id, pseud) => new Transaction(id, pseud),
                i=>i.Id,
                this.TransactionEncoder,
                this.TransactionParser,
                INDICATOR_TRANSACTION
            );
        }

        public Account GetAccountByID(int id)
        {
            this.EnsureFileExistence();

            return this.GetFirstMatching(
                (o)=>o.Id==id,
                this.AccountParser,
                INDICATOR_ACCOUNT
            );
        }

        public Transaction[] GetAccountTransactions(Account account)
        {
            this.EnsureFileExistence();

            return this.GetAllMatching(
                i => i.AccountId == account.Id,
                this.TransactionParser,
                INDICATOR_TRANSACTION
            );
        }

        public void UpdateAccount(Account account)
        {
            this.EnsureFileExistence();

            this.UpdateObject(
                account,
                (a, b) => a.Id == b.Id,
                this.AccountParser,
                this.AccountEncoder,
                INDICATOR_ACCOUNT
            );
        }

        #endregion
    }
}
