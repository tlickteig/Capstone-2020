using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    ///  CREATOR: Kaleb Bachert
    ///  CREATED: 2020/3/5
    ///  APPROVER: Lane Sandburg
    ///  
    ///  TimeOffRequest Data Transfer Object View Model
    /// </summary>
    public class TimeOffRequestVM
    {
        public int TimeOffRequestID { get; set; }

        public string EffectiveStart { get; set; }

        public string EffectiveEnd { get; set; }

        public string ApprovalDate { get; set; }

        public int ApprovingUserID { get; set; }

        public int RequestID { get; set; }
    }
}
