using System;
using System.Text;

namespace Hancock.Helpers
{
    /// <summary>
    ///     Base64 helper methods
    /// </summary>
    public static class Base64Helper
    {
        /// <summary>
        ///     URL encode a string
        /// </summary>
        /// <param name="data">Data to encode</param>
        /// <param name="encoding">Encoding to use</param>
        /// <returns>URL safe data</returns>
        public static string SafeEncode(string data, Encoding encoding = null)
        {
            if (encoding is null)
            {
                encoding = Encoding.UTF8;
            }

            return SafeEncode(encoding.GetBytes(data));
        }

        /// <summary>
        ///     Encode data to make it safe for URLs
        /// </summary>
        /// <param name="data">Data to encode</param>
        /// <returns>Encoded string</returns>
        public static string SafeEncode(byte[] data)
        {
            var encoded = Convert.ToBase64String(data);
            encoded = encoded.Split('=')[0];
            encoded = encoded.Replace('+', '-');
            encoded = encoded.Replace('/', '_');

            return encoded;
        }

        /// <summary>
        ///     Decode data that was encoded for URLs
        /// </summary>
        /// <param name="data">Data to decode</param>
        /// <returns>Decoded data</returns>
        public static byte[] SafeDecode(string data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            data = data.Replace('-', '+');
            data = data.Replace('_', '/');

            switch (data.Length % 4)
            {
                case 0:
                    break;
                case 2:
                    data += "==";
                    break;
                case 3:
                    data += "=";
                    break;
            }

            return Convert.FromBase64String(data);
        }
    }
}
