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
                //error do nothing
            }
            return ""; //failed
        }
    }
}
