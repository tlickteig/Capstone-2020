using DataTransferObjects;
using System.Collections.Generic;

/// <summary>
///  Creator: Kaleb Bachert
///  Created: 2/7/2020
///  Approver: Zach Behrensmeyer
///  
///  Interface for the Request Manager Class
/// </summary>

namespace LogicLayer
{
    public interface IRequestManager
    {
        /// <summary>
		///  Creator: Kaleb Bachert
		///  Created: 2/9/2020
        ///  Approver: Jordan Lindo
		///  Approver: Zach Behrensmeyer
        ///  
        ///  Interface method for retrieving all requests
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        List<RequestVM> RetrieveAllRequests();

        /// <summary>
		///  Creator: Kaleb Bachert
		///  Created: 2/19/2020
		///  Approver: Zach Behrensmeyer
        ///  
        ///  Interface method for approving a request
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        int ApproveRequest(int requestID, int userID);
    }
}