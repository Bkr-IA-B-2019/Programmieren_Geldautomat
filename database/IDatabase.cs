using Geldautomat.database.objects;

namespace Geldautomat.database
{
    interface IDatabase
    {

        /// <summary>
        /// Connects the to databse
        /// </summary>
        /// <exception cref="DatabaseConnectionException">
        /// Gets thrown, when the database failes to connect or open.
        /// Contains the message of the error
        /// </exception>
        void Connect();

        /// <summary>
        /// Closes the connection to the database
        /// </summary>
        void Close();


        /// <summary>
        /// Searches the account that belongs to the given id
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="DatabaseException">
        /// Gets thrown, when the successful communication with the database failes
        /// </exception>
        /// <returns>If the account got found, the account; otherwise null</returns>
        Account GetAccountByID(int id);

        /// <summary>
        /// Searches all transaction belonging to the given account
        /// </summary>
        /// <param name="account">The account of which the transactions should be requested</param>
        /// <exception cref="DatabaseException">
        /// Gets thrown, when the successful communication with the database failes
        /// </exception>
        /// <returns>An array of all transactions a user has done</returns>
        Transaction[] GetAccountTransactions(Account account);

        /// <summary>
        /// Inserts the new account into the database
        /// </summary>
        /// <param name="pseudoAccount">The account that should be inserted (Does not contain an id)</param>
        /// <exception cref="DatabaseException">
        /// Gets thrown, when the successful communication with the database failes
        /// </exception>
        /// <returns>The newly created account with the updates like the id</returns>
        Account CreateNewAccount(Account pseudoAccount);

        /// <summary>
        /// Inserts a new transaction into the database
        /// </summary>
        /// <param name="transaction">The new transaction</param>
        /// <exception cref="DatabaseException">
        /// Gets thrown, when the successful communication with the database failes
        /// </exception>
        /// <returns>The created transaction with the updates from the database like the id</returns>
        Transaction CreateNewTransaction(Transaction transaction);

        /// <summary>
        /// Updates the accounts data to the database.
        /// </summary>
        /// <param name="account">The account that shall be updated</param>
        /// <exception cref="DatabaseException">
        /// Gets thrown, when the successful communication with the database failes
        /// </exception>
        void UpdateAccount(Account account);
    }
}
