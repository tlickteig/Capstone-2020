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
    /// Approver: Ethan Holmes
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
        /// Creator: Jaeho Kim
        /// Created: 2/27/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is a method for selecting all Transactions from the tsql database.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
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
                        transactionVM.Quantity = reader.GetInt32(1);
                        transactionVM.ProductName = reader.GetString(2);
                        transactionVM.Brand = reader.GetString(3);
                        transactionVM.Price = reader.GetDecimal(4);
                        transactionVM.TransactionDate = reader.GetDateTime(5);
                        transactionVM.TransactionTypeID = reader.GetString(6);
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
    }
}
