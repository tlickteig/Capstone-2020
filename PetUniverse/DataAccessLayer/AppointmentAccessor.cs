using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using System.Data;
using System.Data.SqlClient;
using DataAccessInterfaces;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Thomas Dupuy
    /// Created: 02/06/2020
    /// Approver: Awaab Elamin
    /// 
    /// This Accessor class is used as ac accessor for the data objects
    /// </summary>
    class AppointmentAccessor : IAppointmentAccessor
    {
        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 02/06/2020
        /// Approver: Awaab Elamin
        /// 
        /// This method selects all appointments
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        public List<Appointment> SelectAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_appointments");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Appointment newAppointment = new Appointment
                    {
                        AdoptionApplicationID = reader.GetInt32(0),
                        AppointmentID = reader.GetInt32(1),
                        AppointmentTypeID = reader.GetString(2),
                        DateTime = reader.GetDateTime(3),
                        Notes = reader.GetString(4),
                        Decicion = reader.GetString(5),
                        Location = reader.GetString(6)
                    };
                    appointments.Add(newAppointment);
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
            return appointments;
        }
    }
}
