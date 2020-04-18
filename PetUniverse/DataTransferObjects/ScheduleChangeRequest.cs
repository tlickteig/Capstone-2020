using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    /// <summary>
    ///  CREATOR: Kaleb Bachert
    ///  CREATED: 2020/4/7
    ///  APPROVER: Lane Sandburg
    ///  
    ///  ScheduleChangeRequest Data Transfer Object
    /// </summary>
    public class ScheduleChangeRequest
    {
        public int ScheduleChangeRequestID { get; set; }

        public int ShiftID { get; set; }

        public DateTime ApprovalDate { get; set; }

        public int ApprovingUserID { get; set; }

        public int RequestID { get; set; }
    }
}
