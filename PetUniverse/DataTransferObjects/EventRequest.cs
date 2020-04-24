namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Steve Coonrod
    /// DATE: 2020-02-06
    /// CHECKED BY: Ryan Morganti
    /// 
    /// The DTO class to retrieve data for the EventRequest
    /// </summary>
    public class EventRequest
    {
        public int EventID { get; set; }
        public int RequestID { get; set; }
        public int ReviewerID { get; set; }
        public string DisapprovalReason { get; set; }
        public int DesiredVolunteers { get; set; }
        public bool Active { get; set; }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// The no-argument constructor for an EventRequest
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        public EventRequest() { }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// The full-argument constructor for an EventRequest
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="requestID"></param>
        /// <param name="reviewerID"></param>
        /// <param name="disapprovalReason"></param>
        /// <param name="desiredVolunteers"></param>
        /// <param name="active"></param>
        public EventRequest(int eventID, int requestID, int reviewerID, string disapprovalReason, int desiredVolunteers, bool active)
        {
            EventID = eventID;
            RequestID = requestID;
            ReviewerID = reviewerID;
            DisapprovalReason = disapprovalReason;
            DesiredVolunteers = desiredVolunteers;
            Active = active;
        }

    }
}
