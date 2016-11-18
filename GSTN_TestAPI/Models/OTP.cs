using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSTN_TestAPI.Helper;
namespace GSTN_TestAPI.Models
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
                _otp = "102030"; //random OTP id for sandbox
            }
        }
        public string OTPText
        {
            get { return _otp; }
            set { _otp = value; }
        }
    }
}
