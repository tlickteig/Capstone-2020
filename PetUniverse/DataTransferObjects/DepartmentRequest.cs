using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Ryan Morganti
    /// Created: 2020/02/06
    /// Approver:Derek Taylor
    /// 
    /// Class for storing DepartmentRequest data pulled from the Data Store 
    /// Inherits from Class Request
    /// </summary>
    public class DepartmentRequest : Request
    {
        public int RequestorID { get; set; }
        public string RequestorGroupID { get; set; }
        public string RequesteeGroupID { get; set; }
        public DateTime DateAcknowledged { get; set; }
        public int AcknowledgingEmployee { get; set; }
        public DateTime DateCompleted { get; set; }
        public int CompletedEmployee { get; set; }
        public string Subject { get; set; }
        public string Topic { get; set; }
        public string Body { get; set; }

    }
}
