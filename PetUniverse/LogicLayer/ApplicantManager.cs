using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 2/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// This class is handles the logic for Applicants.
    /// </summary>
    public class ApplicantManager : IApplicantManager
    {
        private IApplicantAccessor _applicantAccessor;

        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// No argument Constructor for ApplicantManager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public ApplicantManager()
        {
            _applicantAccessor = new ApplicantAccessor();
        }
        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This Constructor accesses the fake data for Applicants
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="applicantAccessor"></param>
        public ApplicantManager(IApplicantAccessor applicantAccessor)
        {
            _applicantAccessor = applicantAccessor;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/19
        /// Approver: Derek Taylor
        /// 
        /// This method calls the ApplicantAccessor to retrieve all positions at PetUniverse 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public List<JobListing> RetrieveAllPositions()
        {
            try
            {
                return _applicantAccessor.SelectAllJobPositions();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Positions not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This method calls the ApplicantAccessor to retrieve all apllicants
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// 
        /// </summary>        
        /// <returns>List of Applicantss</returns>
        public List<Applicant> RetrieveApplicants()
        {
            try
            {
                return _applicantAccessor.SelectAllApplicants();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }
    }
}
