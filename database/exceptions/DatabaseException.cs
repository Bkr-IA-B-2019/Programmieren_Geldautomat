using System;

namespace Geldautomat.database.exceptions
{
    class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message) { }
    }
}
