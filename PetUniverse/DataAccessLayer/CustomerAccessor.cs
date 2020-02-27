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
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Thomas Dupuy ,2020/02/19
    ///
    /// This Class for accessing Customer data in the database.
    /// </summary>
    public class CustomerAccessor : ICustomerAccessor
    {
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:Thomas Dupuy ,2020/02/21
        /// 
        /// This method used to get  a Customer by Customer's last name.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" customerName"></param>
        /// <returns>customer</returns>
        public Customer RetrieveCustomerByCustomerName(string customerName)
        {
            Customer customer = null;
            // connection
            var conn = DBConnection.GetConnection();
            // commands
            var cmd = new SqlCommand("sp_select_Customer_by_Customer_Name", conn);
            // command type
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar, 50);
            cmd.Parameters["@CustomerName"].Value = customerName;
            try
            {
                // open the connection
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customer = new Customer();
                    customer.UserID = reader.GetInt32(0);
                    customer.FirstName = reader.GetString(1);
                    customer.LastName = customerName;
                    customer.PhoneNumber = reader.GetString(3);
                    customer.Email = reader.GetString(4);
                    customer.Activ = reader.GetBoolean(5);
                    customer.AddressLineOne = reader.GetString(6);
                    customer.AddressLineTwo = reader.GetString(7);
                    customer.City = reader.GetString(8);
                    customer.State = reader.GetString(9);
                    customer.ZipCode = reader.GetString(10);
                }
                else
                {
                    throw new ApplicationException("Customer not found.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't get customer by last name", ex);
            }
            finally
            {
               // close the connection
                conn.Close();
            }
            return customer;
        }
    }
}
