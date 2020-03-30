using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/18/2020
    /// CHECKED BY: 
    /// 
    /// This is a simple interface for methods that have to do with Appointment Type data accessor
    /// </summary>
    public interface IAppointmentTypeAccessor
    {
        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/18/2020
        /// CHECKED BY: 
        /// 
        /// Selects all Appointment types
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        List<string> SelectAllAppointmentTypes();
    }
}
