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
    /// CHECKED BY: NA
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
        List<AdoptionAppointmentVM> SelectAdoptionAppointmentsByActiveAndType(bool active, string appointmentTypeID);
    }
}
