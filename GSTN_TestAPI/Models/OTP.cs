using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSTN_API.Helper;
namespace GSTN_API.Models
{
    public class OTP
    {

        private string status_cd;

        public string Status_CD
        {
            get { return status_cd; }
            set { status_cd = value; }
        }
        private string _otp;

        public OTP()
        {
            if (Constants.Sandbox)
            {
                _otp = "575757"; //random OTP id for sandbox
            }
        }
        public string OTPText
        {
            get { return _otp; }
            set { _otp = value; }
        }
    }
}
