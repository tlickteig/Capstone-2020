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

    public interface IApplicantManager
    {
        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This calls the Applicant Retrieval Data Accessor Method
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns>List of Logs</returns>
        List<Applicant> RetrieveApplicants();
    }
}
