using DataAccessInterfaces;
using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020-04-14
    /// Approver: Ethan Holmes
    ///
    /// Data access fakes for transaction admin.
    /// </summary>
    public class FakeTransactionAdminAccessor : ITransactionAdminAccessor
    {

        private List<TransactionType> _transactionTypes;
        private List<TransactionStatus> _transactionStatuses;

        public FakeTransactionAdminAccessor()
        {
            _transactionTypes = new List<TransactionType>()
            {
                new TransactionType()
                {
                    TransactionTypeID = "FAKEID1",
                    Description = "FakeDesc1",
                    DefaultInStore = true
                },
                new TransactionType()
                {
                    TransactionTypeID = "FAKEID2",
                    Description = "FakeDesc2",
                    DefaultInStore = false
                }
            };

            _transactionStatuses = new List<TransactionStatus>()
            {
                new TransactionStatus()
                {
                    TransactionStatusID = "FAKESTATUSID1",
                    Description = "FakeDesc1",
                    DefaultInStore = true
                },
                new TransactionStatus()
                {
                    TransactionStatusID = "FAKESTATUSID2",
                    Description = "FakeDesc2",
                    DefaultInStore = false
                }
            };
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Fake Insert Transaction STATUS.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionStatus"></param>
        public int InsertTransactionStatus(TransactionStatus transactionStatus)
        {
            int result = 0;
            FakeTransactionAdminAccessor fakeTransactionAdminAccessor = new FakeTransactionAdminAccessor();
            List<TransactionStatus> transactionStatuses = _transactionStatuses;

            if (!transactionStatuses.Contains(transactionStatus))
            {
                transactionStatuses.Add(transactionStatus);
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Fake Insert Transaction TYPE.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionType"></param>
        public int InsertTransactionType(TransactionType transactionType)
        {
            int result = 0;
            FakeTransactionAdminAccessor fakeTransactionAdminAccessor = new FakeTransactionAdminAccessor();
            List<TransactionType> transactionTypes = _transactionTypes;

            if (!transactionTypes.Contains(transactionType))
            {
                transactionTypes.Add(transactionType);
                result = 1;
            }
            return result;
        }
    }
}
