using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_TestAPI.Helper.OutputFormat
{
    public class Output_OTP
    {

        private string status_cd;

        public string Status_CD
        {
            get { return status_cd; }
            set { status_cd = value; }
        }
        private string _otp;

        public Output_OTP()
        {
            if (Constants.Sandbox)
            {
                _otp = "102030"; //random OTP id for sandbox
            }
        }
        public string OTP
        {
            get { return _otp; }
            set { _otp = value; }
        }
    }
}
