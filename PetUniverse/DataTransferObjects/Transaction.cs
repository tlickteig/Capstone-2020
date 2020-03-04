using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
<<<<<<< HEAD
    /// <summary>
    /// NAME: Robert Holmes
    /// DATE: 2/14/2020
    /// CHECKED BY: Cash Carlson
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
        public List<Pair<Product, int>> ProductAmounts { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public int EmployeeID { get; set; }

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/21/2020
        /// CHECKED BY: Cash Carlson
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
=======

    /// <summary>
    ///  Creator: Jaeho Kim
    ///  Created: 2020/02/27
    ///  Approver: Ethan Holmes
    ///  
    ///  Transaction Data Transfer Object
    /// </summary>
	/// <remarks>
    ///  Updated by: Robert Holmes
    ///  Updated date: 2020/3/3
    ///  Changes: Added fields for 
    /// 
    /// </remarks>
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int EmployeeID { get; set; }
        public string Notes { get; set; }
>>>>>>> 63ae88aa846dfa3bac4349404bd0cd7c4150bad5
    }
}
