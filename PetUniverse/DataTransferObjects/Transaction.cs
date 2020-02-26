using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Robert Holmes
    /// DATE: 2/14/2020
    /// CHECKED BY:
    /// 
    /// Holds data relevent to a transaction.
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATED DATE: 
    /// CHANGES: 
    /// 
    /// </remarks>
    public class Transaction
    {
        public int TransactionID { get; set; }
        public Dictionary<Product, int> ProductAmounts { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public int EmployeeID { get; set; }

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/21/2020
        /// CHECKED BY:
        /// 
        /// Initiates transaction with a not null empty dictionary of products and ints.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public Transaction()
        {
            ProductAmounts = new Dictionary<Product, int>();
        }
    }
}
