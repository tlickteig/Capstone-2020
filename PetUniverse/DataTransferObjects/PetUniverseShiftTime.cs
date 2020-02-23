using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Lane Sandburg
    /// Created: 02/07/2019
    /// Approver: Alex Diers
    /// 
    /// ShiftTime Data Transfer Object
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks> 
    public class PetUniverseShiftTime
    {
        public int ShiftTimeID { get; set; }
        public String DepartmentID { get; set; }
        public String StartTime { get; set; }
        public String EndTime { get; set; }
    }
}
