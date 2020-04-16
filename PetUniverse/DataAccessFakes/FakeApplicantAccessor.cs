using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 2/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// This class is where we can pull fake Applicant Records from
    /// </summary>    
    public class FakeApplicantAccessor : IApplicantAccessor
    {

        private List<Applicant> applicants = null;

        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This fake method is called to get a fake ApplicantAccessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns>Fake ApplicantAccessor</returns>
        public FakeApplicantAccessor()
        {
            applicants = new List<Applicant>()
            {
                new Applicant()
                {
                    AddressLineOne = "123 Fake Street",
                    AddressLineTwo = "Apt. 2b",
                    ApplicantID = 1,
                    City = "Faketown",
                    Email = "derek@petuniverse.com",
                    FirstName = "Derek",
                    LastName = "Taylor",
                    MiddleName = "Joel",
                    PhoneNumber = "15555555555",
                    State = "IA",
                    Zipcode = "55555"
                },

                new Applicant()
                {
                    AddressLineOne = "123 Fake Street",
                    AddressLineTwo = "Apt. 2b",
                    ApplicantID = 1,
                    City = "Faketown",
                    Email = "ryan@petuniverse.com",
                    FirstName = "Ryan",
                    LastName = "Morganti",
                    MiddleName = "Bill",
                    PhoneNumber = "15555555555",
                    State = "IA",
                    Zipcode = "55555"
                },

                new Applicant()
                {
                    AddressLineOne = "123 Fake Street",
                    AddressLineTwo = "Apt. 2b",
                    ApplicantID = 1,
                    City = "Faketown",
                    Email = "matt@petuniverse.com",
                    FirstName = "Matt",
                    LastName = "Deaton",
                    MiddleName = "Franklin",
                    PhoneNumber = "15555555555",
                    State = "IA",
                    Zipcode = "55555"
                }
            };
        }

        List<JobListing> positions = new List<JobListing>
        {
            new JobListing{ JobListingID = 1},
            new JobListing{ JobListingID = 2},
            new JobListing{ JobListingID = 3}
        };


        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver:  Ryan Morganti
        /// 
        /// This fake method is called to get a fake list of Applicants
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns>Fake list of Applicants</returns>
        public List<Applicant> SelectAllApplicants()
        {
            var selectedApplicants = (from a in applicants
                                      select a).ToList();
            return selectedApplicants;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/19
        /// Approver:  Derek Taylor
        /// 
        /// Fake Accessor Method for returning a list of positions
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public List<JobListing> SelectAllJobPositions()
        {
            return positions;
        }
    }
}
