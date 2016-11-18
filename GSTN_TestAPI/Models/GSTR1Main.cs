using GSTN_API.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_API.Models
{
    public class GSTR1Main
    {

        public GSTR1Main()
        {
            GSTIN = Constants.GSTIN;
        }

        public string GSTIN
        {
            get;set;
        }

        public string FP
        {
            get;set;
        }

        public double? GT { get; set; }

        public List<B2BTransaction> B2B
        {
            get; set;
        }
    }
}
