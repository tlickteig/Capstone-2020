using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessLayer;
using DataAccessInterfaces;

namespace LogicLayer
{

    /// <summary>
    ///  Creator: Jaeho Kim
    ///  Created: 2/27/2020
    ///  Approver: Ethan Holmes
    ///  
    ///  Manager Class for Transactions
    /// </summary>
    public class TransactionManager : ITransactionManager
    {
        private ITransactionAccessor _transactionAccessor;

        /// <summary>
		///  Creator: Jaeho Kim
		///  Created: 2/27/2020
		///  Approver: Ethan Holmes
		///  
		///  Default Constructor for instantiating Accessor
		/// </summary>
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// 
		/// </remarks>
		public TransactionManager()
        {
            _transactionAccessor = new TransactionAccessor();
        }

        /// <summary>
        ///  Creator: Jaeho Kim
        ///  Created: 2/26/2020
        ///  Approver: Ethan Holmes
        ///  
        ///  Constructor for passing specific Accessor class
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="transactionAccessor"></param>

        public TransactionManager(ITransactionAccessor transactionAccessor)
        {
            _transactionAccessor = transactionAccessor;
        }


        /// <summary>
		///  Creator: Jaeho Kim
		///  Created: 2/27/2020
		///  Approver: Ethan Holmes
		///  
		///  This method calls the Select all transactions method in the DataAccessLayer.
		/// </summary>
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// 
		/// </remarks>
        public List<TransactionVM> RetrieveAllTransactions()
        {
            try
            {
                return _transactionAccessor.SelectAllTransactions();
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Transactions Not Found",ex);
            }
        }
    }
}
