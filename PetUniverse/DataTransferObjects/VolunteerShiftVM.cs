using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     DATE: 2020-02-05
    ///     CHECKED BY: Zoey McDonald
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public class VolunteerShiftVM : VolunteerShift
    {
        public string VolunteerFirstName { get; set; }

        public string VolunteerLastName { get; set; }

        public string TaskDescription { get; set; }
    }
}
