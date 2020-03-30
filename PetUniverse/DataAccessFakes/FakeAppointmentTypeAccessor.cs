using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/18/2020
    /// CHECKED BY: 
    /// 
    /// Fakes for testing Appointment type manager class
    /// </summary>
    public class FakeAppointmentTypeAccessor : IAppointmentTypeAccessor
    {
        List<string> _appointmentTypes;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/18/2020
        /// CHECKED BY: 
        /// 
        /// the default constructor for this class
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public FakeAppointmentTypeAccessor()
        {
            _appointmentTypes = new List<string>()
            {
                "In Home Inspection",
                "Meet and Greet",
                "Interview"
            };
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/18/2020
        /// CHECKED BY: 
        /// 
        /// A fake get all appointments method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public List<string> SelectAllAppointmentTypes()
        {
            return _appointmentTypes;
        }
    }
}
