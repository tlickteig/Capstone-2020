using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Thomas Dupuy
    /// Created: 02/06/2020
    /// Approver: Awaab Elamin
    /// 
    /// This interface class is used as an interface for the logic layer
    /// </summary>
    public interface IAppointmentManager
    {
        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2020/02/06
        /// Approver: Awaab Elamin
        /// 
        /// This method retrieves all appointments
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        List<AppointmentLocationVM> RetrieveAllActiveAppointments();

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
        AppointmentLocationVM RetrieveAppointmentByID(int id);

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
        int RemoveAppointment(Appointment appointment);

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
        int AddAppointment(Appointment appointment);

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
        int EditAppointment(Appointment oldAppointment, Appointment newAppointment);
    }
}
