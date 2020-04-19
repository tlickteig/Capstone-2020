using System;

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
