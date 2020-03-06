using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    ///  Creator: Jaeho Kim
    ///  Created: 2020/02/27
    ///  Approver: Rasha Mohammed
    ///  
    ///  Transaction Data Transfer Object
    /// </summary>
    /// <remarks>
    /// Updated by: Robert Holmes
    /// Updated on: 2020/03/03
    /// Changes: Added ProductAmounts, Date, Status, and Type fields and constructor.
    /// </remarks>
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int EmployeeID { get; set; }
        public string Notes { get; set; }
        public Dictionary<Product, int> ProductAmounts { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Initiates transaction with a not null empty dictionary of products and ints.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public Transaction()
        {
            ProductAmounts = new Dictionary<Product, int>();
        }
    }
}
