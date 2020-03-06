using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    /// <summary>
    /// CREATOR: Jaeho Kim
    /// CREATED: 02/27/2020
    /// APPROVER: Rasha Mohammed
    /// 
    /// Fake Transaction Accessor Class for Unit Testing
    /// </summary>
    public class FakeTransactionAccessor : ITransactionAccessor
    {
        private List<TransactionVM> _transactions;

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2/27/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This fake method is called to get a fake Transaction Accessor
        /// </summary>
        /// <remarks>
        /// Updater: Jaeho Kim
        /// Updated: 2020/03/05
        /// Update: Implemented the Select All Products by Transaction ID.
        /// 
        /// </remarks>
        /// <returns>Fake TransactionAccessor</returns>
        public FakeTransactionAccessor()
        {
            _transactions = new List<TransactionVM>()
            {
                new TransactionVM()
                {
                    TransactionID = 1000,
                    TransactionDate = DateTime.Now,
                    UserID = 100000,
                    FirstName = "Bob",
                    LastName = "Jones",
                    TransactionTypeID = "FAKE_TYPE_1",
                    TransactionStatusID = "FAKE_STATUS_1"
                },
                new TransactionVM()
                {
                    TransactionID = 1001,
                    TransactionDate = DateTime.Now,
                    UserID = 100001,
                    FirstName = "Shawn",
                    LastName = "Gunner",
                    TransactionTypeID = "FAKE_TYPE_2",
                    TransactionStatusID = "FAKE_STATUS_2"
                }
            };
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// CREATED: 3/05/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<TransactionVM> SelectAllProductsByTransactionID(int transactionID)
        {
            return (from v in _transactions
                    where v.TransactionID == 1000
                    select v).ToList();
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// CREATED: 2/27/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: Jaeho Kim
        /// UPDATED: 2020/03/03
        /// UPDATE: Added missing properties from the data transfer object.
        /// 
        /// </remarks>
        public List<TransactionVM> SelectAllTransactions()
        {
            return _transactions;
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// CREATED: 3/05/2020
        /// APPROVER: NA
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<TransactionVM> SelectTransactionsByTransactionDate(DateTime transactionDate)
        {
            throw new NotImplementedException();
        }
    }
}
