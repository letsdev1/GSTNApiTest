using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using json = Newtonsoft.Json;
using GSTN_TestAPI.Models;

namespace GSTN_TestAPI.Helper
{
    public class JsonParser
    {
        public static string ParseOTP(string response)
        {
            var output = json.JsonConvert.DeserializeObject<OTP>(response);
            if (output.Status_CD == "1")
            {
                //bingo

                if (Constants.Sandbox)
                {
                    //just 1 is fine, anything will be a OTP anyway
                }

                return output.OTPText;
            }
            else
            {
                if (Constants.Sandbox)
                {
                    //since it is the Sandbox, let us just process the request for now.
                    //who knows their API is down, again :)
                    return output.OTPText;
                }

                //error do nothing
            }

            return ""; //failed
        }


        public static Auth ParseAuth(string response)
        {
            var output = json.JsonConvert.DeserializeObject<Auth>(response);
            return output;
        }

    }
}
