using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class OutgoingOrders
    {
        public int ItemID { get; set; }

        public int UserID { get; set; }

        public DateTime OrderDate { get; set; }

        public int ItemQuantity { get; set; }

        public string ItemCategoryID { get; set; }

        

    }
}
