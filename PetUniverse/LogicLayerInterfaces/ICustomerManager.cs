using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterfaces;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Thomas Dupuy , 2020/02/21
    ///
    /// This Interface that defines methods for Customer 
    /// </summary>
    public interface ICustomerManager
   {
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 2020/29/2020
        /// Approved By: 
        /// 
        /// This method for getting Customer by email, 
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="customerEmail"></param>     
        /// <returns>Customer</returns>

        Customer RetrieveCustomerByCustomerEmail(string customerEmail);
    }
}
