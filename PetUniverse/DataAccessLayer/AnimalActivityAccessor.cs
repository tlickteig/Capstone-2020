using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// 
    /// Animal Activity Accessor class
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public class AnimalActivityAccessor : IAnimalActivityAccessor
    {
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Gets the animal feeding records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public List<AnimalActivity> GetAnimalFeedingRecords()
        {
            var conn = DBConnection.GetConnection();

            var cmd1 = new SqlCommand("sp_SELECT_Animal_Feeding_Records");

            cmd1.Connection = conn;

            cmd1.CommandType = CommandType.StoredProcedure;

            List<AnimalActivity> N = new List<AnimalActivity>();

            try
            {
                conn.Open();
                var reader = cmd1.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        N.Add(new AnimalActivity()
                        {


                            AnimalID = reader.GetInt32(0),
                            UserID = reader.GetInt32(1),


                            AnimalActivityTypeID = reader.GetString(3),
                          ActivityDateTime = reader.GetDateTime(4)


                          


                        });
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

            return N.ToList();
        }



    }

}