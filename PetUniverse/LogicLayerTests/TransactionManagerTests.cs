using System;
using LogicLayer;
using LogicLayerInterfaces;
using DataTransferObjects;
using DataAccessFakes;
using DataAccessInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{

    /// <summary>
    ///  Creator: Jaeho Kim
    ///  Created: 2/27/2020
    ///  Approver: Rasha Mohammed
    ///  
    ///  Test Class for TransactionManager
    /// </summary>
    [TestClass]
    public class TransactionManagerTests
    {

        private ITransactionAccessor _transactionAccessor;

        private TransactionManager _transactionManager;

        /// <summary>
        ///  Creator: Jaeho Kim
        ///  Created: 2/27/2020
        ///  Approver: Rasha Mohammed
        ///  
        ///  Constructor for instantiating FakeTransactionAccessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public TransactionManagerTests()
        {
            _transactionAccessor = new FakeTransactionAccessor();
        }

        /// <summary>
        /// NAME: Rasha Mohammed
        /// DATE: 2/26/2020
        /// CHECKED BY: Jaeho Kim
        /// 
        /// Load fake transcationLine accessor for testing purposes
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _transactionAccessor = new FakeTransactionAccessor();
            _transactionManager = new TransactionManager(_transactionAccessor);
        }

        /// <summary>
        ///  Creator: Jaeho Kim
        ///  Created: 2/27/2020
        ///  Approver: Rasha Mohammed
        ///  
        ///  Test method for retrieving all transactions
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllTransactions()
        {
            //arrange
            List<TransactionVM> transactions;
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            //act
            transactions = transactionManager.RetrieveAllTransactions();

            //assert
            Assert.AreEqual(2, transactions.Count);
        }

        /// <summary>
        ///  Creator: Jaeho Kim
        ///  Created: 3/05/2020
        ///  Approver: Rasha Mohammed
        ///  
        ///  Test method for retrieving all products using a transactionId
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllProductsByTransactionID()
        {
            // arrange 
            List<TransactionVM> products;
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);
            // Act
            products = transactionManager.RetrieveAllProductsByTransactionID(1000);
            // assert
            Assert.AreEqual(1, products.Count);
        }

        /// <summary>
        /// NAME: Rasha Mohammed
        /// DATE: 2/28/2020
        /// CHECKED BY: Jaeho Kim
        /// 
        /// Tests whether the transaction Manager is able to delete the item from transactionLine.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        [TestMethod]
        public void TestDeleteItemt()
        {
            // arrange
            string productID = "123abc456";
            bool result = false;

            // act
            result = _transactionManager.DeleteItem(productID);

            // assert
            Assert.AreEqual(true, result);

        }

        /// <summary>
        /// NAME: Jaeho Kim
        /// DATE: 4/4/2020
        /// 
        /// Tests AddTransaction
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void TestAddTransaction()
        {
            bool result = false;

            Transaction newTransaction = new Transaction()
            {
                EmployeeID = 100002
            };

            FakeTransactionAccessor _transactionAccessor = new FakeTransactionAccessor();

            result = _transactionAccessor.InsertTransaction(newTransaction) == 1;

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// NAME: Jaeho Kim
        /// DATE: 4/4/2020
        /// 
        /// Tests AddTransactionLineProducts
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void TestAddTransactionLineProducts()
        {
            bool result = false;

            TransactionLineProducts newTransactionLineProducts = new TransactionLineProducts()
            {
                TransactionID = 100002
            };

            FakeTransactionAccessor _transactionAccessor = new FakeTransactionAccessor();

            result = _transactionAccessor.InsertTransactionLineProducts(newTransactionLineProducts) == 1;

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/4/2020
        /// Approver: NA
        /// 
        /// This is a unit test for retrieve by zipcode only.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveLatestSalesTaxDateByZipCode()
        {
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            DateTime salesTaxDate = new DateTime(2002, 10, 18);
            SalesTax salesTax = new SalesTax()
            {
                TaxDate = salesTaxDate,
                TaxRate = 0.0025M,
                ZipCode = "1111"
            };

            DateTime anotherSalesTaxDate = transactionManager.RetrieveLatestSalesTaxDateByZipCode(salesTax.ZipCode);

            Assert.AreEqual(salesTax.TaxDate, anotherSalesTaxDate);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/4/2020
        /// Approver: NA
        /// 
        /// This is a unit test for retrieve by id.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveProductByProductID()
        {
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            string productID = "ProductID100";

            ProductVM anotherProductVM;

            anotherProductVM = transactionManager.RetrieveProductByProductID(productID);

            Assert.AreEqual(anotherProductVM.ProductID, productID);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/4/2020
        /// Approver: NA
        /// 
        /// This is a unit test for retrieve tax rate by date and zipcode.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveTaxRateBySalesTaxDateAndZipCode()
        {
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            DateTime salesTaxDate = new DateTime(2002, 10, 18);
            SalesTax salesTax = new SalesTax()
            {
                TaxDate = salesTaxDate,
                TaxRate = 0.0025M,
                ZipCode = "1111"
            };

            decimal anotherTaxRate = transactionManager
                .RetrieveTaxRateBySalesTaxDateAndZipCode(salesTax.ZipCode,salesTax.TaxDate);

            Assert.AreEqual(salesTax.TaxRate, anotherTaxRate);
        }

        /// <summary>
        ///  Creator: Jaeho Kim
        ///  Created: 3/05/2020
        ///  Approver: Rasha Mohammed
        ///  
        ///  Test method for retrieving transactions using a transaction date.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveTransactionsByTransactionDate()
        {
            // arrange 
            List<TransactionVM> transactions;
            DateTime transactionDate1 = new DateTime(2010, 10, 18);
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);
            // Act
            transactions = transactionManager.RetrieveTransactionByTransactionDate(transactionDate1);
            // assert
            Assert.AreEqual(1, transactions.Count);
        }

        /// <summary>
        ///  Creator: Jaeho Kim
        ///  Created: 3/08/2020
        ///  Approver: NA
        ///  
        ///  Test method for retreiving transactions by employee name.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveTransactionByEmployeeName()
        {
            //arrange
            List<TransactionVM> transactions;
            string firstName = "Bob";
            string lastName = "Jones";
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            // Act
            transactions = transactionManager.RetrieveTransactionByEmployeeName(firstName, lastName);

            // assert
            Assert.AreEqual(1, transactions.Count);


        }
    }
}
