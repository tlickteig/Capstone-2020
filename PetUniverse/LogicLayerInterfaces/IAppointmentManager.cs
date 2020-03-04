using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

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
        /// This method retrieve all appointments
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        List<Appointment> RetrieveAllAppointments();
    }
}
