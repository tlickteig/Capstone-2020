using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME:Lane Sandburg
    /// DATE: 02/07/2019
    /// CHECKED BY:Alex Diers
    /// 
    /// ShiftTime Data Transfer Object
    /// </summary>
    /// <remarks>
    /// UPDATED BY:NA
    /// UPDATED DATE:
    /// WHAT WAS CHANGED:
    /// </remarks> 
    public class PetUniverseShiftTime
    {
        public int ShiftTimeID { get; set; }
        public String DepartmentID { get; set; }
        public String StartTime { get; set; }
        public String EndTime { get; set; }
    }
}
