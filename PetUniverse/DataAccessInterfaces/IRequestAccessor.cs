using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

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
        List<Request> SelectRequestsByStatus(bool open);

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
    }
}