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
        private Account ParseAccountFromLine(string line)
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
        private string GetLineFromAccount(Account acc)
        {
            return $"{acc.Id},{acc.PinSalt.AsBase64()},{acc.PinHash},{acc.Money.ToString(CultureInfo.InvariantCulture)},{acc.Firstname.AsBase64()},{acc.Lastname.AsBase64()},{acc.CreateDateTime.ToString()}";
        }


        /// <summary>
        /// Parses an transaction from the given string that could be read from a file (As a line)
        /// </summary>
        /// <param name="line">The line with the encoded data</param>
        /// <returns>The parsed transaction if successfull; otherwise null</returns>
        private Transaction ParseTransactionFromLine(string line)
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
        private string GetLineFromTransaction(Transaction trans)
        {
            return $"{trans.Id},{trans.TranslatedMoney.ToString(CultureInfo.InvariantCulture)},{trans.Subtracted},{trans.AccountId},{trans.DateTime}";
        }

        #endregion

        #region Database-helper functions

        /// <summary>
        /// Tries to load all saved values from the db-file.
        /// Takes a function to parse a line to an value
        /// and the indicator that indicated that the given line in the database file is that datatype
        /// In case null is returned, the file is corrupted and should be replaced with an working one.
        /// </summary>
        /// <param name="indicator">The char that indicates that the given line from the database is actually one of the requested type.</param>
        /// <param name="doParse">Lineparser for the object</param>
        /// <returns>An array with all loaded values from the file; if the loading was unsuccessfull null</returns>
        private T[] LoadAllOf<T>(LineParser<T> doParse,char indicator)
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
                    while((line = sr.ReadLine()) != null){
                        // Checks if the line not an account
                        if (line.Length <= 0 || line[0] != indicator)
                            continue;

                        // Tries to load the line
                        T loadedObject = doParse(line.Substring(1, line.Length - 1));

                        // Checks if the loading failed
                        if (loadedObject == null)
                            return null;

                        // Appends the all loaded
                        loaded.Add(loadedObject);
                    }

                    // Returns all loaded accounts
                    return loaded.ToArray();
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the highest id that is currently beeing used an returns the next
        /// </summary>
        /// <param name="doParse">LineParser for the object</param>
        /// <param name="getId">Function to get the id (Unique) of an object</param>
        /// <param name="indicator">The indicator to show that a line on the database actually is from the object's type</param>
        /// <returns>The next free account id</returns>
        private int GetNextIDFor<T>(LineParser<T> doParse, Func<T,int> getId, char indicator)
        {
            // Loads all accounts
            T[] accs = this.LoadAllOf(doParse,indicator);

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
        /// Ensures that the required database file exists
        /// </summary>
        private void EnsureFileExistence()
        {
            // Checks if the file does not exist
            if (!File.Exists(this.FilePath))
                // Creates the file
                File.Create(this.FilePath).Close();
        }

        #endregion

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
                this.GetLineFromAccount,
                this.ParseAccountFromLine,
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
                this.GetLineFromTransaction,
                this.ParseTransactionFromLine,
                INDICATOR_TRANSACTION
            );
        }

        public Account GetAccountByID(int id)
        {
            this.EnsureFileExistence();

            try
            {
                string line;

                // Reads in all accounts
                using (StreamReader sr = new StreamReader(this.FilePath, Encoding.UTF8))
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Checks if the line is not an account line
                        if (line.Length <= 0 || line[0] != INDICATOR_ACCOUNT)
                            continue;

                        // Tries to get an account
                        Account acc = this.ParseAccountFromLine(line.Substring(1, line.Length-1));

                        // Checks if the account could not be parsed
                        if (acc == null)
                            throw new DatabaseException("Datenbank-Datei is invalid.");

                        // Checks if the id's match
                        if (id == acc.Id)
                            return acc;
                    }

                return null;
            }
            catch
            {
                throw new DatabaseException("Fehler beim lesen der Datenbank.");
            }
        }

        public Transaction[] GetAccountTransactions(Account account)
        {
            this.EnsureFileExistence();

            try
            {
                // List with all transactions (From the given account)
                List<Transaction> loadedTransactions = new List<Transaction>();

                string line;

                // Reads in all lines
                using (StreamReader sr = new StreamReader(this.FilePath, Encoding.UTF8))
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Checks if the line is not an transaction line
                        if (line.Length <= 0 || line[0] != INDICATOR_TRANSACTION)
                            continue;

                        // Tries to get the transaction
                        Transaction trans = this.ParseTransactionFromLine(line.Substring(1, line.Length - 1));

                        // Checks if the transaction could not be parsed
                        if (trans == null)
                            throw new DatabaseException("Datenbank-Datei is invalid.");

                        // Checks if the id's match
                        if (trans.AccountId == account.Id)
                            // Appends the transaction
                            loadedTransactions.Add(trans);
                    }

                return loadedTransactions.ToArray();
            }
            catch
            {
                throw new DatabaseException("Fehler beim lesen der Datenbank.");
            }
        }

        public void UpdateAccount(Account account)
        {
            this.EnsureFileExistence();

            try
            {
                // Will hold all lines
                List<string> lines = new List<string>();

                // Loads all lines
                string ln;
                using(StreamReader sr = new StreamReader(this.FilePath, Encoding.UTF8))
                    while((ln=sr.ReadLine()) != null)
                    {
                        // Appends the line
                        lines.Add(ln);

                        // Checks if the line isn't an account
                        if(ln.Length <= 0 || ln[0] != INDICATOR_ACCOUNT)
                            continue;

                        // Loads the account
                        Account acc = this.ParseAccountFromLine(ln.Substring(1, ln.Length - 1));

                        // Checks if the account could not be parsed
                        if (acc == null)
                            throw new DatabaseException("Datenbank-Datei is invalid.");

                        // Checks if the ids do not match
                        if (account.Id != acc.Id)
                            continue;

                        // Removes the line and appends the new account
                        lines.RemoveAt(lines.Count-1);
                        lines.Add("A"+this.GetLineFromAccount(account));
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
    }
}
