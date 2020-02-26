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
    /// CHECKED BY: Cash Carlson
    /// 
    /// Holds data relevant to a Product.
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATED DATE: 
    /// CHANGES: 
    /// 
    /// </remarks>
    public class Product
    {
        public string ProductID { get; set; }
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public Boolean Taxable { get; set; }

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/21/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Default constructor.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public Product()
        {

        }
    }
}
