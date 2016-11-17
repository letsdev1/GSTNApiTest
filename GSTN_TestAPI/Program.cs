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
            try
            {

                APIBuilder builder = new APIBuilder();
                string s1 = builder.OTPRequest();
                builder.AuthenticationRequest(s1);

                //now GSTR Data
                GSTRModules.GSTR1 gstr1 = new GSTRModules.GSTR1();
                gstr1.PullB2bInvoices();
                

            }
            catch (Exception ex)
            {
                Logger.GetLogger().LogException(ex);
            }
        }
    }





}



   


   

   





