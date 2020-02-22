using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Derek Taylor
    /// DATE: 2/14/20
    /// CHECKED BY: Ryan Morganti
    /// 
    /// This class is a representation of an Applicant Record
    /// </summary>
    /// <remarks>
    /// UPDATE BY: NA
    /// UPDATE DATE: NA
    /// CHANGE:
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
