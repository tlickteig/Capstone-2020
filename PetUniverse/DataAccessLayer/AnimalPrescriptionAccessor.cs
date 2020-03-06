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
    /// Creator: Ethan Murphy
    /// Created: 2/16/2020
    /// Approver: Carl Davis 2/21/2020
    /// Approver:
    /// 
    /// A class used to access data pertaining to animal prescriptions
    /// </summary>
    public class AnimalPrescriptionAccessor : IAnimalPrescriptionsAccessor
    {
        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver:
        /// 
        /// Creates an animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalPrescription">An AnimalPrescription object</param>
        /// <returns>Creation succesful</returns>
        public bool CreateAnimalPrescriptionRecord(AnimalPrescriptions animalPrescription)
        {
            bool result = false;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_create_animal_prescription_record", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalID", animalPrescription.AnimalID);
            cmd.Parameters.AddWithValue("@AnimalVetAppointmentID", animalPrescription.AnimalVetAppointmentID);
            cmd.Parameters.AddWithValue("@PrescriptionName", animalPrescription.PrescriptionName);
            cmd.Parameters.AddWithValue("@Dosage", animalPrescription.Dosage);
            cmd.Parameters.AddWithValue("@MedicationInterval", animalPrescription.Interval);
            cmd.Parameters.AddWithValue("@AdministrationMethod", animalPrescription.AdministrationMethod);
            cmd.Parameters.AddWithValue("@StartDate", animalPrescription.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", animalPrescription.EndDate);
            cmd.Parameters.AddWithValue("@Description", animalPrescription.Description);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
}
