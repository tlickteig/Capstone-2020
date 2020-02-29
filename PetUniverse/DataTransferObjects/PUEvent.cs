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
    /// CHECKED BY:
    /// 
    /// The DTO class to retrieve data for the PUEvent
    /// </summary>
    public class PUEvent
    {
        public int EventID { get; set; }
        public int CreatedByID { get; set; }
        public DateTime DateCreated { get; set; }
        public string EventName { get; set; }
        public string EventTypeID { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string BannerPath { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }


        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY:
        /// 
        /// The no-argument constructor for an event
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        public PUEvent() { }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY:
        /// 
        /// The full-argument constructor for an event
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="createdByID"></param>
        /// <param name="dateCreated"></param>
        /// <param name="eventName"></param>
        /// <param name="eventTypeID"></param>
        /// <param name="eventDateTime"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipcode"></param>
        /// <param name="eventPictureFileName"></param>
        /// <param name="status"></param>
        /// <param name="description"></param>
        public PUEvent(int eventID, int createdByID, DateTime dateCreated, string eventName, string eventTypeID,
            DateTime eventDateTime, string address, string city, string state, string zipcode, string eventPictureFileName,
            string status, string description)
        {
            EventID = eventID;
            CreatedByID = createdByID;
            DateCreated = dateCreated;
            EventName = eventName;
            EventTypeID = eventTypeID;
            EventDateTime = eventDateTime;
            Address = address;
            City = city;
            State = state;
            Zipcode = zipcode;
            BannerPath = eventPictureFileName;
            Status = status;
            Description = description;
        }
    }
}
