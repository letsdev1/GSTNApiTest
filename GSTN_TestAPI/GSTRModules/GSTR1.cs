using GSTN_TestAPI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_TestAPI.GSTRModules
{
    public class GSTR1
    {
        public void PullB2bInvoices()
        {
            WebClient client = new WebClient();

            string requestPayload = "{\"" + JsonNames.Action + "\": \"" + "" + "\"," +
                "\"" + JsonNames.AppKey + "\": \"" + "" + "\"," +
                "\"" + JsonNames.UserName + "\": \"" + Constants.testUser + "\"" +
                "}";

            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add("auth-token", Context.AuthToken);
            //client.Headers.Add("client-secret", "f328fe52752349c893aa93adcffed8f5");
            //client.Headers.Add("clientid", "l7xx6df7496552824f15b7f4523c0a1fc114");
            //client.Headers.Add("ip-usr", "12.8.91.80");
            //client.Headers.Add("postman-token", "1de717e2-8768-166e-323c-e315492f79d3");
            //client.Headers.Add("state-cd", "11");
            //client.Headers.Add("txn", "returns");
            //client.Headers.Add("username", Constants.testUser);

            string queryString = string.Format("?{0}=29HJKPS9689A8Z4&{1}=Y&{2}=072016", JsonNames.GSTIN, JsonNames.ActionRequired, JsonNames.ReturnPeriod);
            string url = URLs.GSTR1_B2BInvoices + queryString;
            //client.Headers[HttpRequestHeader.Authorization] = "token here";
            var result = client.UploadString(url, "Get");

           

        }
    }
}
