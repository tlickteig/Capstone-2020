using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Steve Coonrod
    /// DATE: 2020-02-06
    /// CHECKED BY: Ryan Morganti
    /// 
    /// The DTO class to retrieve data for the EventType
    /// </summary>
    public class EventType
    {
        public string EventTypeID { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// The no-argument constructor for an EventType
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        public EventType() { }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// The full-argument constructor for an EventType
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventTypeID"></param>
        /// <param name="description"></param>
        public EventType(string eventTypeID, string description)
        {
            EventTypeID = eventTypeID;
            Description = description;
        }
    }
}
