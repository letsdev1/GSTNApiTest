using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_API.Models
{
    public class Auth
    {
        private string auth_token;
        private string sek;
        private string status_cd;

        public string Auth_Token
        {
            get
            {
                return auth_token;
            }
            set
            {
                auth_token = value;
            }
        }


        public string Status_CD
        {
            get
            {
                return status_cd;
            }
            set
            {
                status_cd = value;
            }
        }

        public string SEK
        {
            get
            {
                return sek;
            }
            set
            {
                sek = value;
            }
        }
    }
}
