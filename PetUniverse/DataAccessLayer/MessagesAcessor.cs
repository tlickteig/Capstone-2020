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
    /// Creator: Zach Behrensmeyer
    /// Created: 03/16/2020
    /// Approver: Steven Cardona
    ///
    /// Class of methods for Accessing Messages
    /// </summary>
    public class MessagesAcessor : IMessagesAccessor
    {
        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        ///
        /// This method connects to the database and retrieve departments like the provided text via the sp_get_departments_like_input stored procedure
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="Input"></param>
        /// <returns>departments with similar names</returns>
        public List<string> GetDepartmentsLikeInput(string Input)
        {
            List<string> similarDepartments = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_departments_like_input", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("query", Input);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string query = reader.GetString(0);
                        similarDepartments.Add(query);
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

            return similarDepartments;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        ///
        /// This method connects to the database and retrieve users like the provided text via the sp_get_departments_like_input stored procedure
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="Input"></param>
        /// <returns>users with similar emails</returns>
        public List<string> GetUsersLikeInput(string Input)
        {
            List<string> similarUsers = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_users_like_input", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("query", Input);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string query = reader.GetString(0);
                        similarUsers.Add(query);
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

            return similarUsers;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        ///
        /// This method connects to the database and inserts a message into the message table
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>       
        /// <param name="content"></param>
        /// <param name="subject"></param>
        /// <param name="senderID"></param>
        /// <param name="recieverID"></param>
        /// <returns>users with similar emails</returns>
        public bool sendEmail(string content, string subject, int senderID, int recieverID)
        {

            bool isSent = false;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_message", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("MessageContent", content);
            cmd.Parameters.AddWithValue("MessageTitle", subject);
            cmd.Parameters.AddWithValue("MessageSenderID", senderID);
            cmd.Parameters.AddWithValue("MessageReceiverID", recieverID);
            
            try
            {
                conn.Open();
                isSent = 1 == cmd.ExecuteNonQuery();                     
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return isSent;
        }      
    }
}
