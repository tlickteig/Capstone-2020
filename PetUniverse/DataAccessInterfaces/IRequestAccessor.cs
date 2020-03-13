using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

/// <summary>
///  Creator: Kaleb Bachert
///  CREATED: 2/7/2020
///  APPROVER: Jordan Lindo
///  Approver: Zach Behrensmeyer 
/// 
///  Interface for RequestAccessor
/// </summary>

namespace DataAccessInterfaces
{
    public interface IRequestAccessor
    {
        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/7
        ///  APPROVER: Jordan Lindo
        ///  
        ///  Interface method for retrieving all requests.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        List<Request> SelectRequestsByStatus(bool open);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/7
        ///  APPROVER: Jordan Lindo
        ///  
        ///  Interface method for approving a request.
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
        /// This interface method is for selecting New DepartmentRequests
        /// based on a single DepartmentID
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        List<DepartmentRequest> SelectNewRequestsByDepartmentID(string deptID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// This interface method is for selecting Active DepartmentRequests
        /// based on a single DepartmentID
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        List<DepartmentRequest> SelectActiveRequestsByDepartmentID(string deptID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver:  Derek Taylor
        ///
        /// This interface method is for selecting Completed DepartmentRequests
        /// based on a single DepartmentID
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        List<DepartmentRequest> SelectCompleteRequestsByDepartmentID(string deptID);

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/22
        /// Approver:  Derek Taylor
        ///
        /// This interface method is for selecting an Employee's departments
        /// by their userID.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<string> SelectAllEmployeeDepartments(int userID);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/3
        ///  APPROVER: NA
        ///  
        ///  Interface method for creating a timeoff request.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        int InsertTimeOffRequest(TimeOffRequest request, int requestingUserID);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/7
        ///  APPROVER: NA
        ///  
        ///  Interface method for getting the TimeOffRequest associated with a Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        TimeOffRequestVM SelectTimeOffRequestByRequestID(int requestID);
    }
}
