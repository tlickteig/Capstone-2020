using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Jesse Tomash
    /// Created: 3/12/2020
    /// Approver: Dalton Rierson
    /// 
    /// This is the interface for order accessor
    /// </summary>
    public interface IOrderAccessor
    {

        /// <summary>
        /// Creator: Jesse Tomash
        /// Created: 3/12/2020
        /// Approver: Dalton Rierson
        /// 
        /// This is the interface method for selecting all orders
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Update:
        /// Updated:
        /// </remarks>
        /// <returns></returns>
        IEnumerable<Order> SelectOrders();

        /// <summary>
        /// Creator: Jesse Tomash
        /// Created: 3/12/2020
        /// Approver: Dalton Rierson
        /// 
        /// This is the interface  method for updating an order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Update:
        /// Updated:
        /// </remarks>
        /// <param name="oldOrder"></param>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        int UpdateOrder(Order oldOrder, Order newOrder);

        /// <summary>
        /// Creator: Jesse Tomash
        /// Created: 3/12/2020
        /// Approver: Dalton Rierson
        /// 
        /// This is the interface method to insert an order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Update:
        /// Updated:
        /// </remarks>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        int InsertOrder(Order newOrder);

        /// <summary>
        /// Creator: Jesse Tomash
        /// Created: 3/12/2020
        /// Approver: Dalton Rierson
        /// 
        /// This is the interface method to delete an order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Update:
        /// Updated:
        /// </remarks>
        /// <param name="orderID"></param>
        /// <returns></returns>
        int DeleteOrder(int orderID);
    }
}