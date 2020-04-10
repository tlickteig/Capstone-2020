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
    /// 
    /// Interface for the transaction accessor
    /// </summary>
    public interface ITransactionAccessor
    {

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 02/27/2020
        /// Approver: Rasha Mohammed
        ///
        /// Interface method signature for Selecting all Transactions
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns List of Transactions</returns>
        List<TransactionVM> SelectAllTransactionVMs();

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/03/2020
        /// Approver: Rasha Mohammed
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
        /// Creator: Jaeho Kim
        /// Created: 03/05/2020
        /// Approver: Rasha Mohammed
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
        /// Creator: Rasha Mohammed
        /// Created: 2/14/2020
        /// Approver: Jaeho Kim
        /// 
        /// The method is used to delete the products on the transactionLine by selecting the product ID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        int DeleteItemFromTransaction(string productID);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/19/2020
        /// Approver: NA 
        ///
        /// Interface method signature for inserting a transaction.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>rows affected</returns>
        int InsertTransaction(Transaction transaction);

        int InsertTransactionLineProducts(TransactionLineProducts transactionLineProducts);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/19/2020
        /// Approver: NA 
        ///
        /// Interface method signature for selecting the exact latest sales tax date of the zipcode entered.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>DateTime</returns>
        DateTime SelectLatestSalesTaxDateByZipCode(string zipCode);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/19/2020
        /// Approver: NA 
        ///
        /// Interface method signature for selecting the sales tax rate of the zipcode entered, 
        /// and the exact date entered.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>TaxRate</returns>
        decimal SelectTaxRateBySalesTaxDateAndZipCode(string zipCode, DateTime salesTaxDate);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/19/2020
        /// Approver: NA 
        ///
        /// Interface method signature for selecting the product by product id. 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>ProductVM</returns>
        ProductVM SelectProductByProductID(string productID);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/19/2020
        /// Approver: NA 
        ///
        /// Interface method signature for Selecting transactions using a Employee Name.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns a list of transactions</returns>
        List<TransactionVM> SelectTransactionsByEmployeeName(string firstName, string lastName);
    }
}