using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    ///  Creator: Kaleb Bachert
    ///  Created: 2020/2/7
    ///  Approver: Jordan Lindo
    ///  Approver: Zach Behrensmeyer
    ///  
    ///  Request Data Transfer Object
    /// </summary>

    public class Request
    {
        public int RequestID { get; set; }
        public string RequestTypeID { get; set; }
        public DateTime EffectiveStart { get; set; }
        public DateTime EffectiveEnd { get; set; }
        public DateTime ApprovalDate { get; set; }
        public int RequestingEmployeeID { get; set; }
        public int ApprovingUserID { get; set; }
        public bool Open { get; set; }
    }
}
