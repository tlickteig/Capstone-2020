using DataAccessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;


namespace DataAccessFakes
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/10/2020
    /// CHECKED BY: NA
    /// 
    /// This class contains Data Access fakes for data pertaining to Adoption Appointments.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class FakeAdoptionAppointmentAccessor : IAdoptionAppointmentAccessor
    {
        private List<AdoptionAppointmentVM> adoptionAppointmentVMs;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/10/2020
        /// CHECKED BY: NA
        /// 
        /// This is the no-argument constructor for this class. It builds a fake
        /// data accessor object to be used for testing purposes
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public FakeAdoptionAppointmentAccessor()
        {
            adoptionAppointmentVMs = new List<AdoptionAppointmentVM>()
            {
                new AdoptionAppointmentVM()
                {
                    AppointmentID = 000,
                    AdoptionApplicationID = 000,
                    AppointmentTypeID = "Meet and Greet",
                    AppointmentDateTime = DateTime.Parse("2020-10-10"),
                    Notes = "Fake",
                    Decision = "Fake",
                    LocationID = 000,
                    AppointmentActive = true,
                    CustomerID = 000,
                    AnimalID = 000,
                    AdoptionApplicationStatus = "good",
                    AdoptionApplicationRecievedDate = DateTime.Parse("2020-10-10"),
                    LocationName = "Fake",
                    LocationAddress1 = "111 Fake st.",
                    LocationAddress2 = "Apt #3",
                    LocationCity = "Fake Town",
                    LocationState = "AA",
                    LocationZip = "00000",
                    UserID = 000,
                    UserFirstName = "First",
                    UserLastName = "Last",
                    UserPhoneNumber = "1234567890",
                    UserEmail = "Fake@fake.fake",
                    UserActive = true,
                    UserCity = "Fakesville",
                    State = "BB",
                    UserZipCode = "12345",
                    AnimalName = "FakeDog",
                    AnimalDob = DateTime.Parse("2020-10-10"),
                    AnimalSpeciesID = "Dog",
                    AnimalBreed = "Chihuahua",
                    AnimalArrivalDate = DateTime.Parse("2020-10-10"),
                    AnimalCurrentlyHoused = true,
                    AnimalAdoptable = true,
                    AnimalActive = true
                }
            };
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/10/2020
        /// CHECKED BY: NA
        /// 
        /// This method returns a fake list of Adoption customer VM's. This method will
        /// be used exclusively for unit testing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <param name="appointmentTypeID"></param>
        /// <returns></returns>
        public List<AdoptionAppointmentVM> SelectAdoptionAppointmentsByActiveAndType(bool active, string appointmentTypeID)
        {
            return (from a in adoptionAppointmentVMs
                    where a.AppointmentActive == true 
                    && a.AppointmentTypeID == appointmentTypeID
                    select a).ToList();
        }
    }
}
