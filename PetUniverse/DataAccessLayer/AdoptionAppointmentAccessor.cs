using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;
using System.Data;

namespace DataAccessLayer
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/20/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This data access class is used to access data that pertains to the Adoption Appointment.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class AdoptionAppointmentAccessor : IAdoptionAppointmentAccessor
    {

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Selects an AdoptionAppointmentVM from the database
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AdoptionAppointmentVM SelectAdoptionAppointmentByAppointmentID(int appointmentID)
        {
            AdoptionAppointmentVM adoptionAppointment = new AdoptionAppointmentVM();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_appointment_by_appointment_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
            
            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    adoptionAppointment.AppointmentID = reader.GetInt32(0);
                    adoptionAppointment.AdoptionApplicationID = reader.GetInt32(1);
                    adoptionAppointment.AppointmentTypeID = reader.GetString(2);
                    adoptionAppointment.AppointmentDateTime = reader.GetDateTime(3);
                    if (!reader.IsDBNull(4))
                    {
                        adoptionAppointment.Notes = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        adoptionAppointment.Decision = reader.GetString(5);
                    }
                    adoptionAppointment.LocationID = reader.GetInt32(6);
                    adoptionAppointment.AppointmentActive = reader.GetBoolean(7);
                    adoptionAppointment.CustomerID = reader.GetInt32(8);
                    adoptionAppointment.AnimalID = reader.GetInt32(9);
                    if (!reader.IsDBNull(10))
                    {
                        adoptionAppointment.AdoptionApplicationStatus = reader.GetString(10);
                    }
                    adoptionAppointment.AdoptionApplicationRecievedDate = reader.GetDateTime(11);
                    if (!reader.IsDBNull(12))
                    {
                        adoptionAppointment.LocationName = reader.GetString(12);
                    }
                    adoptionAppointment.LocationAddress1 = reader.GetString(13);
                    if (!reader.IsDBNull(14))
                    {
                        adoptionAppointment.LocationAddress2 = reader.GetString(14);
                    }
                    adoptionAppointment.LocationCity = reader.GetString(15);
                    adoptionAppointment.LocationState = reader.GetString(16);
                    adoptionAppointment.LocationZip = reader.GetString(17);
                    adoptionAppointment.UserID = reader.GetInt32(18);
                    adoptionAppointment.UserFirstName = reader.GetString(19);
                    adoptionAppointment.UserLastName = reader.GetString(20);
                    adoptionAppointment.UserPhoneNumber = reader.GetString(21);
                    adoptionAppointment.UserEmail = reader.GetString(22);
                    adoptionAppointment.UserActive = reader.GetBoolean(23);
                    adoptionAppointment.UserCity = reader.GetString(24);
                    adoptionAppointment.State = reader.GetString(25);
                    adoptionAppointment.UserZipCode = reader.GetString(26);
                    adoptionAppointment.AnimalName = reader.GetString(27);
                    if (!reader.IsDBNull(28))
                    {
                        adoptionAppointment.AnimalDob = reader.GetDateTime(28);
                    }
                    adoptionAppointment.AnimalSpeciesID = reader.GetString(29);
                    if (!reader.IsDBNull(30))
                    {
                        adoptionAppointment.AnimalBreed = reader.GetString(30);
                    }
                    adoptionAppointment.AnimalArrivalDate = reader.GetDateTime(31);
                    adoptionAppointment.AnimalCurrentlyHoused = reader.GetBoolean(32);
                    adoptionAppointment.AnimalAdoptable = reader.GetBoolean(33);
                    adoptionAppointment.AnimalActive = reader.GetBoolean(34);
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

            return adoptionAppointment;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/20/2020
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
        public List<AdoptionAppointmentVM> SelectAdoptionAppointmentsByActiveAndType(bool active, string appointmentTypeID)
        {
            List<AdoptionAppointmentVM> adoptionAppointments = new List<AdoptionAppointmentVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_appointments_by_active_and_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Active", active);
            cmd.Parameters.AddWithValue("@AppointmentTypeID", appointmentTypeID);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var adoptionAppointment = new AdoptionAppointmentVM();

                        adoptionAppointment.AppointmentID = reader.GetInt32(0);
                        adoptionAppointment.AdoptionApplicationID = reader.GetInt32(1);
                        adoptionAppointment.AppointmentTypeID = reader.GetString(2);
                        adoptionAppointment.AppointmentDateTime = reader.GetDateTime(3);
                        if (!reader.IsDBNull(4))
                        {
                            adoptionAppointment.Notes = reader.GetString(4);
                        }
                        if (!reader.IsDBNull(5))
                        {
                            adoptionAppointment.Decision = reader.GetString(5);
                        }    
                        adoptionAppointment.LocationID = reader.GetInt32(6);
                        adoptionAppointment.AppointmentActive = reader.GetBoolean(7);
                        adoptionAppointment.CustomerID = reader.GetInt32(8);
                        adoptionAppointment.AnimalID = reader.GetInt32(9);
                        if (!reader.IsDBNull(10))
                        {
                            adoptionAppointment.AdoptionApplicationStatus = reader.GetString(10);
                        }
                        adoptionAppointment.AdoptionApplicationRecievedDate = reader.GetDateTime(11);
                        if (!reader.IsDBNull(12))
                        {
                            adoptionAppointment.LocationName = reader.GetString(12);
                        }
                        adoptionAppointment.LocationAddress1 = reader.GetString(13);
                        if (!reader.IsDBNull(14))
                        {
                            adoptionAppointment.LocationAddress2 = reader.GetString(14);
                        }
                        adoptionAppointment.LocationCity = reader.GetString(15);
                        adoptionAppointment.LocationState = reader.GetString(16);
                        adoptionAppointment.LocationZip = reader.GetString(17);
                        adoptionAppointment.UserID = reader.GetInt32(18);
                        adoptionAppointment.UserFirstName = reader.GetString(19);
                        adoptionAppointment.UserLastName = reader.GetString(20);
                        adoptionAppointment.UserPhoneNumber = reader.GetString(21);
                        adoptionAppointment.UserEmail = reader.GetString(22);
                        adoptionAppointment.UserActive = reader.GetBoolean(23);
                        adoptionAppointment.UserCity = reader.GetString(24);
                        adoptionAppointment.State = reader.GetString(25);
                        adoptionAppointment.UserZipCode = reader.GetString(26);
                        adoptionAppointment.AnimalName = reader.GetString(27);
                        if (!reader.IsDBNull(28))
                        {
                            adoptionAppointment.AnimalDob = reader.GetDateTime(28);
                        }
                        adoptionAppointment.AnimalSpeciesID = reader.GetString(29);
                        if (!reader.IsDBNull(30))
                        {
                            adoptionAppointment.AnimalBreed = reader.GetString(30);
                        }
                        adoptionAppointment.AnimalArrivalDate = reader.GetDateTime(31);
                        adoptionAppointment.AnimalCurrentlyHoused = reader.GetBoolean(32);
                        adoptionAppointment.AnimalAdoptable = reader.GetBoolean(33);
                        adoptionAppointment.AnimalActive = reader.GetBoolean(34);

                        adoptionAppointments.Add(adoptionAppointment);
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

            return adoptionAppointments;
        }
    }
}
