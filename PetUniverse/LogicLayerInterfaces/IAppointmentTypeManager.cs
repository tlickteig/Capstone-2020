using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/18/2020
    /// CHECKED BY: 
    /// 
    /// Interface for interacting with the data access layer Appointment type methods
    /// </summary>
    public interface IAppointmentTypeManager
    {
        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/18/2020
        /// CHECKED BY: 
        /// 
        /// Retrives all appointment types
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        List<string> RetrieveAllAppontmentTypes();
    }
}
