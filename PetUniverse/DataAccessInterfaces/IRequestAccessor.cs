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
        ///  Creatpr: Kaleb Bachert
        ///  Created: 2/7/2020
        ///  Approver: Jordan Lindo
        ///  Approver: Zach Behrensmeyer 
        /// 
        ///  Interface method for retrieving all requests.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        List<RequestVM> SelectAllRequests();

        /// <summary>
        ///  Creator: Kaleb Bachert
        ///  Created: 2020/2/7
        ///  Approver: Jordan Lindo
        ///  Approver: Zach Behrensmeyer 
        /// 
        ///  Interface method for approving a request.
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


    }
}
