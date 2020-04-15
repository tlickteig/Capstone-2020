using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{

    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/14
    /// Approver: Ethan Holmes
    /// Implementation of the transaction admin manager.
    /// </summary>
    public class TransactionAdminManager : ITransactionAdminManager
    {

        ITransactionAdminAccessor _transactionAdminAccessor;

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        ///
        /// Default constructor for transaction admin.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public TransactionAdminManager()
        {
            _transactionAdminAccessor = new TransactionAdminAccessor();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        ///
        /// Default constructor for transaction admin. Used for
        /// unit testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionAdminAccessor"></param>
        public TransactionAdminManager(ITransactionAdminAccessor transactionAdminAccessor)
        {
            _transactionAdminAccessor = new TransactionAdminAccessor();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        ///
        /// Interface implementation for inserting transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionStatus"></param>
        /// <returns>returns if success or failure</returns>
        public bool AddTransactionStatus(TransactionStatus transactionStatus)
        {
            try
            {
                return 1 == _transactionAdminAccessor.InsertTransactionStatus(transactionStatus);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not added.", ex);
            }
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        ///
        /// Interface implementation for inserting transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionType"></param>
        /// <returns>returns if success or failure</returns>
        public bool AddTransactionType(TransactionType transactionType)
        {
            try
            {
                return 1 == _transactionAdminAccessor.InsertTransactionType(transactionType);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not added.", ex);
            }
        }
    }
}
