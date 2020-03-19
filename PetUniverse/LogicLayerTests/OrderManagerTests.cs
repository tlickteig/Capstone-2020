using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            OrderManager _orderManager = new OrderManager();

            result = _orderManager.RetrieveOrders().Any();

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

            OrderManager _orderManager = new OrderManager();

            result = _orderManager.EditOrder(oldOrder, editedOrder);

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
                OrderID = 1,
                EmployeeID = 346
            };

            OrderManager _orderManager = new OrderManager();

            result = _orderManager.AddOrder(newOrder);

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

            OrderManager _orderManager = new OrderManager();

            result = _orderManager.DeleteOrder(newOrder.OrderID);

            Assert.AreEqual(result, true);
        }
    }
}
