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
    /// Approver: Brandyn T. Coverdill
    /// Approver: Dalton Reierson
    /// 
    /// This is the Order Data Transfer Object
    /// </summary>
    public class Order
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
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
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
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
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
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
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
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
