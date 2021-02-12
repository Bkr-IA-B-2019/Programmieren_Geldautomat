using System;

namespace Geldautomat.database.exceptions
{
    class DatabaseException : Exception
    {
        /// <summary>
        /// The message that can also be displayed to the end user
        /// </summary>
        public string Message { private set; get; }

        public DatabaseException(string message)
        {
            this.Message = message;
        }
    }
}
