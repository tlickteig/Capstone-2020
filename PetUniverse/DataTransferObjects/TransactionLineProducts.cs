using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class TransactionLineProducts
    {
        public int TransactionID { get; set; }
        public List<ProductVM> ProductsSold { get; set; }
    }
}
