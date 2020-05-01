using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

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
        List<Application> _applications;

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

            _applications = new List<Application>
            {
                new Application
                {
                    AdoptionApplicationID = 000,
                    AnimalID = 000,
                    RecievedDate = DateTime.Parse("11/12/1984"),
                    CustomerEmail = "Fake@fake.com",
                    Status = "Fake",
                    ApplicationActive = true
                },
                new Application
                {
                    AdoptionApplicationID = 001,
                    AnimalID = 000,
                    RecievedDate = DateTime.Parse("11/12/1984"),
                    CustomerEmail = "Fake1@fake.com",
                    Status = "Fake",
                    ApplicationActive = true
                },
                new Application
                {
                    AdoptionApplicationID = 002,
                    AnimalID = 000,
                    RecievedDate = DateTime.Parse("11/12/1984"),
                    CustomerEmail = "Fake2@fake.com",
                    Status = "Fake",
                    ApplicationActive = true
                },
            };
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/22/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This method returns a deactivates a fake adoption application
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns></returns>
        public int DeactivateAdoptionApplication(int adoptionApplicationID)
        {
            int rows = 0;
            foreach(var a in _applicationVMs)
            {
                if(a.AdoptionApplicationID == adoptionApplicationID)
                {
                    a.ApplicationActive = false;
                    rows += 1;
                }
            }
            return rows;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/22/2020
        /// CHECKED BY: 
        /// 
        /// This inserts an allication into applications
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="application"></param>
        /// <returns></returns>
        public int InsertAdoptionApplication(Application application)
        {
            int rows = 0;
            try
            {
                _applications.Add(application);
                rows += 1;
            }
            catch (Exception)
            {

                throw;
            }
            return rows;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/11/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This method returns a fake Adoption application by id. This method will
        /// be used exclusively for unit testing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns></returns>
        public ApplicationVM SelectAdoptionApplicationByID(int adoptionApplicationID)
        {
            return (from a in _applicationVMs
                    where a.AdoptionApplicationID == adoptionApplicationID
                    select a).First();
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
        public List<ApplicationVM> SelectAdoptionApplicationsByEmail(string email, bool active)
        {
            return (from a in _applicationVMs
                    where a.CustomerEmail == email
                    && a.ApplicationActive == active
                    select a).ToList();
        }
    }
}
