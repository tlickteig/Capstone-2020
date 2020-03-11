using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAM Austin Gee
    /// DATE: 2/17/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This class contains the inteface methods for Adoption appointments
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public interface IAdoptionAppointmentManager
    {

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/5/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Interface for retrieveing an adoption vm by active and 
        /// type from the data access layer
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
        List<AdoptionAppointmentVM> RetrieveAdoptionAppointmentsByActiveAndType(bool active, string appointmentTypeID);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/5/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Interface for retrieveing an adoption vm by Appointment ID 
        /// from the data access layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        AdoptionAppointmentVM RetrieveAdoptionAppointmentByAppointmentID(int appointmentID);
    }
}



