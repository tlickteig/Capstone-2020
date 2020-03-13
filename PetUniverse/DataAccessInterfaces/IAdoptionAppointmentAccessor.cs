using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

 namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/9/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// Data Access Inteface that is used to establish interfaces for use with 
    /// Adoption Appointment Accessor Methods
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public interface IAdoptionAppointmentAccessor
    {
        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/5/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Data Access Inteface that is used to Select Adoption Appointment VMs by active and type
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <param name="appointmentTypeID"></param>
        /// <returns></returns>
        List<AdoptionAppointmentVM> SelectAdoptionAppointmentsByActiveAndType(bool active, string appointmentTypeID);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/5/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Data Access Inteface that is used to Select Adoption Appointment VMs by AppointmentID
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        AdoptionAppointmentVM SelectAdoptionAppointmentByAppointmentID(int appointmentID);
    }
}
