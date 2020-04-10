using System;
using DataTransferObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 02/19/2020
    /// Approver: Thomas Dupuy, 02/21/2020
    ///
    /// This interface for accessing Customer data.
    /// </summary>
    public interface ICustomerAccessor
    {

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 02/19/2020
        /// Approver: Thomas Dupuy, 02/21/2020
        /// 
        /// This method gets a customer by the Customer Email. 
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="customerName"></param>
        /// <returns> a customer </returns>
        /// 
        Customer RetrieveCustomerByCustomerEmail(string customerEmail);
    }
}