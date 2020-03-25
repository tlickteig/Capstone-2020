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
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/9
        ///  APPROVER: Jordan Lindo
        ///  
        ///  Interface method for retrieving all requests
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        List<Request> RetrieveRequestsByStatus(bool open);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/19
        ///  APPROVER: NA
        ///  
        ///  Interface method for approving a request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        int ApproveRequest(int requestID, int userID, string requestType);

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

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/3
        ///  APPROVER: NA
        ///  
        ///  Interface method for adding a TimeOff Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        bool AddTimeOffRequest(TimeOffRequest request, int RequestingEmployeeID);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/7
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for retrieving a TimeOffRequest by RequestID
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        TimeOffRequestVM RetrieveTimeOffRequestByRequestID(int requestID);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/17
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for adding an availability Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="request"></param>
        /// <param name="requestingEmployeeID"></param>
        bool AddAvailabilityRequest(AvailabilityRequestVM request, int requestingEmployeeID);
    }
}
