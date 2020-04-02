using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// 
    /// Created By: Steve Coonrod
    /// Date: 3/08/2020
    /// Checked By:
    /// 
    /// The data transfer object to represent an Event's View Model data
    /// 
    /// Updated By:
    /// Updated On:
    /// 
    /// </summary>
    public class EventApprovalVM
    {
        public string EventName { get; set; }
        public DateTime DateCreated { get; set; }
        public string EventTypeID { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string BannerPath { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string RequestedByName { get; set; }
        public string DisapprovalReason { get; set; }
        public string ReviewerName { get; set; }
        public int DesiredVolunteers { get; set; }
    }
}