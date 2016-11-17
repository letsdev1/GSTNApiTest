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
    }
}
