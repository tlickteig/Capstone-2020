using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// NAME: Alex Diers
    /// DATE: 2/6/2020
    /// CHECKED BY: Lane Sandburg
    /// 
    /// This class is used for accessing the data store to perform basic
    ///     CRUD functions
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATED DATE: NA
    /// WHAT WAS CHANGED: NA
    /// </remarks>
    public class TrainingVideoAccessor : ITrainingVideoAccessor
    {
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/03/01
        /// Approver:
        /// 
        /// Activate a Training Video
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        public int ActivateTrainingVideo(TrainingVideo video)
        {
            int videoID = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_reactivate_trainer_video", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TrainingVideoID", video.TrainingVideoID);


            try
            {
                conn.Open();
                videoID = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return videoID;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/03/01
        /// Approver:
        /// 
        /// Deactivate a Training Video
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        public int DeactivateTrainingVideo(TrainingVideo video)
        {
            int videoID = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_deactivate_training_video", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TrainingVideoID", video.TrainingVideoID);


            try
            {
                conn.Open();
                videoID = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return videoID;
        }

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/6/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Implementation of the InsertTrainingVideo method to add a TrainingVideo
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        public int InsertTrainingVideo(TrainingVideo video)
        {
            int videoID = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_training_video", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TrainingVideoID", video.TrainingVideoID);
            cmd.Parameters.AddWithValue("@RunTimeMinutes", video.RunTimeMinutes);
            cmd.Parameters.AddWithValue("@RunTimeSeconds", video.RunTimeSeconds);
            cmd.Parameters.AddWithValue("@Description", video.Description);

            try
            {
                conn.Open();
                videoID = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return videoID;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: 
        /// 
        /// Find videos based on active state
        /// </summary>
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<TrainingVideo> SelectTrainingVideosByActive(bool active = true)
        {
            List<TrainingVideo> videos = new List<TrainingVideo>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_videos_by_active", conn);
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
                        videos.Add(new TrainingVideo()
                        {
                            TrainingVideoID = reader.GetString(0),
                            RunTimeMinutes = reader.GetInt32(1),
                            RunTimeSeconds = reader.GetInt32(2),
                            Description = reader.GetString(3),
                            Active = reader.GetBoolean(4)
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

            return videos;
        }


        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/13/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Implementation of the SelectTrainingVideosByEmployee method used to show
        ///     a list of training videos the employee needs to watch
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        public List<TrainingVideo> SelectTrainingVideosByEmployee()
        {
            List<TrainingVideo> videos = new List<TrainingVideo>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_videos_by_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        videos.Add(new TrainingVideo()
                        {
                            TrainingVideoID = reader.GetString(0),
                            RunTimeMinutes = reader.GetInt32(1),
                            RunTimeSeconds = reader.GetInt32(2),
                            Description = reader.GetString(3),
                            Active = reader.GetBoolean(4)
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

            return videos;
        }

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/13/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Implementation of the SelectTrainingVideosByEmployee method used to show
        ///     a list of training videos the employee needs to watch
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>

        public int UpdateTrainingVideo(TrainingVideo oldVideo, TrainingVideo newVideo)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_trainer_video", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@NewRunTimeMinutes", newVideo.RunTimeMinutes);
            cmd.Parameters.AddWithValue("@NewRunTimeSeconds", newVideo.RunTimeSeconds);
            cmd.Parameters.AddWithValue("@NewDescription", newVideo.Description);

            cmd.Parameters.AddWithValue("@OldTrainingVideoID", oldVideo.TrainingVideoID);
            cmd.Parameters.AddWithValue("@OldRunTimeMinutes", oldVideo.RunTimeMinutes);
            cmd.Parameters.AddWithValue("@OldRunTimeSeconds", oldVideo.RunTimeSeconds);
            cmd.Parameters.AddWithValue("@OldDescription", oldVideo.Description);

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
        /// NAME: Alex Diers
        /// DATE: 3/5/2020
        /// CHECKED BY: Chase Schulte
        /// 
        /// Selects a list of training videos and sorts them by relevant employee data
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        public List<TrainingVideoVM> SelectTrainingVideosByEmployee(bool watched = false)
        {

            List<TrainingVideoVM> videos = new List<TrainingVideoVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_videos_by_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IsWatched", watched);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        videos.Add(new TrainingVideoVM()
                        {
                            TrainingVideoID = reader.GetString(0),
                            RunTimeMinutes = reader.GetInt32(1),
                            RunTimeSeconds = reader.GetInt32(2),
                            Description = reader.GetString(3),
                            Active = reader.GetBoolean(4),
                            IsWatched = reader.GetBoolean(5),
                            UserID = reader.GetInt32(6),
                            FirstName = reader.GetString(7),
                            LastName = reader.GetString(8)
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

            return videos;
        }

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 3/5/2020
        /// CHECKED BY: Chase Schulte
        /// 
        /// Changes the status of a TrainingVideoVM to being watched
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        /// <param name="videoVM"></param>
        /// <returns></returns>
        public int UpdateIsWatched(TrainingVideoVM videoVM)
        {
            int videoID = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_iswatched", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", videoVM.UserID);
            cmd.Parameters.AddWithValue("@TrainingVideoID", videoVM.TrainingVideoID);



            try
            {
                conn.Open();
                videoID = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return videoID;
        }

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 3/5/2020
        /// CHECKED BY: Chase Schulte
        /// 
        /// Changes the status of a TrainingVideoVM to not being watched
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Chase Schulte
        /// UPDATED DATE: 5/02/2020
        /// WHAT WAS CHANGED: Added UserID to paramters 
        /// </remarks>
        /// <param name="videoVM"></param>
        /// <returns></returns>
        public int UpdateNotWatched(TrainingVideoVM videoVM)
        {
            int videoID = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_notwatched", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", videoVM.UserID);

            cmd.Parameters.AddWithValue("@TrainingVideoID", videoVM.TrainingVideoID);


            try
            {
                conn.Open();
                videoID = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return videoID;
        }

    }
}
