using Geldautomat.database.exceptions;
using Geldautomat.database.objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldautomat.database
{
    class CSVDatabase : IDatabase
    {
        /// <summary>
        /// The seperator the seperate datatypes
        /// </summary>
        private const char SEPERATOR = ',';

        /// <summary>
        /// The path to the database file
        /// </summary>
        public string FilePath { get; private set; }

        public CSVDatabase(string filePath)
        {
            FilePath = filePath;
        }

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
        /// Tries to load all accounts from the db-file.
        /// In case null is returned, the file is corrupted and should be replaced with an working one.
        /// </summary>
        /// <returns>The accounts if the loading was successfull; otherwise null</returns>
        private Account[] LoadAllAccounts()
        {
            try
            {
                // Opens the reader
                using (StreamReader sr = new StreamReader(this.FilePath))
                {
                    // Will hold all accounts
                    List<Account> accounts = new List<Account>();

                    // Reads all lines
                    string line;
                    while((line = sr.ReadLine()) != null){
                        // Checks if the line is an account
                        if(line[0] == 'A')
                        {
                            // Tries to load the line
                            Account a = this.ParseAccountFromLine(line.Substring(1, line.Length - 1));

                            // Checks if the loading failed
                            if (a == null)
                                return null;

                            accounts.Add(a);
                        }
                    }

                    // Returns all loaded accounts
                    return accounts.ToArray();
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
        /// <returns>The next free account id</returns>
        private int GetNextAccountID()
        {
            // Loads all accounts
            Account[] accs = this.LoadAllAccounts();

            // Checks if no accounts are found
            if (accs == null || accs.Length == 0)
                return 0;

            // Gets the account with the highest id
            int highestId = accs.Aggregate((a, b) => a.Id > b.Id ? a : b).Id;

            // Returns the next highest id
            return highestId + 1;
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

        /// <summary>
        /// Ensures that the required database file exists
        /// </summary>
        private void EnsureFileExistence()
        {
            // Checks if the file does not exist
            if (!File.Exists(this.FilePath))
                File.Create(this.FilePath);
        }

        #region IDatabase inhert

        public void Close()
        {
            // Not needed
        }

        public Account CreateNewAccount(Account pseudoAccount)
        {
            this.EnsureFileExistence();

            // Gets the next account id
            int id = this.GetNextAccountID();

            // Creates the full account
            Account acc = new Account(id, pseudoAccount);

            // Appends the next account
            try
            {
                // Appends the account to the database
                using (StreamWriter sr = new StreamWriter(this.FilePath, true, Encoding.UTF8))
                    sr.WriteLine("A"+this.GetLineFromAccount(acc));
                // Returns the newly created account
                return acc;
            }
            catch
            {
                throw new DatabaseException("Fehler beim sichern des Benutzers.");
            }
        }

        public Transaction CreateNewTransaction(Transaction pseudoTransaction)
        {
            this.EnsureFileExistence();

            throw new NotImplementedException();
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
                        if (line[0] != 'A')
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
            }
            catch
            {
                throw new DatabaseException("Fehler beim lesen der Datenbank.");
            }

            throw new NotImplementedException();
        }

        public Transaction[] GetAccountTransactions(Account account)
        {
            this.EnsureFileExistence();

            throw new NotImplementedException();
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
                        if(ln[0] != 'A')
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
