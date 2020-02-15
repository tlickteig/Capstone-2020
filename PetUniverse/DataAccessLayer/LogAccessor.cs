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
    /// NAME: Zach Behrensmeyer
    /// DATE: 2/11/2020
    /// CHECKED BY: Steven Cardona
    /// 
    /// This class accesses Log data 
    /// </summary>
    public class LogAccessor : ILogAccessor
    {


        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/11/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This method is used to get logs related to login and logouts
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// CHANGE:
        /// </remarks>
        /// <returns>List of Logs</returns>
        public List<LogItem> GetLoginLogout()
        {
            List<LogItem> Logs = new List<LogItem>();

            //Get a connection
            var conn = DBConnection.GetConnection();

            //Call the sproc
            var cmd = new SqlCommand("sp_get_login_logout_logs", conn);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        LogItem log = new LogItem();
                        log.LogID = reader.GetInt32(0);
                        log.LogDate = reader.GetDateTime(1);
                        log.LogLevel = reader.GetString(2);
                        log.Message = reader.GetString(3);
                        Logs.Add(log);
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
            return Logs;
        }
    }
}
