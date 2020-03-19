using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 3/12/2020
    /// 
    /// The Interface for the ordermanager Class
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    public interface IOrderManager
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        /// 
        /// The interface method for the method to retrieve all orders
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        IEnumerable<Order> RetrieveOrders();
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        /// 
        /// The interface method for the method to edit an order
        /// </summary>
        /// <param name="oldOrderInvoice"></param>
        /// <param name="newOrderInvoice"></param>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        bool EditOrder(Order oldOrderInvoice, Order newOrderInvoice);
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        /// 
        /// The interface method for the method to add an order
        /// </summary>
        /// <param name="newOrderInvoice"></param>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        bool AddOrder(Order newOrderInvoice);
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        /// 
        /// The interface method for the method for deleting an orderr by id
        /// </summary>
        /// <param name="orderInvoiceID"></param>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        bool DeleteOrder(int orderInvoiceID);
    }
}
