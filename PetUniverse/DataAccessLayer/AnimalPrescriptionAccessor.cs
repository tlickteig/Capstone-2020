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

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Selects all animal prescription records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal prescriptions</returns>
        public List<AnimalPrescriptions> SelectAllAnimalPrescriptionRecords()
        {
            List<AnimalPrescriptions> animalPrescriptions = new List<AnimalPrescriptions>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_animal_prescriptions", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        AnimalPrescriptions animalPrescription = new AnimalPrescriptions()
                        {
                            AnimalPrescriptionID = reader.GetInt32(0),
                            AnimalID = reader.GetInt32(1),
                            AnimalVetAppointmentID = reader.GetInt32(2),
                            PrescriptionName = reader.GetString(3),
                            Dosage = reader.GetDecimal(4),
                            Interval = reader.GetString(5),
                            AdministrationMethod = reader.GetString(6),
                            StartDate = reader.GetDateTime(7),
                            EndDate = reader.GetDateTime(8),
                            Description = reader.GetString(9),
                            AnimalName = reader.GetString(10)
                        };
                        animalPrescriptions.Add(animalPrescription);
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
            return animalPrescriptions;
        }
    }
}
