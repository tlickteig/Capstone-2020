using DataAccessFakes;
using DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicLayerTests
{

    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/13
    /// Approver: Rob Holmes
    /// Unit tests for sales tax.
    /// </summary>
    [TestClass]
    public class SalesTaxManagerTests
    {

        private FakeSalesTaxAccessor _fakeSalesTaxAccessor;

        // default constructor for fake data.
        public SalesTaxManagerTests()
        {
            _fakeSalesTaxAccessor = new FakeSalesTaxAccessor();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/13
        /// Approver: Rob Holmes
        ///
        /// Unit test for inserting sales tax.
        /// </summary>
        /// <remarks>
        /// Updater: Jaeho Kim
        /// Updated: 2020/04/14
        /// Update: Previous test was testing was failing 
        /// when ran twice. Fixed the issue.
        /// </remarks>
        [TestMethod]
        public void TestSalesTaxManagerInsertSalesTax()
        {
            // arrange
            DateTime salesTaxDate = new DateTime(2017, 11, 12);
            var salesTax = new SalesTax()
            {
                TaxDate = salesTaxDate,
                TaxRate = 0.05M,
                ZipCode = "FAKE"
            };

            // act
            FakeSalesTaxAccessor _salesTaxAccessor = new FakeSalesTaxAccessor();
            bool result = _salesTaxAccessor.InsertSalesTax(salesTax) == 1;

            // assert
            Assert.AreEqual(result, true);
        }
    }
}
