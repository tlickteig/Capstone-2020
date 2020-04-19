using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Thomas Dupuy
    /// Created: 02/06/2020
    /// Approver: Awaab Elamin
    /// 
    /// This manager class is used as a manager for the accessor
    /// </summary>
    public class AppointmentManager : IAppointmentManager
    {
        public IAppointmentAccessor _appointmentAccessor;

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 02/06/2020
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
        public AppointmentManager()
        {
            _appointmentAccessor = new AppointmentAccessor();
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 02/06/2020
        /// Approver: Awaab Elamin
        /// 
        /// This method is a one argument constructor
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        /// <param name="appointmentAccessor"></param>
        public AppointmentManager(IAppointmentAccessor appointmentAccessor)
        {
            _appointmentAccessor = appointmentAccessor;
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
        public int AddAppointment(Appointment appointment)
        {
            try
            {
                return _appointmentAccessor.InsertAppointment(appointment);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
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
        public int EditAppointment(Appointment oldAppointment, Appointment newAppointment)
        {
            try
            {
                return _appointmentAccessor.UpdateAppointment(oldAppointment, newAppointment);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
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
        public int RemoveAppointment(Appointment appointment)
        {
            try
            {
                return _appointmentAccessor.DeactivateAppointment(appointment);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
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
        public List<AppointmentLocationVM> RetrieveAllActiveAppointments()
        {
            try
            {
                return _appointmentAccessor.SelectAllActiveAppointments();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 4/12/2020
        /// Approver: Michael Thompson
        /// 
        /// This method retrieves an appointment by its id
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        public AppointmentLocationVM RetrieveAppointmentByID(int id)
        {
            try
            {
                return _appointmentAccessor.SelectAppointmentByID(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }
    }
}