using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldautomat
{
    static class Extendings
    {
        /// <summary>
        /// Converts the given string to an base64 encoded string
        /// </summary>
        /// <param name="plainText">Plain text to convert to base64</param>
        /// <returns>The base64 string</returns>
        public static string AsBase64(this string plainText)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        }

        /// <summary>
        /// Converts the given string back to normal utf8-plaint text from base64 encoding
        /// </summary>
        /// <param name="base64">The base64 encoded text</param>
        /// <returns>The normal plain text if converting was successfull; otherwise null</returns>
        public static string AsUTF8FromBase64(this string base64)
        {
            try
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
            }catch
            {
                return null;
            }
        }

    }
}
