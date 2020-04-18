using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Creator: Kaleb Bachert
///  Created: 2020/2/14
///  Approver: Jordan Lindo
///  Approver: Zach Behrensmeyer
///  
///  Request Data Transfer Object View Model
/// </summary>
/// 
namespace DataTransferObjects
{
    public class RequestVM
    {
        public int RequestID { get; set; }
        public string RequestTypeID { get; set; }
        public DateTime DateCreated { get; set; }
        public String EffectiveStart { get; set; }
        public String EffectiveEnd { get; set; }
        public String ApprovalDate { get; set; }
        public int RequestingEmployeeID { get; set; }
        public string RequestingEmail { get; set; }
        public int ApprovingUserID { get; set; }
        public bool Open { get; set; }
    }
}