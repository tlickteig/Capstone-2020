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
        List<TransactionVM> SelectAllTransactionVMs();

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

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA 
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
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA 
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
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA 
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
        /// CREATOR: Jaeho Kim
        /// DATE: 04/04/2020
        /// APPROVER: NA 
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
        /// CREATOR: Jaeho Kim
        /// DATE: 03/08/2020
        /// APPROVER: NA 
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
