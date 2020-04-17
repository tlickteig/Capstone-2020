using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Thomas Dupuy
    /// Created: 02/06/2020
    /// Approver: Awaab Elamin
    /// 
    /// This interface class is used as an interface for the Accessor Layer
    /// </summary>
    public interface IAppointmentAccessor
    {
        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 02/06/2020
        /// Approver: Awaab Elamin
        /// 
        /// This method selects all appointments
        /// </summary>        
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        List<AppointmentLocationVM> SelectAllActiveAppointments();

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 4/12/2020
        /// Approver: Michael Thompson
        /// 
        /// This method selects an appointment by its id
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        AppointmentLocationVM SelectAppointmentByID(int id);

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 4/12/2020
        /// Approver: Michael Thompson
        /// 
        /// This method deactivates an appointment
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        int DeactivateAppointment(Appointment appointment);

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 4/12/2020
        /// Approver: Michael Thompson
        /// 
        /// This method inserts an appointment
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        int InsertAppointment(Appointment appointment);

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
        int UpdateAppointment(Appointment oldAppointment, Appointment newAppointment);
    }
}