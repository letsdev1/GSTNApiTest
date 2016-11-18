using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_API.Models
{
    public class Item
    {
        public int? Num { get; set; }

        public string Status { get; set; }
        public string TY { get; set; }
        public string Hsn_Sc { get; set; }

        public double? TxVal { get; set; }

        public double? IRT { get; set; }
        public double? IAmt { get; set; }

        public double? CRT { get; set; }
        public double? CAmt { get; set; }

        public double? SRT { get; set; }
        public double? SAmt { get; set; }
    }
}
