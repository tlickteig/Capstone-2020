using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/6/2020
    /// CHECKED BY: Mohamed Elamin, 02/07/2020
    /// 
    /// This class contains Data Access fakes for data pertaining to Adoption Customers.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class FakeAdoptionCustomerAccessor : IAdoptionCustomerAccessor
    {
        private List<AdoptionCustomerVM> adoptionCustomerVMs;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Mohamed Elamin, 02/07/2020
        /// 
        /// This method returns a Faked list of AdoptionCustomerVM's much the same way a data access object would.
        /// it is important to not that this method is used exclusively for unit testing and test driven development
        /// purposes.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public FakeAdoptionCustomerAccessor()
        {
            adoptionCustomerVMs = new List<AdoptionCustomerVM>()
            {
                new AdoptionCustomerVM()
                {
                    Adoptable = false,
                    AdoptionApplicationRecievedDate = DateTime.Parse("2019-10-10"),
                    CustomerAdoptionStatus = "Read to pick up animal",
                    AnimalActive = true,
                    AnimalArrivalDate = DateTime.Parse("2019-2-2"),
                    AnimalBreed = "Hound",
                    AnimalID = 1,
                    AnimalName = "FakeDog",
                    City = "City",
                    CurrentlyHoused = true,
                    CustomerID = 1,
                    Email = "Fake@Fake.com",
                    FirstName = "Fake Customer First Name",
                    LastName = "Fake Customer Last Name",
                    PhoneNumber = "1234567890",
                    State = "FS",
                    Active = true,
                    PUUserID = 1,
                    ZipCode = "12345"
                }
            };
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Mohamed Elamin, 02/07/2020
        /// 
        /// This class contains Data Access fakes for data pertaining to Adoption Customers.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<AdoptionCustomerVM> SelectAdoptionCustomersByActive(bool active)
        {
            return (from a in adoptionCustomerVMs
                    where a.Active == true
                    select a).ToList();
        }
    }
}
