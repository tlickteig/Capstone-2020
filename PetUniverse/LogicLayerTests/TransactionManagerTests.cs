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
    ///  Approver: Ethan Holmes
    ///  
    ///  Test Class for TransactionManager
    /// </summary>
    [TestClass]
    public class TransactionManagerTests
    {

        private ITransactionAccessor _transactionAccessor;

        /// <summary>
        ///  Creator: Jaeho Kim
        ///  Created: 2/27/2020
        ///  Approver: Ethan Holmes
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
        ///  Creator: Jaeho Kim
        ///  Created: 2/27/2020
        ///  Approver: Ethan Holmes
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
    }
}
