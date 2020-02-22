using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME: Derek Taylor
    /// DATE: 2/14/2020
    /// CHECKED BY: Ryan Morganti
    /// 
    /// 
    /// Interface for accessing Applicants
    /// </summary>
    /// <remarks>
    /// UPDATE BY: NA
    /// UPDATED DATE: NA
    /// CHANGE: NA
    /// </remarks>
    public interface IApplicantAccessor
    {
        /// <summary>
        /// NAME: Derek Taylor
        /// DATE: 2/14/2020
        /// CHECKED BY: Ryan Morganti
        /// 
        /// 
        /// Method is used to retrieve all applicant records
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// </remarks>
        /// <returns></returns>
        List<Applicant> SelectAllApplicants();
    }
}
