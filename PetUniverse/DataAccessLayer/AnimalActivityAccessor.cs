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
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Gets animal activity records by activity type
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="activity">Activity type ID</param>
        /// <returns>List of animal activity records</returns>
        public List<AnimalActivity> GetAnimalActivityRecordsByActivityType(string activity)
        {
            List<AnimalActivity> activities = new List<AnimalActivity>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_animal_activites_by_activity_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActivityTypeID", activity);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    activities.Add(new AnimalActivity()
                    {
                        AnimalActivityId = reader.GetInt32(0),
                        AnimalID = reader.GetInt32(1),
                        UserID = reader.GetInt32(2),
                        AnimalName = reader.GetString(3),
                        AnimalActivityTypeID = reader.GetString(4),
                        ActivityDateTime = reader.GetDateTime(5),
                        Description = reader.IsDBNull(6) ? "" : reader.GetString(6)
                    });
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

            return activities;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Gets animal activity types
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal activity types</returns>
        public List<AnimalActivityType> GetAnimalActivityTypes()
        {
            List<AnimalActivityType> activityTypes = new List<AnimalActivityType>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_animal_activity_types", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    activityTypes.Add(new AnimalActivityType()
                    {
                        ActivityTypeId = reader.GetString(0),
                        Description = reader.GetString(1)
                    });
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

            return activityTypes;
        }

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

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Inserts an animal activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalActivity">The record to insert</param>
        /// <returns>List of animal activity types</returns>
        public int InsertAnimalActivityRecord(AnimalActivity animalActivity)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_animal_activity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalID", animalActivity.AnimalID);
            cmd.Parameters.AddWithValue("@UserID", animalActivity.UserID);
            cmd.Parameters.AddWithValue("@AnimalActivityTypeID", animalActivity.AnimalActivityTypeID);
            cmd.Parameters.AddWithValue("@ActivityDateTime", animalActivity.ActivityDateTime);
            cmd.Parameters.AddWithValue("@Description", animalActivity.Description);

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
        /// Creator: Ethan Murphy
        /// Created: 4/6/2020
        /// Approver: Chuck Baxter 4/7/2020
        /// 
        /// Updates an existing animal activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalActivity">The existing record</param>
        /// <param name="newAnimalActivity">The updated record</param>
        /// <returns>Update successful</returns>
        public int UpdateAnimalActivityRecord(AnimalActivity oldAnimalActivity, AnimalActivity newAnimalActivity)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_animal_activity", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalActivityID", oldAnimalActivity.AnimalActivityId);
            cmd.Parameters.AddWithValue("@AnimalID", oldAnimalActivity.AnimalID);
            cmd.Parameters.AddWithValue("@UserID", oldAnimalActivity.UserID);
            cmd.Parameters.AddWithValue("@AnimalActivityTypeID", oldAnimalActivity.AnimalActivityTypeID);
            cmd.Parameters.AddWithValue("@ActivityDateTime", oldAnimalActivity.ActivityDateTime);
            cmd.Parameters.AddWithValue("@Description", oldAnimalActivity.Description);

            cmd.Parameters.AddWithValue("@NewAnimalID", newAnimalActivity.AnimalID);
            cmd.Parameters.AddWithValue("@NewUserID", newAnimalActivity.UserID);
            cmd.Parameters.AddWithValue("@NewAnimalActivityTypeID", newAnimalActivity.AnimalActivityTypeID);
            cmd.Parameters.AddWithValue("@NewActivityDateTime", newAnimalActivity.ActivityDateTime);
            cmd.Parameters.AddWithValue("@NewDescription", newAnimalActivity.Description);

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