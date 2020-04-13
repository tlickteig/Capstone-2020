using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    ///  CREATOR: Ryan Morganti
    ///  CREATED: 2020/04/04
    ///  APPROVER: Matt Deaton
    ///  
    ///   Donation Access class for connection to the database when making donation relation queries
    /// </summary>
    public class DonationAccessor : IDonationAccessor
    {
        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/04
        ///  APPROVER: Matt Deaton
        ///  
        ///  Database access method used to retrieve the past year's donation history
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public List<Donation> SelectDonationsFromPastYear()
        {
            List<Donation> donations = new List<Donation>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_donations_from_past_year", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Donation newDonation = new Donation();

                        newDonation.DonationID = reader.GetInt32(0);
                        newDonation.DonorID = reader.GetInt32(1);
                        newDonation.FirstName = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                        {
                            newDonation.LastName = reader.GetString(3);
                        }
                        
                        newDonation.DateOfDonation = reader.GetDateTime(4);
                        newDonation.TypeOfDonation = reader.GetString(5);
                        if (!reader.IsDBNull(6))
                        {
                            newDonation.DonationAmount = reader.GetDecimal(6);
                        }
                        

                        donations.Add(newDonation);
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

            return donations;
        }
    }
}
