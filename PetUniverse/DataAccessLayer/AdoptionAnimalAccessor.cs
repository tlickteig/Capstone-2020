using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/5/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Holds the data access methods for the AdoptionAnimalAccessor Class
    /// </summary>
    public class AdoptionAnimalAccessor : IAdoptionAnimalAccessor
    {

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/4/2020
        /// Approver: Micheal Thompson, 4/9/2020
        /// 
        /// Deactivates a chosen animal
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns></returns>
        public int DeactivateAdoptionAnimal(int animalID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_animal", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalID", animalID);

            try
            {
                conn.Open();

                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Selects a list of Adoption Animal VMs from the database
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<AdoptionAnimalVM> SelectAdoptionAnimalsByActive(bool active)
        {
            List<AdoptionAnimalVM> adoptionAnimalVMs = new List<AdoptionAnimalVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_animals_by_active", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var adoptionAnimalVM = new AdoptionAnimalVM();

                        if (!reader.IsDBNull(0)) adoptionAnimalVM.AnimalID = reader.GetInt32(0);
                        if (!reader.IsDBNull(1)) adoptionAnimalVM.AnimalName = reader.GetString(1);
                        if (!reader.IsDBNull(2)) adoptionAnimalVM.Dob = reader.GetDateTime(2);
                        if (!reader.IsDBNull(3)) adoptionAnimalVM.AnimalBreed = reader.GetString(3);
                        if (!reader.IsDBNull(4)) adoptionAnimalVM.ArrivalDate = reader.GetDateTime(4);
                        if (!reader.IsDBNull(5)) adoptionAnimalVM.CurrentlyHoused = reader.GetBoolean(5);
                        if (!reader.IsDBNull(6)) adoptionAnimalVM.Adoptable = reader.GetBoolean(6);
                        if (!reader.IsDBNull(7)) adoptionAnimalVM.Active = reader.GetBoolean(7);
                        if (!reader.IsDBNull(8)) adoptionAnimalVM.AnimalSpeciesID = reader.GetString(8);
                        if (!reader.IsDBNull(9)) adoptionAnimalVM.AnimalKennelID = reader.GetInt32(9);
                        if (!reader.IsDBNull(10)) adoptionAnimalVM.AnimalKennelInfo = reader.GetString(10);
                        if (!reader.IsDBNull(11)) adoptionAnimalVM.AnimalMedicalInfoID = reader.GetInt32(11);
                        if (!reader.IsDBNull(12)) adoptionAnimalVM.IsSpayedorNuetered = reader.GetBoolean(12);
                        if (!reader.IsDBNull(13)) adoptionAnimalVM.AdoptionApplicationID = reader.GetInt32(13);
                        if (!reader.IsDBNull(14)) adoptionAnimalVM.CustomerEmail = reader.GetString(14);
                        //if(!reader.IsDBNull(15))adoptionAnimalVM.UserID = reader.GetInt32(15);
                        if (!reader.IsDBNull(15)) adoptionAnimalVM.CustomerFirstName = reader.GetString(15);
                        if (!reader.IsDBNull(16)) adoptionAnimalVM.CustomerLastName = reader.GetString(16);
                        if (!reader.IsDBNull(17)) adoptionAnimalVM.AnimalHandlingNotesID = reader.GetInt32(17);
                        if (!reader.IsDBNull(18)) adoptionAnimalVM.AnimalHandlingNotes = reader.GetString(18);
                        if (!reader.IsDBNull(19)) adoptionAnimalVM.TempermentWarning = reader.GetString(19);

                        adoptionAnimalVMs.Add(adoptionAnimalVM);


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

            return adoptionAnimalVMs;
        }
    }
}
