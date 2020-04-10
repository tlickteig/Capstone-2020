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
        List<Appointment> SelectAllAppointments();
    }
}