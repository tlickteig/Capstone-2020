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
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/14/2020
    /// Approver: Chuck Baxter, 2/14/2020
    /// 
    /// Data access methods for the kennel table
    /// </summary>
    public class AnimalKennelAccessor : IAnimalKennelAccessor
    {
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Adds a kennel record to the database 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennel"> Kennel object </param>
        /// <returns> An integer that represents the number of rows effected. Should equal 1 if method succeeded. </returns>
        public int InsertKennelRecord(AnimalKennel kennel)
        {
            int animalKennelID = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_kennel_record", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalID", kennel.AnimalID);
            cmd.Parameters.AddWithValue("@UserID", kennel.UserID);
            cmd.Parameters.AddWithValue("@AnimalKennelInfo", kennel.AnimalKennelInfo);
            cmd.Parameters.AddWithValue("@AnimalKennelDateIn", kennel.AnimalKennelDateIn);

            try
            {
                conn.Open();
                animalKennelID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return animalKennelID;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/12/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Gets all kennel records and returns them to the up layers
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AnimalKennel> RetriveAllAnimalKennels()
        {
            List<AnimalKennel> kennels = new List<AnimalKennel>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_kennel_records");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var note = new AnimalKennel();
                        note.AnimalKennelID = reader.GetInt32(0);
                        note.AnimalID = reader.GetInt32(1);
                        note.UserID = reader.GetInt32(2);
                        note.AnimalKennelInfo = reader.GetString(3);
                        note.AnimalKennelDateIn = reader.GetDateTime(4);
                        note.AnimalKennelDateOut = reader[5] as DateTime?;
                        kennels.Add(note);
                    }
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

            return kennels;
        }
    }
}
