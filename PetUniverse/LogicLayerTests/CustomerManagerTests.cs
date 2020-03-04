using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayerInterfaces;
using LogicLayerTests;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Thomas Dupuy , 2020/02/21
    ///
    /// This Class for testing all public methods int the Customer Manager class.
    ///
    /// </summary>
    [TestClass]
   public class CustomerManagerTests
    {
        private ICustomerAccessor _fakeCustomerAccessor;
        private CustomerManager _customerManager;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy ,2020/02/21
        /// 
        /// This is the Setup for tests.
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
        [TestInitialize]
        public void TestSetup()
        {
            _fakeCustomerAccessor = new FakeCustomerAccessor();
            _customerManager = new CustomerManager(_fakeCustomerAccessor);
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy
        /// 
        /// This is the test for SelectAdoptionApplicationByStatus method.
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
        [TestMethod]
        public void TestRetrieveCustomerByCustomerName()
        {
            // arrange
            Customer selectedCustomers = null;
            const string customerName = "Elamin";
            int result = 0;

            // act
            selectedCustomers = _customerManager.RetrieveCustomerByCustomerName(customerName);
            if (selectedCustomers != null)
            {
                result = 1;
            }
            // assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy , 2020/02/21
        /// 
        /// This method for clean up after the test is finshed.
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
        [TestCleanup]
        public void TestTearDown()
        {
            _fakeCustomerAccessor = null;
        }
    }
}
