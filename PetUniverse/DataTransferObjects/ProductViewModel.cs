using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Robert Holmes
    /// DATE: 2/21/2020
    /// CHECKED BY: Cash Carlson
    /// 
    /// Holds the values of interest for display in a datagrid.
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATED DATE: 
    /// CHANGES: 
    /// 
    /// </remarks>
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string ProductID { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/21/2020
        /// CHECKED BY:  Cash Carlson
        /// 
        /// Default constructor.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public ProductViewModel() { }
    }
}
