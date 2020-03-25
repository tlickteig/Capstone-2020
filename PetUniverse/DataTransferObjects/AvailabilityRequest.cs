using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/3/15
///  APPROVER: Lane Sandburg
///  
///  Request Data Transfer Object
/// </summary>

namespace DataTransferObjects
{
    public class AvailabilityRequest
    {
        public int AvailabilityRequestID { get; set; }

        public DateTime SundayStartTime { get; set; }

        public DateTime SundayEndTime { get; set; }

        public DateTime MondayStartTime { get; set; }

        public DateTime MondayEndTime { get; set; }

        public DateTime TuesdayStartTime { get; set; }

        public DateTime TuesdayEndTime { get; set; }

        public DateTime WednesdayStartTime { get; set; }

        public DateTime WednesdayEndTime { get; set; }

        public DateTime ThursdayStartTime { get; set; }

        public DateTime ThursdayEndTime { get; set; }

        public DateTime FridayStartTime { get; set; }

        public DateTime FridayEndTime { get; set; }

        public DateTime SaturdayStartTime { get; set; }

        public DateTime SaturdayEndTime { get; set; }

        public DateTime ApprovalDate { get; set; }

        public int ApprovingUserID { get; set; }

        public int RequestID { get; set; }
    }
}
