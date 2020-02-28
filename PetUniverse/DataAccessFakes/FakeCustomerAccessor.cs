using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;
using DataAccessFakes;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver:Thomas Dupuy ,2020/02/21
    ///
    /// This Class for creating a fake Customer data which will used 
    /// for testing Logic layer public methodes.
    /// </summary>
    public class FakeCustomerAccessor : ICustomerAccessor
    {
        private List<Customer> customers = null;
        private Customer customer = new Customer();

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy ,2020/02/21
        /// 
        /// This method will get fake Customer when whene it called. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <returns>Fack customers</returns>
        public FakeCustomerAccessor()
        {
            customers = new List<Customer>()
            {
                new Customer()
                {
                UserID = 10009,
                FirstName = "John",
                LastName = "Elamin",
                PhoneNumber = "3192098622",
                Email = "john@hotmail.com",
                AddressLineOne = "12 us street SW",
                AddressLineTwo = "Apt2",
                ZipCode = "53987",
                State = "NY",
                City = "london",
                Active = true
                },

            new Customer()
            {
                UserID = 10008,
                FirstName = "Ali",
                LastName = "Ahmed",
                PhoneNumber = "3193762955",
                Email = "ali@hotmail.com",
                AddressLineOne = "12 kirkwood street SW",
                AddressLineTwo = "Apt1",
                ZipCode = "52487",
                State = "IA",
                City = "cedar rapids",
                Active = true
            },
            new Customer()
            {
                UserID = 10007,
                FirstName = "Zaic",
                LastName = "kamal",
                PhoneNumber = "9299556722",
                Email = "zaic@hotmail.com",
                AddressLineOne = "12 k street SW",
                AddressLineTwo = "Apt4",
                ZipCode = "50987",
                State = "IA",
                City = "cedar rapids",
                Active = true
            },
        };
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy ,2020/02/21
        /// 
        /// This fake method is called to get a fake Customer which has the same 
        /// passed last name. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="customerName"></param>
        /// <returns>fake customer</returns>
        public Customer RetrieveCustomerByCustomerName(string customerName)
        {
            Customer _customer = new Customer();
            foreach (var customer in customers)
            {
                if (customer.LastName == customerName)
                {
                    _customer = customer;
                    break;
                }
            }
            return _customer;
        }
    }
}
