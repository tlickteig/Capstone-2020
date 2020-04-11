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
    /// Creator: Austin Gee
    /// Created: 3/30/2020
    /// Approver: Micheal Thompson, 4/9/2020
    ///
    /// This Class for creation a fake Adoption Applications which will used 
    /// for testing Logic layer methodes.
    /// </summary>
    public class FakeApplicationAccessor : IAdoptionApplicationAccessor
    {
        List<ApplicationVM> _applicationVMs;

        public FakeApplicationAccessor()
        {
            _applicationVMs = new List<ApplicationVM>
            {
                new ApplicationVM
                {
                    AdoptionApplicationID = 000,
                    AnimalActive = true,
                    AnimalBreed = "Fake",
                    AnimalID = 000,
                    AnimalName = "Fake",
                    AnimalSpeciesID = "Fake",
                    ApplicationActive = true,
                    CustomerEmail = "Fake@fake.com",
                    RecievedDate = DateTime.Now,
                    Status = "Fake"
                },
                new ApplicationVM
                {
                    AdoptionApplicationID = 001,
                    AnimalActive = true,
                    AnimalBreed = "Fake",
                    AnimalID = 001,
                    AnimalName = "Fake",
                    AnimalSpeciesID = "Fake",
                    ApplicationActive = true,
                    CustomerEmail = "Fake",
                    RecievedDate = DateTime.Now,
                    Status = "Fake"
                },
                new ApplicationVM
                {
                    AdoptionApplicationID = 002,
                    AnimalActive = true,
                    AnimalBreed = "Fake",
                    AnimalID = 002,
                    AnimalName = "Fake",
                    AnimalSpeciesID = "Fake",
                    ApplicationActive = true,
                    CustomerEmail = "Fake",
                    RecievedDate = DateTime.Now,
                    Status = "Fake"
                }
            };
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/10/2020
        /// CHECKED BY: Micheal Thompson, 4/9/2020
        /// 
        /// This method returns a fake list of Adoption applications by email. This method will
        /// be used exclusively for unit testing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public List<ApplicationVM> SelectAdoptionApplicationsByEmail(string email)
        {
            return (from a in _applicationVMs
                    where a.CustomerEmail == email
                    select a).ToList();
        }
    }
}
