using DataAccessFakes;
using DataAccessInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
    [TestClass]
    public class PoSCustomerPortalTests
    {

        private IPoSCustomerPortalAccessor _fakePoSCustomerPortalAccessor;

        public PoSCustomerPortalTests()
        {

            _fakePoSCustomerPortalAccessor = new FakePoSCustomerPortalAccessor();


        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// Test for Report Shipping error.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TestReportShippingError()
        {

            int result = _fakePoSCustomerPortalAccessor.ReportShippingError("FakeErrorType", "FakeErrorDesc");
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// Test for adding a credit card.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TestAddCreditCard()
        {
            int result = _fakePoSCustomerPortalAccessor.AddCreditCard("Visa", "1234 5555 JJFF KFD2", "444");
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// Test for remove a credit card.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TestRemoveCreditCard()
        {
            int result = _fakePoSCustomerPortalAccessor.DeleteCreditCard("1234 5555 JJFF KFD2");
            Assert.AreEqual(1, result);
        }


        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// Test cleanup
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _fakePoSCustomerPortalAccessor = null;

        }

    }
}
