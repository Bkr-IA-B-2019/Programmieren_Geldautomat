using Geldautomat.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldautomat
{
    static class Config
    {
        /// <summary>
        /// What database gets used
        /// </summary>
        public static IDatabase USED_DATABASE = new SqliteDatabase();

        /// <summary>
        /// What kind of products can be bought
        /// </summary>
        public static string[] BUY_PRODUCTS =
        {
            "Bananen",
            "Äpfel",
            "Milch",
            "Diese Anwendung"
        };

        /// <summary>
        /// Which file to use when using the sqlite-database
        /// </summary>
        public static string SQLITE_FILE_NAME = "Bank.sqlite";

    }
}
