using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/14
    /// Approver: Ethan Holmes
    /// 
    /// Interfaces for Transaction Admin.
    /// </summary>
    public interface ITransactionAdminAccessor
    {
        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// APPROVER: Ethan Holmes
        ///
        /// Interface method signature for inserting transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionType"></param>
        /// <returns>rows effected</returns>
        int InsertTransactionType(TransactionType transactionType);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// APPROVER: Ethan Holmes
        ///
        /// Interface method signature for inserting transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionStatus"></param>
        /// <returns>rows effected</returns>
        int InsertTransactionStatus(TransactionStatus transactionStatus);
    }
}
