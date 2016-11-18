using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_TestAPI.Helper
{
    public class URLs
    {
        public static string Domain
        {
            get
            {
                if (Constants.Sandbox == true)
                {
                    return @"http://devapi.gstsystem.co.in";
                }
            }
        }

        public static string SSLDomain
        {
            get
            {
                if (Constants.Sandbox == true)
                {
                    return @"https://devapi.gstsystem.co.in";
                }
            }
        }

        public static string GSTR1_B2BInvoices
        {
            get
            {
                return Domain + Constants.URL_GSTR1_B2BInvoices;
            }
        }

    }
}
