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
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/13/2020
    /// Approver: Chuck Baxter, 2/13/2020
    /// 
    /// Medication accessor class
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>

    public class MedicationAccessor : IMedicationAccessor
    {
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// gets the complete medication inventory
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public List<Medication> GetCompleteMedicationInventory()
        {
            var conn = DBConnection.GetConnection();
            Medication _medication = new Medication();

            var cmd1 = new SqlCommand("SP_SELECT_Items_By_ItemCategoryID");

            cmd1.Connection = conn;

            cmd1.CommandType = CommandType.StoredProcedure;

            List<Medication> N = new List<Medication>();


            try
            {
                conn.Open();
                var reader = cmd1.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var medication = new Medication();
                        

                        medication.ItemID = reader.GetInt32(0);
                        medication.ItemQuantity = reader.GetInt32(1);
                        medication.ItemName = reader.GetString(2);


                        N.Add(medication);
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
            return N.ToList();

           
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/3/2020
        /// Approver: Carl Davis, 3/6/2020
        /// Approver: 
        /// 
        /// Get medication list where quantity is below a specified number
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public List<Medication> GetMedicationByLowQauntity()
        {
            var conn = DBConnection.GetConnection();
            Medication _medication = new Medication();

            var cmd1 = new SqlCommand("SP_SELECT_Medication_By_Low_Qauntity");

            cmd1.Connection = conn;

            cmd1.CommandType = CommandType.StoredProcedure;

            List<Medication> N = new List<Medication>();


            try
            {
                conn.Open();
                var reader = cmd1.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var medication= new Medication();


                        medication.ItemID = reader.GetInt32(0);
                        medication.ItemQuantity = reader.GetInt32(1);
                        medication.ItemName = reader.GetString(2);


                        N.Add(medication);
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
            return N.ToList();
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/3/2020
        /// Approver: Carl Davis, 3/6/2020
        /// Approver: 
        /// 
        /// Get medication list where quantity is eqaul to zero
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public List<Medication> GetMedicationByEmptyQauntity()
        {
            var conn = DBConnection.GetConnection();
            Medication _medication = new Medication();

            var cmd1 = new SqlCommand("SP_SELECT_Medication_By_Empty_Qauntity");

            cmd1.Connection = conn;

            cmd1.CommandType = CommandType.StoredProcedure;

            List<Medication> N = new List<Medication>();


            try
            {
                conn.Open();
                var reader = cmd1.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var medication = new Medication();


                        medication.ItemID = reader.GetInt32(0);
                        medication.ItemQuantity = reader.GetInt32(1);
                        medication.ItemName = reader.GetString(2);


                        N.Add(medication);
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
            return N.ToList();
        }
        
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// Approver: 
        /// 
        /// inserts a fake medication order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public int InsertMedicationOrder(int ItemID, string ItemName, int ItemQuantity)
        {
            int Order = 0;

            var conn = DBConnection.GetConnection();


            var cmd = new SqlCommand("SP_Create_SpecialOrder", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string CID = "Medication";

            cmd.Parameters.AddWithValue("@ItemID", ItemID);
            cmd.Parameters.AddWithValue("@ItemName", ItemName);
            cmd.Parameters.AddWithValue("@ItemQuantity", ItemQuantity);
            cmd.Parameters.AddWithValue("@ItemCategoryID", CID);



            try
            {
                conn.Open();
                Order = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return Order;
        }
    }

}