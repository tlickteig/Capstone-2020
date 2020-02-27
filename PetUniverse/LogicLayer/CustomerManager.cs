using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Thomas Dupuy , 2020/02/21
    ///
    /// This Class manage Customer logic, and implements the 
    /// IHomeInspectorManager Interface
    /// </summary>
    public class CustomerManager : ICustomerManager
    {
        private ICustomerAccessor _customerAccessor;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy , 2020/02/19
        /// 
        /// This a constructor method for the Customer 
        /// Manager class.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public CustomerManager()
        {
            _customerAccessor = new CustomerAccessor();

        }
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy , 2020/02/19
        /// 
        /// This method is a constructor for the Customer 
        /// Manager.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="ICustomerAccessor"></param>
        /// <param name="customerAccessor"></param>
        /// <returns></returns>
        public CustomerManager(ICustomerAccessor customerAccessor)
        {
            _customerAccessor = customerAccessor;

        }
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy , 2020/02/19
        /// 
        /// This method gets a customer by the Customer  for the Customer 
        /// Manager.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="customerName"></param>
        /// <returns> a customer </returns>
        public Customer RetrieveCustomerByCustomerName(string customerName)
        {
            Customer customer = null;
            try
            {
                customer = _customerAccessor.RetrieveCustomerByCustomerName(customerName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("customer not Found", ex);
            }

            return customer;
        }
    }
}
