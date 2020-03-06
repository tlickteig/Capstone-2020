using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 02/27/2020
    /// Approver: Rasha Mohammed
    /// </summary>
    public interface ITransactionAccessor
    {
        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 02/27/2020
        /// APPROVER: Rasha Mohammed
        ///
        /// Interface method signature for Selecting all Transactions
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns List of Transactions</returns>
        List<TransactionVM> SelectAllTransactions();

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/03/2020
        /// APPROVER: Rasha Mohammed
        ///
        /// Interface method signature for Selecting all products using a TransactionID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns a list of transactions</returns>
        List<TransactionVM> SelectAllProductsByTransactionID(int transactionID);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/05/2020
        /// APPROVER: NA 
        ///
        /// Interface method signature for Selecting transactions using a Transaction DateTime.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns a list of transactions</returns>
        List<TransactionVM> SelectTransactionsByTransactionDate(DateTime transactionDate);

        /// <summary>
        /// NAME: Rasha Mohammed
        /// DATE: 2/14/2020
        /// CHECKED BY: Jaeho Kim
        /// 
        /// The method is used to delete the products on the transactionLine by selecting the product ID.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        int DeleteItemFromTransaction(string productID);

    }
}
