using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessFakes;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 2/7/2020
    /// 
    /// This is the Test class for OrderManager
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    [TestClass]
    public class OrderManagerTests
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        /// 
        /// Tests RetrieveOrders
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void RetrieveOrderTest()
        {
            bool result = false;

            FakeOrderAccessor _orderAccessor = new FakeOrderAccessor();

            result = _orderAccessor.SelectOrders().Any();

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        /// 
        /// Tests EditORder
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void EditOrderTest()
        {
            bool result = false;

            Order oldOrder = new Order()
            {
                OrderID = 1,
                EmployeeID = 532
            };

            Order editedOrder = new Order()
            {
                OrderID = 1,
                EmployeeID = 557
            };

            FakeOrderAccessor _orderAccessor = new FakeOrderAccessor();

            result = _orderAccessor.UpdateOrder(oldOrder, editedOrder) == 1;

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        /// 
        /// Tests AddOrder
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void AddOrderTest()
        {
            bool result = false;

            Order newOrder = new Order()
            {
                EmployeeID = 346
            };

            FakeOrderAccessor _orderAccessor = new FakeOrderAccessor();

            result = _orderAccessor.InsertOrder(newOrder) == 1;

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        /// 
        /// Tests DeleteOrder
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void DeleteOrderTest()
        {
            bool result = false;

            Order newOrder = new Order()
            {
                OrderID = 1,
                EmployeeID = 3462
            };

            FakeOrderAccessor _orderAccessor = new FakeOrderAccessor();

            result = _orderAccessor.DeleteOrder(newOrder.OrderID) == 1;

            Assert.AreEqual(result, true);
        }
    }
}
