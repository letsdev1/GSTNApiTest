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
using GSTN_TestAPI.Models;

namespace GSTN_TestAPI
{
    class Program
    {
        //entry point
        static void Main(string[] args)
        {
            try
            {

                APIBuilder builder = new APIBuilder();
                string s1 = builder.OTPRequest();
                builder.AuthenticationRequest(s1);

                //now GSTR Data
                /*GSTRModules.GSTR1 gstr1 = new GSTRModules.GSTR1();
                gstr1.PullB2bInvoices();
                */

                //json parse

                //for getting B2b Invoice

                GSTRModules.GSTR1 gstrModule = new GSTRModules.GSTR1();
                gstrModule.PullB2bInvoices();

                //for saving invoice

                string json = File.ReadAllText(@"C:\Users\Vikas\Dropbox\Projects\Ongoing\Other\GSTN\GSTNApiTest\GSTN_TestAPI\Helper\SamplePaylodJson.txt");
                GSTR1Main gstr1 = Newtonsoft.Json.JsonConvert.DeserializeObject<GSTR1Main>(json);
                string payload = Newtonsoft.Json.JsonConvert.SerializeObject(gstr1);
                //gstrModule.RetSave(payload);


                CEncryption encryption = new CEncryption();

                string encryptedAppKey = encryption.Encrypt(Constants.appKey, Constants.appKey);
                string decryptedAppKey = System.Text.Encoding.UTF8.GetString(encryption.Decrypt(encryptedAppKey, Constants.appKey));



            }
            catch (Exception ex)
            {
                Logger.GetLogger().LogException(ex);
            }
        }
    }





}



   


   

   





