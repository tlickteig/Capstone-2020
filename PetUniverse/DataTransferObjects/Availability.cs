namespace DataTransferObjects
{
    /// <summary>
    ///  CREATOR: Chase Schulte
    ///  CREATED: 2020/03/28
    ///  APPROVER: Kaleb Bachert
    ///  
    ///  Availability Data Transfer Object
    /// </summary>
    public class Availability
    {
        public int AvailabilityID { get; set; }

        public int UserID { get; set; }

        public string DayOfWeek { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public bool Active { get; set; }
    }
}
