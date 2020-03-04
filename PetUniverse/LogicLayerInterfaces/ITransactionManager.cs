using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{

    /// <summary>
    /// NAME: Jaeho Kim
    /// DATE: 2/27/2020
    ///  Approver: Ethan Holmes
    /// Interface outlines the requirements for the Transaction Manager class.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATE DATE: N/A
    /// CHANGE DESCRIPTION: N/A
    /// </remarks>
    public interface ITransactionManager
    {
        /// <summary>
		///  Creator: Jaeho Kim
		///  Created: 2/27/2020
        ///  Approver: Ethan Holmes
        ///  
        ///  Interface method for retrieving all transactions
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        List<TransactionVM> RetrieveAllTransactions();
    }
}
