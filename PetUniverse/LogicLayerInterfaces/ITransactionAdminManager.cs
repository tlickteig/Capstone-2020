using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/14
    /// Approver: Ethan Holmes
    /// 
    /// This class calls the data accessor functions.
    /// </summary>
    public interface ITransactionAdminManager
    {

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Interface for inserting a transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionType"></param>
        /// <returns>bool (success or failure)</returns>
        bool AddTransactionType(TransactionType transactionType);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Interface for inserting a transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionStatus"></param>
        /// <returns>bool (success or failure)</returns>
        bool AddTransactionStatus(TransactionStatus transactionStatus);

    }
}
