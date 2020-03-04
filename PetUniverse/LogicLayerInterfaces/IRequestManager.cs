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

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// Interface method for selecting New DepartmentRequests
        /// based on list of DepartmentIDs
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptIDs"></param>
        /// <returns></returns>
        List<DepartmentRequest> RetrieveNewRequestsByDepartmentID(List<string> deptIDs);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver:  Derek Taylor
        ///
        /// Interface method for selecting Active DepartmentRequests
        /// based on list of DepartmentIDs
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptIDs"></param>
        /// <returns></returns>
        List<DepartmentRequest> RetrieveActiveRequestsByDepartmentID(List<string> deptIDs);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// Interface method for selecting Complete DepartmentRequests
        /// based on list of DepartmentIDs
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptIDs"></param>
        /// <returns></returns>
        List<DepartmentRequest> RetrieveCompleteRequestsByDepartmentID(List<string> deptIDs);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/22
        /// Approver: Derek Taylor
        ///
        /// Interface method for selecting DepartmentIDs based on a UserID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<string> RetrieveAllDepartmentIDsByUserID(int userId);



    }
}