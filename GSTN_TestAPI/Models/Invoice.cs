using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_API.Models
{
    public class Invoice
    {
        public string Flag { get; set; }
        public string ChkSum { get; set; }
        public string INum { get; set; }
        public string IDT { get; set; }
        public double? Val { get; set; }
        public string POS { get; set; }
        public string Rchrg { get; set; }
        public string Pro_Ass { get; set; }
        public List<Item> Itms { get; set; }
    }
}
