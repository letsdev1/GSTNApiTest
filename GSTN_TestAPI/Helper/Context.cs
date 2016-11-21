using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_API.Helper
{

    public class Context
    {
        public static string AppKey;
        public static byte[] AppKeyBytes;
        public static string AppKey_NormalEncryption;
        public static string LoggedUser;
        public static byte[] DecipherBytes;
        public static string Decipher;
        public static string AuthToken;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">The payload downloaded from the URL Request</param>
        /// <returns></returns>
        public static string DecryptPayload(string rek, string data)
        {
            CEncryption encryption = new CEncryption();
            byte[] decryptREK = encryption.Decrypt(rek, Context.DecipherBytes);
            byte[] jsonData = encryption.Decrypt(data, decryptREK);

            string json = Encoding.UTF8.GetString(jsonData);
            byte[] decodeJson = Convert.FromBase64String(json);

            string finalJson = Encoding.UTF8.GetString(decodeJson);

            return finalJson;
        }

    }
}
