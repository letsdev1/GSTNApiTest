using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_API
{
    /// <summary>
    /// 
    /// </summary>
    public class CEncryption
    {

        #region Generate Certificate
        public static X509Certificate2 getPublicKey()
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            X509Certificate2 cert2 = new X509Certificate2(@"C:\Users\Vikas\Downloads\GSTN_PublicKey.cer");
            return cert2;
        }

        public static X509Certificate2 getPublicKeyBase64()
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            X509Certificate2 cert2 = new X509Certificate2(@"C:\Users\Vikas\Downloads\gstn_public_key_base64.cer");
            return cert2;
        }

        #endregion


        #region Encryption Block

        public string Encrypt(string plainText, byte[] keyBytes)
        {
            byte[] dataToEncrypt = UTF8Encoding.UTF8.GetBytes(plainText);
            return Encrypt(dataToEncrypt, keyBytes);
        }

        public string Encrypt(string plainText, string key)
        {
            return Encrypt(plainText, Encoding.UTF8.GetBytes(key));
        }

        public string Encrypt(byte[] dataToEncrypt, byte[] keyBytes)
        {
            AesManaged tdes = new AesManaged();

            tdes.KeySize = 256;
            tdes.BlockSize = 128;
            tdes.Key = keyBytes;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform crypt = tdes.CreateEncryptor();
            byte[] cipher = crypt.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            tdes.Clear();
            return Convert.ToBase64String(cipher, 0, cipher.Length);

        }

        #endregion


        #region Decryption Block

        public byte[] Decrypt(string encryptedText, string key)
        {
            byte[] dataToDecrypt = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            return Decrypt(dataToDecrypt, keyBytes);
        }

        public byte[] Decrypt(string encryptedText, byte[] keys)
        {
            byte[] dataToDecrypt = Convert.FromBase64String(encryptedText);
            return Decrypt(dataToDecrypt, keys);
        }

        public byte[] Decrypt(byte[] dataToDecrypt, byte[] keys)
        {

            AesManaged tdes = new AesManaged();
            tdes.KeySize = 256;
            tdes.BlockSize = 128;
            tdes.Key = keys;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform decrypt = tdes.CreateDecryptor();
            byte[] deCipher = decrypt.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            tdes.Clear();

            return deCipher;
        }


        #endregion


        #region Encryption with Public Key

        public string EncryptTextWithPublicKey(string input)
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            return EncryptTextWithPublicKey(bytesToBeEncrypted);
        }

        public string EncryptTextWithPublicKey(byte[] bytesToBeEncrypted)
        {
            X509Certificate2 certificate = getPublicKey();
            RSACryptoServiceProvider RSA = (RSACryptoServiceProvider)certificate.PublicKey.Key;

            byte[] bytesEncrypted = RSA.Encrypt(bytesToBeEncrypted, false);

            string result = Convert.ToBase64String(bytesEncrypted);
            return result;
        }


        #endregion




    }


}
