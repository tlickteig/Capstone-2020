namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 2/14/20
    /// Approver: Ryan Morganti
    /// 
    /// This class is a representation of an Applicant Record
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class Applicant
    {
        public int ApplicantID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }
}
