using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 2/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// 
    /// Interface for accessing Applicants
    /// </summary>
    public interface IApplicantAccessor
    {

        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// 
        /// Method is used to retrieve all applicant records
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<Applicant> SelectAllApplicants();

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/19
        /// Approver: Derek Taylor
        /// 
        /// 
        /// Method is used to retrieve all Positions at PetUniverse
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<JobListing> SelectAllJobPositions();
    }
}