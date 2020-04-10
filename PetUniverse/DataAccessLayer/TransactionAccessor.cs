using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessLayer
{

    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2/27/2020
    /// Approver: Rasha Mohammed
    /// 
    /// This is a DataAccess class for TSQL it implements the ITransactionAccessor
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class TransactionAccessor : ITransactionAccessor
    {

        int TransactionID = 0;

        /// <summary>
        /// NAME: Rasha Mohammed
        /// DATE: 2/21/2020
        /// CHECKED BY: Jaeho Kim
        /// 
        /// Queries the SQL database for a delete item from trnsactionLine when that match the productID  .
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public int DeleteItemFromTransaction(string productID)
        {
            int rows = 0;

            string cmdText = "sp_delete_Item_from_Transaction";


            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductID", productID);


            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Implementation for selecting a product by the product upc (productID).
        /// This is part of the search function for populating a ProductVM details 
        /// using the product upc.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>ProductVM</returns>
        public ProductVM SelectProductByProductID(string productID)
        {
            var product = new ProductVM();
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_product_by_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", productID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    product.ProductID = reader.GetString(0);
                    product.Name = reader.GetString(1);
                    product.Taxable = reader.GetBoolean(2);
                    product.Price = reader.GetDecimal(3);
                    product.QuantityInStock = reader.GetInt32(4);
                    product.ItemDescription = reader.GetString(5);
                    product.Active = reader.GetBoolean(6);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return product;
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Implementation for inserting a transaction.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>rows affected</returns>
        public int InsertTransaction(Transaction transaction)
        {
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_transaction", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TransactionDateTime", transaction.TransactionDateTime);
            cmd.Parameters.AddWithValue("@TaxRate", transaction.TaxRate);
            cmd.Parameters.AddWithValue("@SubTotalTaxable", transaction.SubTotalTaxable);
            cmd.Parameters.AddWithValue("@SubTotal", transaction.SubTotal);
            cmd.Parameters.AddWithValue("@Total", transaction.Total);
            cmd.Parameters.AddWithValue("@TransactionTypeID", transaction.TransactionTypeID);
            cmd.Parameters.AddWithValue("@EmployeeID", transaction.EmployeeID);
            cmd.Parameters.AddWithValue("@TransactionStatusID", transaction.TransactionStatusID);
            cmd.Parameters.AddWithValue("@ReturnTransactionId", 0);



            try
            {
                conn.Open();
                TransactionID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return TransactionID;
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 04/04/2020
        /// APPROVER: NA
        ///
        /// Implementation for inserting a products related to the transaction.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>rows affected</returns>
        public int InsertTransactionLineProducts(TransactionLineProducts transactionLineProducts)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_transaction_line_products", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                conn.Open();

                foreach (var item in transactionLineProducts.ProductsSold)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@TransactionID", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@PriceSold", SqlDbType.Decimal));

                    cmd.Parameters[0].Value = TransactionID;
                    cmd.Parameters[1].Value = item.ProductID;
                    cmd.Parameters[2].Value = item.Quantity;
                    cmd.Parameters[3].Value = item.Price;
                    rows = cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }


        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/05/2020
        /// APPROVER: Rasha Mohammed
        ///
        /// Implementation for Selecting all products using a TransactionID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns a list of transactions</returns>
        public List<TransactionVM> SelectAllProductsByTransactionID(int transactionID)
        {
            List<TransactionVM> products = new List<TransactionVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_products_by_transaction_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("TransactionID", transactionID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransactionVM transactionVM = new TransactionVM();

                    transactionVM.Quantity = reader.GetInt32(0);
                    transactionVM.ProductID = reader.GetString(1);
                    transactionVM.ProductName = reader.GetString(2);
                    transactionVM.ProductCategoryID = reader.GetString(3);
                    transactionVM.ProductTypeID = reader.GetString(4);
                    transactionVM.Description = reader.GetString(5);
                    transactionVM.Brand = reader.GetString(6);
                    transactionVM.Price = reader.GetDecimal(7);

                    products.Add(transactionVM);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return products;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2/27/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This is a method for selecting all Transactions from the tsql database.
        /// </summary>
        /// <remarks>
        /// Updater: Jaeho Kim
        /// Updated: 2020/03/03
        /// Update: Fixed the issue with a stored procedure.
        /// 
        /// </remarks>
        public List<TransactionVM> SelectAllTransactionVMs()
        {
            List<TransactionVM> transactions = new List<TransactionVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_transactions", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TransactionVM transactionVM = new TransactionVM();

                        transactionVM.TransactionID = reader.GetInt32(0);
                        transactionVM.TransactionDate = reader.GetDateTime(1);
                        transactionVM.UserID = reader.GetInt32(2);
                        transactionVM.FirstName = reader.GetString(3);
                        transactionVM.LastName = reader.GetString(4);
                        transactionVM.TransactionTypeID = reader.GetString(5);
                        transactionVM.TransactionStatusID = reader.GetString(6);

                        transactions.Add(transactionVM);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return transactions;
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Implementation for selecting the SalesTax by zipCode.
        /// This function retrieves the exact date of the latest 
        /// salesTaxDate of the ZipCode. The tax rate is NOT 
        /// included.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>DateTime</returns>
        public DateTime SelectLatestSalesTaxDateByZipCode(string zipCode)
        {
            DateTime salesTaxDate = DateTime.Now;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_latest_salesTaxDate_by_zipCode", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ZipCode", zipCode);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        salesTaxDate = reader.GetDateTime(0);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return salesTaxDate;
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/19/2020
        /// APPROVER: NA
        ///
        /// Implementation for selecting the Sales Tax Rate by zipCode 
        /// and salesTaxDate.
        /// This function retrieves the sales tax rate of the latest 
        /// salesTaxDate of the ZipCode.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>TaxRate</returns>
        public decimal SelectTaxRateBySalesTaxDateAndZipCode(string zipCode, DateTime salesTaxDate)
        {
            decimal taxRate = 0.0M;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_taxRate_by_salesTaxDate_and_zipCode", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ZipCode", zipCode);
            cmd.Parameters.AddWithValue("@SalesTaxDate", salesTaxDate);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        taxRate = reader.GetDecimal(0);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return taxRate;
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/05/2020
        /// APPROVER: NA
        ///
        /// Implementation for Selecting all transactions using a TransactionDate.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns a list of transactions</returns>
        public List<TransactionVM> SelectTransactionsByTransactionDate(DateTime transactionDate)
        {
            List<TransactionVM> transactions = new List<TransactionVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_transactions_by_datetime", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TransactionDateTime", transactionDate);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransactionVM transactionVM = new TransactionVM();

                    transactionVM.TransactionID = reader.GetInt32(0);
                    transactionVM.TransactionDate = reader.GetDateTime(1);
                    transactionVM.UserID = reader.GetInt32(2);
                    transactionVM.FirstName = reader.GetString(3);
                    transactionVM.LastName = reader.GetString(4);
                    transactionVM.TransactionTypeID = reader.GetString(5);
                    transactionVM.TransactionStatusID = reader.GetString(6);

                    transactions.Add(transactionVM);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return transactions;
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/08/2020
        /// APPROVER: NA
        ///
        /// Implementation for Selecting all transactions using a employee name.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns a list of transactions</returns>
        public List<TransactionVM> SelectTransactionsByEmployeeName(string firstName, string lastName)
        {
            List<TransactionVM> transactions = new List<TransactionVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_transactions_by_employee_name", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("FirstName", firstName);
            cmd.Parameters.AddWithValue("LastName", lastName);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransactionVM transactionVM = new TransactionVM();

                    transactionVM.TransactionID = reader.GetInt32(0);
                    transactionVM.TransactionDate = reader.GetDateTime(1);
                    transactionVM.UserID = reader.GetInt32(2);
                    transactionVM.FirstName = reader.GetString(3);
                    transactionVM.LastName = reader.GetString(4);
                    transactionVM.TransactionTypeID = reader.GetString(5);
                    transactionVM.TransactionStatusID = reader.GetString(6);

                    transactions.Add(transactionVM);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return transactions;
        }
    }
}
