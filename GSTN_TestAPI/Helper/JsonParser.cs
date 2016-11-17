using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using json = Newtonsoft.Json;
using GSTN_TestAPI.Helper.OutputFormat;

namespace GSTN_TestAPI.Helper
{
    public class JsonParser
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
                if (Constants.Sandbox)
                {
                    //since it is the Sandbox, let us just process the request for now.
                    //who knows their API is down, again :)
                    return output.OTP;
                }

                //error do nothing
            }

            return ""; //failed
        }


        public static Output_Auth ParseAuth(string response)
        {
            var output = json.JsonConvert.DeserializeObject<Output_Auth>(response);
            return output;
        }

    }
}
