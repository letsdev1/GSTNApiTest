using GSTN_API.Helper;
using GSTN_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_API.GSTRModules
{
    public class GSTR1
    {

        public void RetSave(string payload)
        {
            WebClient client = new WebClient();

            //encrypt payload
            CEncryption encryption = new CEncryption();
            string encryptedPayload = encryption.Encrypt(payload, Context.DecipherBytes);

            string requestPayload = "{\"" + JsonNames.Action + "\": \"RETSAVE\"," +
                "\"" + JsonNames.Data + "\": \"" + encryptedPayload + "\"," +
                "\"" + JsonNames.HMAC + "\": \"" + encryption.HMAC_Encrypt(Context.DecipherBytes) + "\"" +
                "}";


            client.Headers.Add("client-secret", "f328fe52752349c893aa93adcffed8f5");
            client.Headers.Add("clientid", "l7xx6df7496552824f15b7f4523c0a1fc114");
            client.Headers.Add("ip-usr", "12.8.91.80");
            client.Headers.Add("postman-token", "1de717e2-8768-166e-323c-e315492f79d3");
            client.Headers.Add("state-cd", "07");
            client.Headers.Add("txn", "returns");


            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add("auth-token", Context.AuthToken);
            client.Headers.Add("username", Constants.testUser);
            string url = URLs.GSTR1_B2BInvoices;
            var result = client.UploadString(url, "PUT", encryptedPayload);
        }

        public WrapperB2B PullB2bInvoices()
        {
            WebClient client = new WebClient();

            string requestPayload = "{\"" + JsonNames.Action + "\": \"" + "" + "\"," +
                "\"" + JsonNames.AppKey + "\": \"" + "" + "\"," +
                "\"" + JsonNames.UserName + "\": \"" + Constants.testUser + "\"" +
                "}";
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            client.Headers.Add("client-secret", "f328fe52752349c893aa93adcffed8f5");
            client.Headers.Add("clientid", "l7xx6df7496552824f15b7f4523c0a1fc114");
            client.Headers.Add("ip-usr", "12.8.91.80");
            client.Headers.Add("postman-token", "1de717e2-8768-166e-323c-e315492f79d3");
            client.Headers.Add("state-cd", "07");
            client.Headers.Add("txn", "returns");
            client.Headers.Add("auth-token", Context.AuthToken);
            client.Headers.Add("action", "B2B");
            client.Headers.Add("username", Constants.testUser);
            //string queryString = string.Format("?{0}=29HJKPS9689A8Z4", JsonNames.GSTIN);

            //string queryString = string.Format("?{0}=&{1}=Y&{2}=&{3}=B2B", JsonNames.GSTIN, JsonNames.ActionRequired, JsonNames.ReturnPeriod, JsonNames.Action);
            string url = URLs.GSTR1_B2BInvoices;

            CEncryption encryption = new CEncryption();

            client.QueryString.Add(JsonNames.GSTIN, "05BDIPA7164F1ZT");// encryption.Encrypt("29HJKPS9689A8Z4", Context.DecipherBytes));
            client.QueryString.Add(JsonNames.Action, "B2B");
            client.QueryString.Add(JsonNames.ActionRequired, "Y");
            client.QueryString.Add(JsonNames.ReturnPeriod, "072016");

            //client.Headers[HttpRequestHeader.Authorization] = "token here";

            try
            {

                var result = client.DownloadString(url);

                //now  decrypt data using the EK
                Output_B2B b2b = Newtonsoft.Json.JsonConvert.DeserializeObject<Output_B2B>(result);

                if (b2b.Status_CD == "0")
                {
                    //failed

                    Logger.GetLogger().LogException(new Exception("Failed B2B Request. Result is : " + result));
                    return null;
                }
                
                byte[] decryptREK = encryption.Decrypt(b2b.REK, Context.DecipherBytes);
                byte[] jsonData = encryption.Decrypt(b2b.Data, decryptREK);

                string json = Encoding.UTF8.GetString(jsonData);
                byte[] decodeJson = Convert.FromBase64String(json);

                string finalJson = Encoding.UTF8.GetString(decodeJson);
                WrapperB2B b2bs = Newtonsoft.Json.JsonConvert.DeserializeObject<WrapperB2B>(finalJson);
                return b2bs;

            }
            catch (Exception ex)
            {
                string s = ex.Message;
                string trace = ex.StackTrace;
            }

            return null;
        }
    }

    public class WrapperB2B
    {
        public List<B2BTransaction> B2B { get; set; }
    }



    public class Output_B2B
    {
        public string Data { get; set;}
        public string Status_CD { get; set; }
        public string REK
        {
            get;set;
        }
        public string HMAC
        {
            get;set;
        }
    }

}
