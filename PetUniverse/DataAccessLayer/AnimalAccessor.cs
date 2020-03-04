using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;
// needed to connect to SQL server
using System.Data.SqlClient;
// needed for provides access to classes that represent the ADO.NET architecture
using System.Data;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// animal accessor to interact with animal data
    /// </summary>

    public class AnimalAccessor : IAnimalAccessor
    {
        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020 
        ///
        /// a data access method that uses a stored procedure to add a new animal to the database
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 2/28/2020
        /// Update: Removed status and image location
        /// Approver: Austin Gee
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animal"></param>
        /// <returns></returns>
        public int InsertAnimal(Animal animal)
        {
            int AnimalID = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_animal", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalName", animal.AnimalName);
            cmd.Parameters.AddWithValue("@Dob", animal.Dob);
            cmd.Parameters.AddWithValue("@AnimalBreed", animal.AnimalBreed);
            cmd.Parameters.AddWithValue("@ArrivalDate", animal.ArrivalDate);
            cmd.Parameters.AddWithValue("@AnimalSpeciesID", animal.AnimalSpeciesID);

            try
            {
                conn.Open();
                AnimalID = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return AnimalID;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/13/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Daulton Schilling, 2/14/2020 
        /// 
        /// a data access method that uses a stored procedure to select a list of animals where the active 
        /// field is true
        /// 
        /// need to add a default imagelocation later
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 2/28/2020
        /// Update: Removed status and image location
        /// Approver: Austin Gee
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="active"></param>
        /// <returns>a list of animal objects</returns>
        public List<Animal> SelectAnimalsByActive(bool active = true)
        {
            List<Animal> animals = new List<Animal>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_active_animals");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Active", SqlDbType.Bit);
            cmd.Parameters["@Active"].Value = active;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var animal = new Animal();
                        animal.AnimalID = reader.GetInt32(0);
                        animal.AnimalName = reader.GetString(1);
                        if (reader.IsDBNull(2))
                        {
                            animal.Dob = DateTime.Parse("01/01/2020");
                        }
                        else
                        {
                            animal.Dob = reader.GetDateTime(2);
                        }
                        animal.AnimalBreed = reader.GetString(3);
                        animal.ArrivalDate = reader.GetDateTime(4);
                        animal.CurrentlyHoused = reader.GetBoolean(5);
                        animal.Adoptable = reader.GetBoolean(6);
                        animal.Active = reader.GetBoolean(7);
                        animal.AnimalSpeciesID = reader.GetString(8);

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

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver:  
        /// 
        /// a data access method that uses a stored procedure to select a list of animals where the active 
        /// field is false
        /// 
        /// need to add a default imagelocation later
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 2/28/2020
        /// Update: Removed status and image location
        /// Approver: Austin Gee
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="active"></param>
        /// <returns>a list of animal objects</returns>
        public List<Animal> SelectAnimalsByInactive(bool active = false)
        {
            List<Animal> animals = new List<Animal>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_active_animals");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Active", SqlDbType.Bit);
            cmd.Parameters["@Active"].Value = active;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var animal = new Animal();
                        animal.AnimalID = reader.GetInt32(0);
                        animal.AnimalName = reader.GetString(1);
                        if (reader.IsDBNull(2))
                        {
                            animal.Dob = DateTime.Parse("01/01/2020");
                        }
                        else
                        {
                            animal.Dob = reader.GetDateTime(2);
                        }
                        animal.AnimalBreed = reader.GetString(3);
                        animal.ArrivalDate = reader.GetDateTime(4);
                        animal.CurrentlyHoused = reader.GetBoolean(5);
                        animal.Adoptable = reader.GetBoolean(6);
                        animal.Active = reader.GetBoolean(7);
                        animal.AnimalSpeciesID = reader.GetString(8);

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

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/28/2020
        /// Approver: Jordan Lindo, 2/28/2020
        /// Approver:  
        /// 
        /// a data access method that uses a stored procedure to select a list of strings of animal species
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param></param>
        /// <returns>a list of animal objects</returns>
        public List<string> SelectAnimalSpeciesID()
        {
            List<string> species = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_animal_species");
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
                        species.Add(reader.GetString(0));
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
            return species;
        }
    }
}
