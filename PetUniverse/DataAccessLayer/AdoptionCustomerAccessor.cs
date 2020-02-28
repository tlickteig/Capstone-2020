using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/6/202
    /// CHECKED BY: Mohamed Elamin, 02/07/2020
    /// 
    /// This data access class is used to access data that pertains to the Adoption customer.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class AdoptionCustomerAccessor : IAdoptionCustomerAccessor
    {
        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/202
        /// CHECKED BY: Mohamed Elamin, 02/07/2020
        /// 
        /// This method retrieves a list of AdoptionCustomerVMs from the database and returns it.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<AdoptionCustomerVM> SelectAdoptionCustomersByActive(bool active)
        {
            List<AdoptionCustomerVM> adoptionCustomers = new List<AdoptionCustomerVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_customers_by_active", conn);
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
                        AdoptionCustomerVM adoptionCustomer = new AdoptionCustomerVM();

                        adoptionCustomer.PUUserID = reader.GetInt32(0);
                        adoptionCustomer.FirstName = reader.GetString(1);
                        adoptionCustomer.LastName = reader.GetString(2);
                        adoptionCustomer.PhoneNumber = reader.GetString(3);
                        adoptionCustomer.Email = reader.GetString(4);
                        adoptionCustomer.Active = reader.GetBoolean(5);
                        adoptionCustomer.City = reader.GetString(6);
                        adoptionCustomer.State = reader.GetString(7);
                        adoptionCustomer.ZipCode = reader.GetString(8);
                        adoptionCustomer.CustomerID = reader.GetInt32(9);
                        adoptionCustomer.AnimalID = reader.GetInt32(10);
                        adoptionCustomer.CustomerAdoptionStatus = reader.GetString(11);
                        adoptionCustomer.AdoptionApplicationRecievedDate = reader.GetDateTime(12);
                        adoptionCustomer.AnimalName = reader.GetString(13);
                        adoptionCustomer.AnimalBreed = reader.GetString(14);
                        adoptionCustomer.AnimalArrivalDate = reader.GetDateTime(15);
                        adoptionCustomer.CurrentlyHoused = reader.GetBoolean(16);
                        adoptionCustomer.Adoptable = reader.GetBoolean(17);
                        adoptionCustomer.AnimalActive = reader.GetBoolean(18);
                        adoptionCustomer.AdoptionApplicationID = reader.GetInt32(19);
                        adoptionCustomer.AnimalSpecies = reader.GetString(20);
                        

                        adoptionCustomers.Add(adoptionCustomer);
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

            return adoptionCustomers;
        }
    }
}
