using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 2/9/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Data Access Inteface that is used to establish interfaces for use with 
    /// Adoption Appointment Accessor Methods
    /// </summary>
    public interface IAdoptionAppointmentAccessor
    {
        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Data Access Inteface that is used to Select Adoption Appointment VMs by active and type
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="active"></param>
        /// <param name="appointmentTypeID"></param>
        /// <returns></returns>
        List<AdoptionAppointmentVM> SelectAdoptionAppointmentsByActiveAndType(bool active, string appointmentTypeID);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Data Access Inteface that is used to Select Adoption Appointment VMs by AppointmentID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        AdoptionAppointmentVM SelectAdoptionAppointmentByAppointmentID(int appointmentID);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// Data Access Inteface that is used to inser Adoption Appointments
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="adoptionAppointment"></param>
        /// <returns></returns>
        int InsertAdoptionAppointment(AdoptionAppointment adoptionAppointment);
    }
}
