﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using json = Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using GSTN_API.Helper;
using System.Security.Cryptography;
using GSTN_API.Models;
using GSTN_API.GSTRModules;

namespace GSTN_API
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

                //for getting B2b Invoices

                GSTRModules.GSTR1 gstrModule = new GSTRModules.GSTR1();
                WrapperB2B b2bInvoices = gstrModule.PullB2bInvoices();

                //Here in B2bInvoices, the invoices would come in.

                //for saving invoice - 

                //From here -- In Progress --  Dont use this code as I have not yet completed the code below this point

                string json = File.ReadAllText(@"C:\Users\Vikas\Dropbox\Projects\Ongoing\Other\GSTN\GSTNApiTest\GSTN_API\Helper\SamplePaylodJson.txt");
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



   


   

   





