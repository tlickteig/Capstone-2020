using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Dalton Reierson
    /// Created: 2020/04/24
    /// Approver: Jesse Tomash
    /// Approver: 
    ///
    /// Interface for orderLine accessor
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public interface IOrderLineAccessor
    {
        List<OrderLine> SelectOrderLineByReceivingRecordID(int ReceivingRecordID);
        int UpdateOrderLine(OrderLine oldOrderLine, OrderLine newOrderLine);
    }
}
