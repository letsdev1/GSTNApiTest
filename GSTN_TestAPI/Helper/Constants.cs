using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_API.Helper
{

    public class Constants
    {
        public const bool Sandbox = true;
        public const string version_1 = "v0.2";
        public const string URL_Authentication_TaxPayer = "/taxpayerapi/v0.2/authenticate";
        public const string URL_GSTR1_B2BInvoices = "/taxpayerapi/v0.1/returns/gstr1";


        #region DefaultSandboxValues
        public const string testUser = "Viso.TN.TP.1";
        public const string appKey = "1504F6AE-0010-4F41-8084-433AF897";
        public const string GSTIN = "33GSPTN4371G1Z5";
        #endregion
    }
}
