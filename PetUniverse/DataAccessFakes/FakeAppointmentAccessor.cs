using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Thomas Dupuy
    /// Created: 2020/02/06
    /// Approver: Awaab Elamin
    /// 
    /// This fake accessor class is used as an accessor for the data objects
    /// </summary>
    public class FakeAppointmentAccessor : IAppointmentAccessor
    {
        private List<Appointment> appointments;

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2020/2/6
        /// Approver: Awaab Elamin
        /// 
        /// This method is a no-argument constructor
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        public FakeAppointmentAccessor()
        {
            appointments = new List<Appointment>()
            {
                new Appointment()
                {
                    AppointmentID = 1000000,
                    AdoptionApplicationID = 1000000,
                    AppointmentTypeID = "InHomeInspection",
                    DateTime = new DateTime(2020, 5, 1, 12, 30, 00),
                    Notes = "",
                    Decicion = "Undesided",
                    Location = "123 Real Ave, Marion IA"
                },
                new Appointment()
                {
                    AppointmentID = 1000001,
                    AdoptionApplicationID = 1000001,
                    AppointmentTypeID = "InHomeInspection",
                    DateTime = new DateTime(2020, 4, 2, 16, 15, 00),
                    Notes = "",
                    Decicion = "Undesided",
                    Location = "654 Notreal Blvd, Marion IA"
                }
            };
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2020/2/6
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
            return appointments;
        }
    }
}
