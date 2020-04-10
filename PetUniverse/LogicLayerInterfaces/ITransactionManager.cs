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
    ///  Approver: Rasha Mohammed
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
        ///  Approver: Rasha Mohammed
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

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/03/2020
        /// APPROVER: Rasha Mohammed
        ///
        /// Interface method signature for Selecting all products with a TransactionID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns a Transaction</returns>
        List<TransactionVM> RetrieveAllProductsByTransactionID(int transactionID);

        /// <summary>
        /// NAME: Rasha Mohammed
        /// DATE: 2/25/2020
        /// CHECKED BY: Jaeho Kim
        /// 
        /// Interface to delete product from transactionLine when the productID selected.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        bool DeleteItem(string productID);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/17/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for Selecting a product with Product UPC.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns a Transaction</returns>
        ProductVM RetrieveProductByProductID(string productID);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for adding a transaction using transactionID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns a Transaction</returns>
        bool AddTransaction(Transaction transaction);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for adding products to a transaction.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns a Transaction</returns>
        bool AddTransactionLineProducts(TransactionLineProducts transactionLineProducts);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for adding a product to 
        /// a list of every products. This method adds every 
        /// product to the list whether the product is 
        /// taxable or not.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>void</returns>
        void AddProduct(ProductVM productVM);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for adding a taxable product 
        /// to a list of taxable products only.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>void</returns>
        void AddProductTaxable(ProductVM productVM);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for getting a list
        /// of every products (taxable or not).
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>List of all products</returns>
        List<ProductVM> GetAllProducts();

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for getting a list
        /// of taxable products only.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>List of all products</returns>
        List<ProductVM> GetTaxableProducts();

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for getting an 
        /// IEnumerable of every products (taxable or 
        /// not).
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>IEnumerable of All Products</returns>
        IEnumerable<ProductVM> EnumerableAllProducts();

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for getting an 
        /// IEnumerable of every taxable products.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>IEnumerable of Taxable Products</returns>
        IEnumerable<ProductVM> EnumerableTaxableProducts();

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for getting 
        /// the latest sales tax date of the zip code.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>DateTime</returns>
        DateTime RetrieveLatestSalesTaxDateByZipCode(string zipCode);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for getting 
        /// the tax rate of the zip code, of the 
        /// latest sales tax date.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>sales tax rate</returns>
        decimal RetrieveTaxRateBySalesTaxDateAndZipCode(string zipCode, DateTime salesTaxDate);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for calculating 
        /// the sub total of all of the products.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>SubTotal</returns>
        decimal CalculateSubTotal(List<ProductVM> AllProductsList);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for calculating 
        /// the sub total of the taxable products.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>SubTotalTaxable</returns>
        decimal CalculateSubTotalTaxable(List<ProductVM> TaxableProductList);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/22/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for calculating the 
        /// total of the products. One param Takes the 
        /// subTotal, which represents the cost of all products. 
        /// Another param takes the subTotalTaxable, which 
        /// represents only the cost of taxable products. 
        /// This number is used to calculate the tax.
        /// The final param represents the salesTax object. 
        /// Only the taxRate is actually used for calculation.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>Total</returns>
        decimal CalculateTotal(decimal subTotal, decimal subTotalTaxable, SalesTax salesTax);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/22/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for validating the
        /// item quantity.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>bool</returns>
        bool isItemQuantityValid(List<ProductVM> shoppingCart, ProductVM productVM);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 04/04/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for clearing the shopping cart.
        /// item quantity.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>bool</returns>
        void ClearShoppingCart();

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/07/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for Selecting all Transactions with a TransactionDate.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns a Transaction</returns>
        List<TransactionVM> RetrieveTransactionByTransactionDate(DateTime transactionDate);

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/08/2020
        /// APPROVER: NA
        ///
        /// Interface method signature for Selecting all Transactions with a Employee Name.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns a Transaction</returns>
        List<TransactionVM> RetrieveTransactionByEmployeeName(string firstName, string lastName);
    }
}
