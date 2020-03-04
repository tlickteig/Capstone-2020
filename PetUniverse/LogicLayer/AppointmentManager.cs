using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessInterfaces;
using DataAccessFakes;

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
            _appointmentAccessor = new FakeAppointmentAccessor();
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
        public List<Appointment> RetrieveAllAppointments()
        {
            try
            {
                return _appointmentAccessor.SelectAllAppointments();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }
    }
}
