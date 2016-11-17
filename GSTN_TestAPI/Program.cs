using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using json = Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using GSTN_TestAPI.Helper;
using System.Security.Cryptography;
using GSTN_TestAPI.Helper.OutputFormat;

namespace GSTN_TestAPI
{
    class Program
    {
        //entry point
        static void Main(string[] args)
        {
            //////string domain = URLs.Domain;
            //////CEncryption encrypt = new CEncryption();
            //////string appKey = encrypt.EncryptTextWithPublicKey(Constants.appKey);
            //////string appKey1 = Constants.appKey;
            try
            {
                //////    string otp = "102030";

                //////    byte [] newKeys = Convert.FromBase64String(appKey);
                //////    //string data1 = encrypt.EncryptText(otp, newKeys);
                //////    string data = encrypt.Encrypt(otp, appKey1);




                //////    WebClient client = new WebClient();
                //////    string encryptedAppKey = appKey;


                //////    string action = string.IsNullOrEmpty(otp) ? "OTPREQUEST" : "AUTHTOKEN";
                //////    string otpJson = string.IsNullOrEmpty(otp) ? "" : ", \"" + JsonNames.OTP + "\":\"" + data + "\"";

                //////    string requestPayload = "{\"" + JsonNames.Action + "\": \"" + action + "\"," +
                //////        "\"" + JsonNames.AppKey + "\": \"" + encryptedAppKey + "\"," +
                //////        "\"" + JsonNames.UserName + "\": \"" + Constants.testUser + "\"" +
                //////            otpJson +
                //////        "}";

                //////    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                //////    client.Headers.Add("auth-token", "8a227e0ba56042a0acdf98b3477d2c03");
                //////    client.Headers.Add("client-secret", "f328fe52752349c893aa93adcffed8f5");
                //////    client.Headers.Add("clientid", "l7xx6df7496552824f15b7f4523c0a1fc114");
                //////    client.Headers.Add("ip-usr", "12.8.91.80");
                //////    client.Headers.Add("postman-token", "1de717e2-8768-166e-323c-e315492f79d3");
                //////    client.Headers.Add("state-cd", "11");
                //////    client.Headers.Add("txn", "returns");
                //////    client.Headers.Add("username", Constants.testUser);






                //////    string url = domain + Constants.url_authentication_taxPayer;
                //////    //client.Headers[HttpRequestHeader.Authorization] = "token here";
                //////    var result = client.UploadString(url, "Post", requestPayload);

                APIBuilder builder = new APIBuilder();
                string s1 = builder.OTPRequest();
                builder.AuthenticationRequest(s1);



            }
            catch (Exception ex)
            {
                Logger.GetLogger().LogException(ex);
            }
        }
    }





}



   


   

   





