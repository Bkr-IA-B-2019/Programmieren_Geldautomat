using Geldautomat.database.exceptions;
using Geldautomat.database.objects;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;

namespace Geldautomat.database
{
    class SqliteDatabase : IDatabase
    {
        
        /// <summary>
        /// The connection to the database
        /// </summary>
        private SqliteConnection connection;

        /// <summary>
        /// The name of the open database file
        /// </summary>
        public string File { get; private set; }
        public SqliteDatabase()
        {
            this.File = Config.SQLITE_FILE_NAME;
        }

        /// <summary>
        /// Ensures that the database-connection is established.
        /// </summary>
        /// <exception cref="DatabaseConnectionException">Throws if the database failes to connect</exception>
        private void EnsureConnection()
        {
            // Checks if the connection already established
            if (this.connection != null)
                return;

            try
            {
                // Creates the connection
                this.connection = new SqliteConnection($"data source=\"{this.File}\";");
                this.connection.Open();
            }
            catch (SqliteException)
            {
                // Resets the connection
                this.connection = null;
                throw new DatabaseConnectionException("Fehler beim öffnen der Datenbankverbindung.");
            }
        }

        public void Close()
        {
            // Checks if the connection is open
            if (this.connection.State == ConnectionState.Open)
                // Closes the connection
                this.connection.Close();
        }

        public Account GetAccountByID(int id)
        {
            this.EnsureConnection();
            try
            {
                // Creates a new command
                var cmd = this.connection.CreateCommand();
                cmd.CommandText = @"
                    SELECT *
                    FROM Accounts
                    WHERE id=$id;
                ";

                // Appends the parameters
                cmd.Parameters.AddWithValue("$id", id);

                // Executes the command get gets the result
                using (var reader = cmd.ExecuteReader())
                    // Checks if a user got found
                    if (reader.Read())
                    {
                        // Creates the new account
                        return new Account(
                            id,                     // Account id
                            reader.GetDateTime(1)   // Creation date
                        )
                        {
                            Firstname = reader.GetString(2),
                            Lastname = reader.GetString(3),
                            Money = reader.GetDecimal(4),
                            PinHash = reader.GetString(5),
                            PinSalt = reader.GetString(6)
                        };
                    }
                    else
                        return null;
            }
            catch (SqliteException)
            {
                throw new DatabaseException("Fehler bei der Abfrage mit der Datenbank.");
            }
        }

        public Transaction[] GetAccountTransactions(Account account)
        {
            this.EnsureConnection();
            try
            {
                // Creates a new command
                var cmd = this.connection.CreateCommand();
                cmd.CommandText = @"
                    SELECT *
                    FROM Transactions
                    WHERE accountid=$id;
                ";

                // Appends the parameters
                cmd.Parameters.AddWithValue("$id", account.Id);

                // List with all transactions
                var transactions = new List<Transaction>();

                // Executes the command get gets the result
                using (var reader = cmd.ExecuteReader())
                    // Checks if a user got found
                    while (reader.Read())
                    {
                        // Creates the transaction
                        transactions.Add(
                            new Transaction(
                                reader.GetInt32(0),     // Id
                                reader.GetDecimal(1),   // Money
                                reader.GetBoolean(2),   // Subtracted
                                account.Id,             // Account id
                                reader.GetDateTime(4)   // Datetime
                            )
                        );
                    }

                // Returns all found transactions
                return transactions.ToArray();
            }
            catch (SqliteException)
            {
                throw new DatabaseException("Fehler bei der Abfrage mit der Datenbank.");
            }
        }

        public Account CreateNewAccount(Account pseudoAccount)
        {
            this.EnsureConnection();
            try
            {
                // Creates a new command
                var cmd = this.connection.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO Accounts
                    (createdatetime,firstname,lastname,money,pinhash,pinsalt)
                    VALUES
                    ($cdt,$fn,$ln,$m,$ph,$ps);
                ";

                // Appends the parameters
                cmd.Parameters.AddWithValue("$cdt", pseudoAccount.CreateDateTime);
                cmd.Parameters.AddWithValue("$fn", pseudoAccount.Firstname);
                cmd.Parameters.AddWithValue("$ln", pseudoAccount.Lastname);
                cmd.Parameters.AddWithValue("$m", pseudoAccount.Money);
                cmd.Parameters.AddWithValue("$ph", pseudoAccount.PinHash);
                cmd.Parameters.AddWithValue("$ps", pseudoAccount.PinSalt);

                // Executes the command get gets the result
                cmd.ExecuteNonQuery();

                // Gets the last insert id
                int id = this.GetLastInsertedID();

                // Creates the new account
                return new Account(id,pseudoAccount);
            }
            catch (SqliteException)
            {
                throw new DatabaseException("Fehler beim sichern des Account's in der Datenbank.");
            }
        }

        public Transaction CreateNewTransaction(Transaction pseudoTransaction)
        {
            this.EnsureConnection();
            try
            {
                // Creates a new command
                var cmd = this.connection.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO Transactions
                    (translatedmoney,subtracted,accountid,datetime)
                    VALUES
                    ($tm,$s,$aid,$dt);
                ";

                // Appends the parameters
                cmd.Parameters.AddWithValue("$tm", pseudoTransaction.TranslatedMoney);
                cmd.Parameters.AddWithValue("$s", pseudoTransaction.Subtracted);
                cmd.Parameters.AddWithValue("$aid", pseudoTransaction.AccountId);
                cmd.Parameters.AddWithValue("$dt", pseudoTransaction.DateTime);

                // Executes the command get gets the result
                cmd.ExecuteNonQuery();

                // Gets the last insert id
                int id = this.GetLastInsertedID();

                // Creates the new account
                return new Transaction(id, pseudoTransaction);
            }
            catch (SqliteException)
            {
                throw new DatabaseException("Fehler beim sichern der Transaktion in der Datenbank.");
            }
        }

        public void UpdateAccount(Account account)
        {
            this.EnsureConnection();
            try
            {
                // Creates a new command
                var cmd = this.connection.CreateCommand();
                cmd.CommandText = @"
                    UPDATE ACCOUNTS
                    SET createdatetime=$cdt, firstname=$fn, lastname=$ln, money=$m, pinhash=$ph, pinsalt=$ps
                    WHERE id=$id;
                ";

                // Appends the parameters
                cmd.Parameters.AddWithValue("$cdt", account.CreateDateTime);
                cmd.Parameters.AddWithValue("$fn", account.Firstname);
                cmd.Parameters.AddWithValue("$ln", account.Lastname);
                cmd.Parameters.AddWithValue("$m", account.Money);
                cmd.Parameters.AddWithValue("$ph", account.PinHash);
                cmd.Parameters.AddWithValue("ps", account.PinSalt);
                cmd.Parameters.AddWithValue("$id", account.Id);

                // Executes the command get gets the result
                cmd.ExecuteNonQuery();
            }
            catch (SqliteException)
            {
                throw new DatabaseException("Fehler beim sichern des Accounts in der Datenbank.");
            }
        }


        /// <summary>
        /// Gets the last inserted row_id
        /// </summary>
        private int GetLastInsertedID()
        {
            this.EnsureConnection();
            // Creates the command
            var cmd = this.connection.CreateCommand();
            cmd.CommandText = @"
                SELECT last_insert_rowid();
            ";
            // Returns the last row id
            return (int)((long)cmd.ExecuteScalar());
        }
    }
}
