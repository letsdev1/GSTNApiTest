using GSTN_API.Helper;
using GSTN_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_API
{


    public class APIBuilder
    {
        private CEncryption encryption = new CEncryption();
        private string domain = URLs.Domain;

        public APIBuilder()
        {
            Context.LoggedUser = Constants.testUser;
            Context.AppKeyBytes = Encoding.UTF8.GetBytes(Constants.appKey); //CEncryption.CreateKey();



        }

        public void AuthenticationRequest(string OTP)
        {

            string result = GenericAuthenticationRequest(OTP); //OTP and Authentication is same
            Auth auth = JsonParser.ParseAuth(result);

            byte[] decryptedKey = encryption.Decrypt(auth.SEK, Context.AppKeyBytes);
            byte[] hidecipher = Convert.FromBase64String(Context.AppKey);

            string tryDecipher = System.Text.Encoding.UTF8.GetString(decryptedKey);

            Context.Decipher = tryDecipher;
            Context.DecipherBytes = decryptedKey;
            Context.AuthToken = auth.Auth_Token;
        }

        /// <summary>
        /// returns the OTP generated
        /// </summary>
        /// <returns></returns>
        public string OTPRequest()
        {
            string result = GenericAuthenticationRequest(); //OTP and Authentication is same

            string OTP = JsonParser.ParseOTP(result);

            if (!string.IsNullOrEmpty(OTP))
            {
                //store the values in context to be used at a later stage
                Logger.GetLogger().Log("Generated OTP is " + OTP);
            }
            else
            {
                Logger.GetLogger().LogException(new Exception("Couldn't generate the OTP.")); //logging exception will log the stacktrace too.
            }

            return OTP;

        }

        /// <summary>
        /// Returns the response
        /// </summary>
        /// <param name="OTP"></param>
        /// <returns></returns>
        private string GenericAuthenticationRequest(string OTP = "")
        {
            WebClient client = new WebClient();

            string encryptedAppKey = "";

            if (string.IsNullOrEmpty(Context.AppKey))
                encryptedAppKey = encryption.EncryptTextWithPublicKey(Constants.appKey); //app key is your application key
            else
                encryptedAppKey = Context.AppKey;

            Context.AppKey = encryptedAppKey;
            string id = Convert.ToBase64String(Context.AppKeyBytes);

            string action = string.IsNullOrEmpty(OTP) ? "OTPREQUEST" : "AUTHTOKEN";
            string otpJson = string.IsNullOrEmpty(OTP) ? "" : ", \"" + JsonNames.OTP + "\":\"" + encryption.Encrypt(OTP, Context.AppKeyBytes) + "\"";

            string requestPayload = "{\"" + JsonNames.Action + "\": \"" + action + "\"," +
                "\"" + JsonNames.AppKey + "\": \"" + encryptedAppKey + "\"," +
                "\"" + JsonNames.UserName + "\": \"" + Constants.testUser + "\"" +
                    otpJson +
                "}";

            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add("auth-token", "8a227e0ba56042a0acdf98b3477d2c03"); //8a227e0ba56042a0acdf98b3477d2c03
            client.Headers.Add("client-secret", "f328fe52752349c893aa93adcffed8f5");
            client.Headers.Add("clientid", "l7xx6df7496552824f15b7f4523c0a1fc114");
            client.Headers.Add("ip-usr", "12.8.91.80");
            client.Headers.Add("postman-token", "1de717e2-8768-166e-323c-e315492f79d3");
            client.Headers.Add("state-cd", "11");
            client.Headers.Add("txn", "returns");
            client.Headers.Add("username", Constants.testUser);

            
            string url = domain + Constants.URL_Authentication_TaxPayer;
            //client.Headers[HttpRequestHeader.Authorization] = "token here";
            var result = client.UploadString(url, "Post", requestPayload);
            
            return result;
        }
    }
}
