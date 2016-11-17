using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_TestAPI.Helper
{
    /// <summary>
    /// All the variables to be used in Json will be here
    /// </summary>
    public class JsonNames
    {

        #region Authentication

        public const string Action = "action";
        public const string UserName = "username";
        public const string AppKey = "appkey";
        public const string OTP = "otp";

        #endregion


        #region GSTR1
        public const string ActionRequired = "action_required";
        public const string GSTIN = "gstin"; //gst identification number. 
        public const string ReturnPeriod = "ret_period";
        #endregion



    }
}
