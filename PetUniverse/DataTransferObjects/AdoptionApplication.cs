using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2/5/2020
    /// Approver: Austin Gee, 2/7/2020
    ///
    /// This Class for creating  the properties of Adoption Applications.
    /// </summary>
    public class AdoptionApplication
    {
        public int AdoptionApplicationID { get; set; }
        public string CustomerEmail { get; set; }
        public string AnimalName { get; set; }
        public string Status { get; set; }
        public DateTime RecievedDate { get; set; }
    }
}
