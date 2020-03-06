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
        public List<TransactionVM> SelectAllTransactions()
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
                        transactionVM.Notes = reader.GetString(7);

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
            throw new NotImplementedException();
        }
    }
}
