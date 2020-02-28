using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/7/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This is the View model that is used for Adoption Appointment
    /// representation.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class AdoptionAppointmentVM : AdoptionAppointment
    {
        public int CustomerID { get; set; }
        public int AnimalID { get; set; }
        public string AdoptionApplicationStatus { get; set; }
        public DateTime AdoptionApplicationRecievedDate { get; set; }
        public string LocationName { get; set; }
        public string LocationAddress1 { get; set; }
        public string LocationAddress2 { get; set; }
        public string LocationCity { get; set; }
        public string LocationState { get; set; }
        public string LocationZip { get; set; }
        public int UserID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public bool UserActive { get; set; }
        public string UserCity { get; set; }
        public string State { get; set; }
        public string UserZipCode { get; set; }
        public string AnimalName { get; set; }
        public DateTime AnimalDob { get; set; }
        public string AnimalSpeciesID { get; set; }
        public string AnimalBreed { get; set; }
        public DateTime AnimalArrivalDate { get; set; }
        public bool AnimalCurrentlyHoused { get; set; }
        public bool AnimalAdoptable { get; set; }
        public bool AnimalActive { get; set; }
    }
}
