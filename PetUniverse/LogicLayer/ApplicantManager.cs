using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// NAME: Derek Taylor
    /// DATE: 2/14/2020
    /// CHECKED BY: Ryan Morganti
    /// 
    /// This class is handles the logic for Applicants.
    /// </summary>
    /// <remarks>
    /// UPDATE BY: NA
    /// UPDATE DATE: NA
    /// CHANGE: NA
    /// 
    /// </remarks>
    public class ApplicantManager : IApplicantManager
    {
        private IApplicantAccessor _applicantAccessor;
        /// <summary>
        /// NAME: Derek Taylor
        /// DATE: 2/14/2020
        /// CHECKED BY: Ryan Morganti
        /// 
        /// No argument Constructor for ApplicantManager
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE:
        /// 
        /// </remarks>
        public ApplicantManager()
        {
            _applicantAccessor = new ApplicantAccessor();
        }
        /// <summary>
        /// NAME: Derek Taylor
        /// DATE 2/14/2020
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This Constructor accesses the fake data for Applicants
        /// </summary>
        /// <remarks>
        /// UPDATE BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="applicantAccessor"></param>
        public ApplicantManager(IApplicantAccessor applicantAccessor)
        {
            _applicantAccessor = applicantAccessor;
        }
        /// <summary>
        /// NAME : Derek Taylor
        /// DATE: 2/14/2020
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This method calls the ApplicantAccessor to retrieve all apllicants
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
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
