using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 2/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// This class accesses Applicants 
    /// </summary>
    public class ApplicantAccessor : IApplicantAccessor
    {
        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This method is used to get all applicants
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>List of Logs</returns>
        public List<Applicant> SelectAllApplicants()
        {
            List<Applicant> applicants = new List<Applicant>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_applicants", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        applicants.Add(new Applicant()
                        {
                            ApplicantID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            MiddleName = reader.GetString(3),
                            Email = reader.GetString(4),
                            PhoneNumber = reader.GetString(5)
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
            return applicants;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/19
        /// Approver: Derek Taylor
        ///  
        /// Method used to query all the positions at PetUniverse from the DataBase
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public List<JobListing> SelectAllJobPositions()
        {
            List<JobListing> positions = new List<JobListing>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_job_listings", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        JobListing job = new JobListing();

                        job.JobListingID = reader.GetInt32(0);
                        job.Position = reader.GetString(1);
                        job.Benefits = reader.GetString(2);
                        job.Requirements = reader.GetString(3);
                        job.StartingWage = reader.GetDecimal(4);
                        job.Responsibilities = reader.GetString(5);
                        job.Active = reader.GetBoolean(6);

                        positions.Add(job);
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
            return positions;
        }
    }
}
