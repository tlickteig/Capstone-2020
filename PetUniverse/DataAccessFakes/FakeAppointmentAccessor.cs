using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Thomas Dupuy
    /// Created: 2/6/2020
    /// Approver: Awaab Elamin
    /// 
    /// This fake accessor class is used as an accessor for the data objects
    /// </summary>
    public class FakeAppointmentAccessor : IAppointmentAccessor
    {

        private List<AppointmentLocationVM> appointments;

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2/6/2020
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
            appointments = new List<AppointmentLocationVM>()
            {
                new AppointmentLocationVM()
                {
                    AppointmentID = 1,
                    AdoptionApplicationID = 1,
                    AppointmentTypeID = "InHomeInspection",
                    DateTime = new DateTime(2020, 5, 1, 12, 30, 00),
                    Notes = "",
                    Decicion = "Undecided",
                    LocationID = 1,
                    Active = true,
                    LocationName = "Home",
                    LocationAddress1 = "123 Real Ave",
                    LocationCity = "Marion",
                    LocationState = "IA",
                    LocationZip = "52402"
                },
                new AppointmentLocationVM()
                {
                    AppointmentID = 2,
                    AdoptionApplicationID = 2,
                    AppointmentTypeID = "Interview",
                    DateTime = new DateTime(2020, 4, 2, 16, 15, 00),
                    Notes = "",
                    Decicion = "Undecided",
                    LocationID = 2,
                    Active = true,
                    LocationName = "Store",
                    LocationAddress1 = "654 Notreal Blvd",
                    LocationCity = "Marion",
                    LocationState = "IA",
                    LocationZip = "52402"
                },
                new AppointmentLocationVM()
                {
                    AppointmentID = 3,
                    AdoptionApplicationID = 2,
                    AppointmentTypeID = "MeetAndGreet",
                    DateTime = new DateTime(2020, 10, 10, 10, 45, 00),
                    Notes = "",
                    Decicion = "Undecided",
                    LocationID = 2,
                    Active = true,
                    LocationName = "Home",
                    LocationAddress1 = "654 Boomway St",
                    LocationAddress2 = "Apt 2",
                    LocationCity = "Ceader Rapids",
                    LocationState = "IA",
                    LocationZip = "52404"
                }
            };
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 4/12/2020
        /// Approver: Michael Thompson
        /// 
        /// This method adds an appointment
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        public int DeactivateAppointment(Appointment appointment)
        {
            int i = 0;
            foreach (var appointmentVar in appointments)
            {
                if (appointmentVar.AppointmentID == appointment.AppointmentID)
                {
                    i++;
                }
            }
            return i;
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 4/12/2020
        /// Approver: Michael Thompson
        /// 
        /// This method removes an appointment
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        public int InsertAppointment(Appointment appointment)
        {
            foreach (var appointmentVar in appointments)
            {
                if (appointmentVar.AppointmentID == appointment.AppointmentID)
                {
                    return 0;
                }
            }
            return 1;
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 02/06/2020
        /// Approver: Awaab Elamin
        /// 
        /// This method retrieve all appointments
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        public List<AppointmentLocationVM> SelectAllActiveAppointments()
        {
            List<AppointmentLocationVM> activeAppointments = new List<AppointmentLocationVM>();
            foreach (var appointment in appointments)
            {
                if (appointment.Active)
                {
                    activeAppointments.Add(appointment);
                }
            }
            return activeAppointments;
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 4/12/2020
        /// Approver: 
        /// 
        /// This method retrieves an appointment by its id
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        public AppointmentLocationVM SelectAppointmentByID(int id)
        {
            foreach (var appointment in appointments)
            {
                if (appointment.AppointmentID == id)
                {
                    return appointment;
                }
            }
            return null;
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 4/15/2020
        /// Approver: Michael Thompson
        /// 
        /// This method updates an appointment
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        public int UpdateAppointment(Appointment oldAppointment, Appointment newAppointment)
        {
            int i = 0;
            foreach (var appointmentVar in appointments)
            {
                if (appointmentVar.AppointmentID == oldAppointment.AppointmentID)
                {
                    i++;
                }
            }
            return i;
        }
    }
}
