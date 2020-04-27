using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Dalton Reierson
    /// Created: 2020/04/24
    /// Approver: Jesse Tomash
    /// Approver: 
    ///
    /// fake data access layer for order line
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class FakeOrderLineAccessor : IOrderLineAccessor
    {

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// fake for selecting order line by receiving record id
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<OrderLine> SelectOrderLineByReceivingRecordID(int ReceivingRecordID)
        {
            List<OrderLine> orderLines = new List<OrderLine>();

            OrderLine orderLine = new OrderLine();

            orderLine.OrderLineID = 100000;
            orderLine.ReceivingRecordID = 100000;
            orderLine.ItemID = 100000;
            orderLine.MissingItemQuantity = 10;
            orderLine.DamagedItemQuantity = 10;
            orderLines.Add(orderLine);

            orderLine.OrderLineID = 100001;
            orderLine.ReceivingRecordID = 100000;
            orderLine.ItemID = 100001;
            orderLine.MissingItemQuantity = 11;
            orderLine.DamagedItemQuantity = 11;
            orderLines.Add(orderLine);

            return orderLines;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// fake for updating order line
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int UpdateOrderLine(OrderLine oldOrderLine, OrderLine newOrderLine)
        {
            return 1;
        }

    }
}
