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
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/4/2020
    /// 
    /// Accessor for the kennel cleaning records
    /// </summary>
    public class AnimalKennelCleaningAccessor : IAnimalKennelCleaningAccessor
    {
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// Approver:
        /// 
        /// Inserts the cleaning record into the database 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="cleaningRecord"></param>
        /// <returns></returns>
        public int InsertKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_kennel_cleaning_record", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalKennelID", cleaningRecord.AnimalKennelID);
            cmd.Parameters.AddWithValue("@UserID", cleaningRecord.UserID);
            cmd.Parameters.AddWithValue("@Date", cleaningRecord.Date);
            cmd.Parameters.AddWithValue("@Notes", cleaningRecord.Notes);

            try
            {
                conn.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
}
