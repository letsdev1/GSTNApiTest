using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_TestAPI.Models
{
    public class B2BTransaction
    {
        public string CTIN
        {
            get;set;
        }

        public List<Invoice> Inv { get; set; }
    }
}
