using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 3/30/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// Approver: 
    /// 
    /// This is the interface for order accessor
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    public interface ISpecialOrderAccessor
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the interface method for selecting all orders
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        IEnumerable<SpecialOrder> SelectSpecialOrders();
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the interface  method for updating an order
        /// </summary>
        /// <param name="oldOrder"></param>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        int UpdateSpecialOrder(SpecialOrder oldOrder, SpecialOrder newOrder);
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the interface method to insert an order
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        int InsertSpecialOrder(SpecialOrder newOrder);
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the interface method to delete an order
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        int DeleteSpecialOrder(int orderID);
    }
}
