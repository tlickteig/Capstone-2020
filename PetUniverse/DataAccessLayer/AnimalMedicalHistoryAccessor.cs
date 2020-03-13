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
    /// Creator: Daulton Schilling
    /// Created: 3/13/2020
    /// Approver: 
    /// 
    /// Class for accessing medical history  
    /// </summary>
    public class AnimalMedicalHistoryAccessor : IAnimalMedicalHistoryAccessor
    {
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// Gets an animals medical history
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="AnimalID"></param>
        /// <Returns>
        /// List<NewAnimalChecklist>
        /// </Returns>
        public List<MedicalHistory> GetAnimalMedicalHistoryByAnimalID(int id)
        {
           
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_Select_AnimalMedicalHistory_By_AnimalID");


            List<MedicalHistory> animals = new List<MedicalHistory>();


            cmd.Connection = conn;


            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@AnimalID", SqlDbType.Int);
            cmd.Parameters["@AnimalID"].Value = id;


            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var animal = new MedicalHistory();

                        animal.AnimalID = reader.GetInt32(0);
                        animal.AnimalName = reader.GetString(1);
                        animal.AnimalSpeciesID = reader.GetString(2);
                        animal.Vaccinations = reader.GetString(3);
                        animal.Spayed_Neutered = reader.GetBoolean(4);
                        animal.MostRecentVaccinationDate = reader.GetDateTime(5);
                        animal.AdditionalNotes = reader.GetString(6);







                        animals.Add(animal);
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
            return animals;
        }
    }
}
