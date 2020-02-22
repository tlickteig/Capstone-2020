using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// CREATE BY: Derek Taylor
    /// DATE: 2/14/2020
    /// CHECKED BY: Ryan Morganti
    /// 
    /// This is the interface for the ApplicantManager
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// CHANGE: NA
    /// 
    /// </remarks>
    public interface IApplicantManager
    {
        /// <summary>
        /// CREATED BY: Derek Taylor
        /// DATE: 2/14/2020
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This calls the Applicant Retrieval Data Accessor Method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <returns>List of Logs</returns>
        List<Applicant> RetrieveApplicants();
    }
}
