using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Jaeho Kim
    /// DATE: 2/27/20
    /// APROVER: Ethan Holmes
    /// This is the TransactionVM object in which the End User 
    /// will see. It contains data that the end user can understand.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATE DATE: N/A
    /// CHANGE DESCRIPTION: N/A
    /// </remarks>
    public class TransactionVM
    {
        public int TransactionID { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionTypeID { get; set; }
        public string Notes { get; set; }
    }
}
