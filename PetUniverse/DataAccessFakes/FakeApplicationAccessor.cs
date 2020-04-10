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
    /// Approver: Mohammed Elamin
    ///
    /// This Class for creation a fake Adoption Applications which will used 
    /// for testing Logic layer methodes.
    /// </summary>
    public class FakeApplicationAccessor : IAdoptionApplicationAccessor
    {
        List<ApplicationVM> _applicationVMs;

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/30/2020
        /// Approver: Mohammed Elamin
        ///
        /// No argument constructor for the FakeApplicationAccessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
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
        /// Creator: Austin Gee
        /// Created: 3/30/2020
        /// Approver: Mohammed Elamin
        ///
        /// This method is for returning adoption applications by email
        /// </summary>
        /// <param name="email"></param>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public List<ApplicationVM> SelectAdoptionApplicationsByEmail(string email)
        {
            return (from a in _applicationVMs
                    where a.CustomerEmail == email
                    select a).ToList();
        }
    }
}
