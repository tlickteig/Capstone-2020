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
    /// NAME: Derek Taylor
    /// DATE: 2/14/2020
    /// CHECKED BY: Ryan Morganti
    /// 
    /// This class accesses Applicants 
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATED DATE: NA
    /// CHANGE:
    /// </remarks>
    public class ApplicantAccessor : IApplicantAccessor
    {
        /// <summary>
        /// NAME: Derek Taylor
        /// DATE: 2/14/2020
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This method is used to get all applicants
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// CHANGE:
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
    }
}
