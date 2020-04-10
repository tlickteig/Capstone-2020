using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 3/30/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// Approver: 
    /// 
    /// This is the Test class for OrderManager
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    [TestClass]
    public class SpecialOrderManagerTests
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
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

            FakeSpecialOrderAccessor _specialOrderAccessor = new FakeSpecialOrderAccessor();

            result = _specialOrderAccessor.SelectSpecialOrders().Any();

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
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

            SpecialOrder oldOrder = new SpecialOrder()
            {
                SpecialOrderID = 1,
                SpecialOrderEmployeeID = 532
            };

            SpecialOrder editedOrder = new SpecialOrder()
            {
                SpecialOrderID = 1,
                SpecialOrderEmployeeID = 557
            };

            FakeSpecialOrderAccessor _SpecialOrderAccessor = new FakeSpecialOrderAccessor();

            result = _SpecialOrderAccessor.UpdateSpecialOrder(oldOrder, editedOrder) == 1;

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Tests AddOrder
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void AddSpecialOrderTest()
        {
            bool result = false;

            SpecialOrder newOrder = new SpecialOrder()
            {
                SpecialOrderEmployeeID = 346
            };

            FakeSpecialOrderAccessor _SpecialOrderAccessor = new FakeSpecialOrderAccessor();

            result = _SpecialOrderAccessor.InsertSpecialOrder(newOrder) == 1;

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Tests DeleteOrder
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void DeleteSpecialOrderTest()
        {
            bool result = false;

            SpecialOrder newOrder = new SpecialOrder()
            {
                SpecialOrderID = 1,
                SpecialOrderEmployeeID = 3462
            };

            FakeSpecialOrderAccessor _specialOrderAccessor = new FakeSpecialOrderAccessor();

            result = _specialOrderAccessor.DeleteSpecialOrder(newOrder.SpecialOrderID) == 1;

            Assert.AreEqual(result, true);
        }
    }
}
