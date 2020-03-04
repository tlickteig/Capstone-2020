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
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy , 2020/02/21
        /// 
        /// This method for getting Customer by thier name, and 
        /// return a list of the Adoption Applications.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="customerName"></param>     
        /// <returns>Customer</returns>

        Customer RetrieveCustomerByCustomerName(string customerName);
   }
}
