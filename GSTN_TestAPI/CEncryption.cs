using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_TestAPI
{
    public class CEncryption
    {

        public static X509Certificate2 getPublicKey()
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            X509Certificate2 cert2 = new X509Certificate2(@"C:\Users\Vikas\Downloads\GSTN_PublicKey.cer");
            return cert2;
        }



        private string HMAC_Encrypt(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }

            
        }


        public string Encrypt(string plainText, string key)
        {
            byte[] dataToEncrypt = UTF8Encoding.UTF8.GetBytes(plainText);

            AesManaged tdes = new AesManaged();

            tdes.KeySize = 256;
            tdes.BlockSize = 128;
            tdes.Key = Encoding.ASCII.GetBytes(key);
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform crypt = tdes.CreateEncryptor();
            byte[] cipher = crypt.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            tdes.Clear();
            return Convert.ToBase64String(cipher, 0, cipher.Length);
          
        }

        public byte[] Decrypt(string encryptedText, string key)
        {
            byte[] dataToDecrypt = Convert.FromBase64String(encryptedText);

            AesManaged tdes = new AesManaged();

            tdes.KeySize = 256;
            tdes.BlockSize = 128;
            tdes.Key = Encoding.ASCII.GetBytes(key);
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform decrypt = tdes.CreateDecryptor();
            byte[] deCipher = decrypt.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            tdes.Clear();

            return deCipher;
        }

        public byte[] Decrypt(string encryptedText, byte [] keys)
        {
            byte[] dataToDecrypt = Convert.FromBase64String(encryptedText);

            AesManaged tdes = new AesManaged();

            tdes.KeySize = 256;
            tdes.BlockSize = 128;
            tdes.Key = Encoding.ASCII.GetBytes(key);
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform decrypt = tdes.CreateDecryptor();
            byte[] deCipher = decrypt.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            tdes.Clear();

            return deCipher;
        }


        public string EncryptTextWithPublicKey(string input)
        {
            X509Certificate2 certificate = getPublicKey();
            RSACryptoServiceProvider RSA = (RSACryptoServiceProvider)certificate.PublicKey.Key;
           // RSA.KeySize = 256;

            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] bytesEncrypted = RSA.Encrypt(bytesToBeEncrypted, false);

            string result = Convert.ToBase64String(bytesEncrypted);
            return result;

        }


    }


}
