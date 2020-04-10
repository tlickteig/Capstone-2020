using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/02/21
    /// Approver: Cash Carlson
    /// 
    /// Holds the values of interest for display in a datagrid.
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    public class ProductVM
    {
        public string Name { get; set; }
        public string ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver:  Cash Carlson
        /// 
        /// Default constructor.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public ProductVM() { }


        public bool Taxable { get; set; }
        public string ItemDescription { get; set; }
        public bool Active { get; set; }

        public int QuantityInStock { get; set; }
    }
}
