using DataAccessFakes;
using DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{

    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/14
    /// Approver: Ethan Holmes
    ///  
    /// Unit testing Class for Transaction Admin
    /// </summary>
    [TestClass]
    public class TransactionAdminTests
    {

        private FakeTransactionAdminAccessor _fakeTransactionAdminAccessor;

        public TransactionAdminTests()
        {
            _fakeTransactionAdminAccessor = new FakeTransactionAdminAccessor();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Tests AddTransactionType
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestTransactionAdminManagerInsertTransactionType()
        {
            // arrange
            var transactionType = new TransactionType()
            {
                TransactionTypeID = "FakeTransactionTypeID",
                Description = "FakeDescTransactionType",
                DefaultInStore = false
            };
            FakeTransactionAdminAccessor _transactionAdminAccessor = new FakeTransactionAdminAccessor();

            // act
            bool result = _transactionAdminAccessor.InsertTransactionType(transactionType) == 1;

            // assert
            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Tests AddTransactionStatus
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestTransactionAdminManagerInsertTransactionStatus()
        {
            // arrange
            var transactionStatus = new TransactionStatus()
            {
                TransactionStatusID = "FakeTransactionStatusID1000",
                Description = "FakeDescTransactionStatus10000",
                DefaultInStore = false
            };
            FakeTransactionAdminAccessor _transactionAdminAccessor = new FakeTransactionAdminAccessor();

            // act
            bool result = _transactionAdminAccessor.InsertTransactionStatus(transactionStatus) == 1;

            // assert
            Assert.AreEqual(result, true);
        }
    }
}
