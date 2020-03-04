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
    /// Approver: Ethan Holmes
    /// </summary>
    public interface ITransactionAccessor
    {
        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 02/27/2020
        /// APPROVER: Hassan Karar
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
    }
}
