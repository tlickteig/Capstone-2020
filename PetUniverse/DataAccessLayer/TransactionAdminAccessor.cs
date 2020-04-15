using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/14
    /// Approver: Ethan Holmes
    /// 
    /// This class deals with setting up data that 
    /// the transaction entry use case requires. 
    /// The transaction entry depends on the data, 
    /// transaction type and status. The head 
    /// cashier puts this data into the database 
    /// in which the transaction entry can function.
    /// </summary>
    public class TransactionAdminAccessor : ITransactionAdminAccessor
    {

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Implementation for inserting a transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionStatus"></param>
        /// <returns>rows effected</returns>
        public int InsertTransactionStatus(TransactionStatus transactionStatus)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_transaction_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TransactionStatusID", transactionStatus.TransactionStatusID);
            cmd.Parameters.AddWithValue("@Description", transactionStatus.Description);
            cmd.Parameters.AddWithValue("@DefaultInStore", transactionStatus.DefaultInStore);

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
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Implementation for inserting a transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionType"></param>
        /// <returns>rows effected</returns>
        public int InsertTransactionType(TransactionType transactionType)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_transaction_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TransactionTypeID", transactionType.TransactionTypeID);
            cmd.Parameters.AddWithValue("@Description", transactionType.Description);
            cmd.Parameters.AddWithValue("@DefaultInStore", transactionType.DefaultInStore);

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
    }
}
