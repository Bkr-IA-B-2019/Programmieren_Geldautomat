namespace Geldautomat.database.exceptions
{
    class DatabaseConnectionException : DatabaseException
    {
        public DatabaseConnectionException(string message) : base(message) { }
    }
}
