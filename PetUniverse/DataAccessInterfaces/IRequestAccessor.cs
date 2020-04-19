using DataTransferObjects;
using System.Collections.Generic;

/// <summary>
///  Creator: Kaleb Bachert
///  Created: 2/7/2020
///  Approver: Jordan Lindo
///  Approver: Zach Behrensmeyer 
/// 
///  Interface for RequestAccessor
/// </summary>

namespace DataAccessInterfaces
{
    public interface IRequestAccessor
    {

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 2/7/2020
        /// Approver: Jordan Lindo
        ///  
        /// Interface method for retrieving all requests.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<RequestVM> SelectRequestsByStatus(bool open);

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 2/7/2020
        /// Approver: Jordan Lindo
        ///  
        /// Interface method for approving a request.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        int ApproveRequest(int requestID, int userID, string requestType);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 02/13/2020
        /// Approver: Derek Taylor
        ///
        /// This interface method is for selecting New DepartmentRequests
        /// based on a single DepartmentID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        List<DepartmentRequest> SelectNewRequestsByDepartmentID(string deptID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 02/13/2020
        /// Approver: Derek Taylor
        ///
        /// This interface method is for selecting Active DepartmentRequests
        /// based on a single DepartmentID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        List<DepartmentRequest> SelectActiveRequestsByDepartmentID(string deptID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 02/13/2020
        /// Approver: Derek Taylor
        ///
        /// This interface method is for selecting Completed DepartmentRequests
        /// based on a single DepartmentID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        List<DepartmentRequest> SelectCompleteRequestsByDepartmentID(string deptID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 02/22/2020
        /// Approver: Derek Taylor
        ///
        /// This interface method is for selecting an Employee's departments
        /// by their userID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<string> SelectAllEmployeeDepartments(int userID);

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 3/3/2020
        /// Approver: Jordan Lindo
        ///  
        ///  Interface method for creating a timeoff request.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        int InsertTimeOffRequest(TimeOffRequest request, int requestingUserID);

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 3/17/2020
        /// Approver: Jordan Lindo
        ///  
        ///  Interface method for creating an availability request.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="request"></param>
        /// <param name="requestingUserID"></param>
        int InsertAvailabilityRequest(AvailabilityRequestVM request, int requestingUserID);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/7
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for creating a schedule change request.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA     
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestingUserID"></param>
        int InsertScheduleChangeRequest(ScheduleChangeRequest request, int requestingUserID);

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 3/7/2020
        /// Approver: Jordan Lindo
        ///  
        ///  Interface method for getting the TimeOffRequest associated with a Request
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        TimeOffRequestVM SelectTimeOffRequestByRequestID(int requestID);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/9
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for getting the ScheduleChangeRequest associated with a Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        ScheduleChangeRequestVM SelectScheduleChangeRequestByRequestID(int requestID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver:  Derek Taylor
        ///
        /// This interface method is for selecting all Request Types into a List.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <returns></returns>
        List<string> SelectAllRequestTypes();

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver:  Derek Taylor
        ///
        /// This interface method is for selecting all Employee names and userIDs into a List of arrays.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <returns></returns>
        List<string[]> SelectAllEmployeeNames();

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver:  Derek Taylor
        ///
        /// This interface method is for selecting all DepartmentRequest responses associated with a requestID.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="requestID"></param>
        /// <returns></returns>
        List<RequestResponse> SelectAllRequestResponsesByRequestID(int requestID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/16
        /// Approver:  Derek Taylor
        ///
        /// This interface method is for updating a new DepartmentRequest's status to 'Acknowledged'.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="userId"></param>
        /// <param name="requestID"></param>
        /// <returns></returns>
        int UpdateDepartmentRequestStatusToAcknowledged(int userId, int requestID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/16
        /// Approver:  Derek Taylor
        ///
        /// This interface method is for updating an acknowledged DepartmentRequest's status to 'Completed'.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="requestID"></param>
        /// <returns></returns>
        int UpdateDepartmentRequestStatusToCompleted(int userID, int requestID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/18
        /// Approver:  Derek Taylor
        ///
        /// This interface method is for updating a DepartmentRequest's fields.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="requestID"></param>
        /// <param name="oldRequestedGroupID"></param>
        /// <param name="oldRequestTopic"></param>
        /// <param name="oldRequestBody"></param>
        /// <param name="newRequestedGroupID"></param>
        /// <param name="newRequestTopic"></param>
        /// <param name="newRequestBody"></param>
        /// <returns></returns>
        int UpdateDepartmentRequest(int userID, int requestID, string oldRequestedGroupID, string oldRequestTopic,
            string oldRequestBody, string newRequestedGroupID, string newRequestTopic, string newRequestBody);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/2
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for inserting Active Time Off, called once a request is approved
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>

        int InsertActiveTimeOff(ActiveTimeOff activeTimeOff);
    }
}
