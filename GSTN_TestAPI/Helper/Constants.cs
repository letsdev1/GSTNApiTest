using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_TestAPI.Helper
{

    public class Constants
    {
        public const bool Sandbox = true;
        public const string version_1 = "v0.1";
        public const string URL_Authentication_TaxPayer = "/taxpayerapi/v0.1/authenticate";
        public const string URL_GSTR1_B2BInvoices = "/taxpayerapi/v0.1/returns/gstr1";


        #region DefaultSandboxValues
        public const string testUser = "GSTNHelper";
        public const string appKey = "9b0d686d-f4e3-4b49-a347-22440b8f";
        public const string GSTIN = "25ABCDE1028F6Z4";
        #endregion
    }
}
