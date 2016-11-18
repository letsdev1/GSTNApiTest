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
    }
}
