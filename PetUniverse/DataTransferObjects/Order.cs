using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 3/12/2020
    /// 
    /// This is the Order Data Transfer Object
    /// </summary>
    public class Order
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        /// 
        /// Unique order ID 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public int OrderID { get; set; }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        /// 
        /// Unique Employee ID
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public int EmployeeID { get; set; }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        /// 
        /// Active status of the order
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public bool Active { get; set; }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        /// 
        /// The constructor for an order, which generates an order ID
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
    }
}
