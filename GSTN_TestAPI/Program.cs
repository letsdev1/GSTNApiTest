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

namespace GSTN_TestAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                Logger.GetLogger().Log("Starting the request");
                APIBuilder builder = new APIBuilder();
                Logger.GetLogger().Log("Builder object created");
                string OTP = builder.OTPRequest();
            }
            catch(Exception ex)
            {
                Logger.GetLogger().LogException(ex);
            }
        }
    }

    public class URLs
    {
        public static string Domain
        {
            get
            {
                if(Constants.Sandbox == true)
                {
                    return @"http://devapi.gstsystem.co.in";
                }
            }
        }
    }
    public class Constants
    {
        public const bool Sandbox = true;
    }


    public class Context
    {
        public static string AppKey;
        public static string LoggedUser;
    }

    public class APIBuilder
    {
        private CEncryption encryption = new CEncryption();
        private string domain = URLs.Domain;
        private string testUser = "GSTNHelper";
        private string appKey = "aa2cc65c-5xxx-46ec-b356-e09503af";
        private const string version_1 = "v0.1";
        private string url_authentication_taxPayer = "/taxpayerapi/v0.1/authenticate";
        


        public void AuthenticationRequest(string OTP)
        {

        }

        /// <summary>
        /// returns the OTP generated
        /// </summary>
        /// <returns></returns>
        public string OTPRequest()
        {
            string OTP = JSonParser.ParseOTP(result);

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

        private void GenericAuthenticationRequest(string OTP = "")
        {
            WebClient client = new WebClient();
            string encryptedAppKey = "";
            if(string.IsNullOrEmpty(Context.AppKey))
                encryptedAppKey = encryption.EncryptTextWithPublicKey(appKey); //app key is your application key

            Context.AppKey = encryptedAppKey;
            Context.LoggedUser = testUser;

            string action = string.IsNullOrEmpty(OTP) ? "OTPREQUEST" : "AUTHTOKEN";

            string requestPayload = "{\"" + JsonNames.Action + "\": \"OTPREQUEST\"," +
                "\"" + JsonNames.AppKey + "\": \"" + encryptedAppKey + "\"," +
                "\"" + JsonNames.UserName + "\": \"" + testUser + "\"}";

            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add("auth-token", "8a227e0ba56042a0acdf98b3477d2c03");
            client.Headers.Add("client-secret", "f328fe52752349c893aa93adcffed8f5");
            client.Headers.Add("clientid", "l7xx6df7496552824f15b7f4523c0a1fc114");
            client.Headers.Add("ip-usr", "12.8.91.80");
            client.Headers.Add("postman-token", "1de717e2-8768-166e-323c-e315492f79d3");
            client.Headers.Add("state-cd", "11");
            client.Headers.Add("txn", "returns");
            client.Headers.Add("username", testUser);

            string url = domain + url_authentication_taxPayer;
            //client.Headers[HttpRequestHeader.Authorization] = "token here";
            var result = client.UploadString(url, "Post", requestPayload);

        }

    }



    public class JSonParser
    {
        public static string ParseOTP(string response)
        {
            var output = json.JsonConvert.DeserializeObject<Output_OTP>(response);
            if (output.Status_CD == "1")
            {
                //bingo

                if (Constants.Sandbox)
                {
                    //just 1 is fine, anything will be a OTP anyway
                }

                return output.OTP;
            }
            else
            {
                //error do nothing
            }
            return ""; //failed
        }
    }


    /// <summary>
    /// All the variables to be used in Json will be here
    /// </summary>
    public class JsonNames
    {
        public const string Action = "action";
        public const string UserName = "username";
        public const string AppKey = "appkey";
        public const string OTP = "otp";
    }

    public class Output_OTP
    {

        private string status_cd;

        public string Status_CD
        {
            get { return status_cd; }
            set { status_cd = value; }
        }
        private string _otp; 



        public Output_OTP()
        {
            if (Constants.Sandbox)
            {
                _otp = "192918"; //random OTP id for sandbox
            }
        }
        public string OTP
        {
            get { return _otp; } set { _otp = value; }
        }
    }


    public class Logger
    {
        private static Logger _logger = null;
        private string _fileName = string.Empty;

        private Logger()
        {
            _fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (!Directory.Exists(_fileName + "\\GSTNApi"))
            {
                Directory.CreateDirectory(_fileName + "\\GSTNApi");
            }

            _fileName = Path.Combine(_fileName, "GSTNApi", "log.txt");

        }

        public static Logger GetLogger()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }
            return _logger;
        }

        public void Log(string text)
        {
            string newText = string.Format("Logged At {1} \r \r {0} \r \r", text, DateTime.Now.ToString());
            File.AppendAllText(_fileName, newText);
        }

        public void LogException(Exception ex)
        {
            string exceptionText = GetExceptionStack(ex);
        }

        public string GetExceptionStack(Exception ex)
        {
            string exceptionText = "";

            if (ex == null)
            {
                return "";
            }
            else
            {
                string innerText = GetExceptionStack(ex.InnerException);
                string currentExText = "";


                exceptionText = string.IsNullOrEmpty(innerText) ?

                                    currentExText = "---------------------------------------" +
                                    Environment.NewLine +
                                    ex.Message +
                                    Environment.NewLine +
                                    ex.StackTrace +
                                    Environment.NewLine +
                                    "---------------------------------------":

                                    currentExText = "---------------------------------------" +
                                    Environment.NewLine +
                                    ex.Message +
                                    Environment.NewLine +
                                    ex.StackTrace +
                                    Environment.NewLine +
                                    innerText +
                                    Environment.NewLine +
                                    "---------------------------------------";

                
                

            }

            return exceptionText;


        }

    }


}
