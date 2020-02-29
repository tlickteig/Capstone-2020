using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/2/7
///  APPROVER: Jordan Lindo
///  
///   Fake Request Accessor Class for Unit Testing
/// </summary>

namespace DataAccessFakes
{
    public class FakeRequestAccessor : IRequestAccessor
    {
        private List<RequestVM> requests;

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/7
        ///  APPROVER: Jordan Lindo
        ///  
        ///   Fake Request Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public FakeRequestAccessor()
        {
            requests = new List<RequestVM>()
            {
                new RequestVM()
                {
                    RequestID = 1000000,
                    RequestTypeID = "Time Off",
                    EffectiveStart = DateTime.Now.AddDays(14).ToString(),
                    EffectiveEnd = DateTime.Now.AddDays(21).ToString(),
                    ApprovalDate = DateTime.Now.ToString(),
                    RequestingEmployeeID = 1000001,
                    ApprovingUserID = 1000000
                },
                new RequestVM()
                {
                    RequestID = 1000001,
                    RequestTypeID = "Schedule Change",
                    EffectiveStart = DateTime.Now.AddDays(1).ToString(),
                    RequestingEmployeeID = 1000001
                }
            };
        }

        private List<DepartmentRequest> _requests = new List<DepartmentRequest>()
        {
            new DepartmentRequest
            {
                RequesteeGroupID = "Management",
                RequestorGroupID = "Inventory",
                DateAcknowledged = DateTime.Now,
                DateCompleted = DateTime.Now.AddDays(2)
            },
            new DepartmentRequest
            {
                RequesteeGroupID = "CustomerService",
                RequestorGroupID = "Inventory",
                DateAcknowledged = DateTime.Now,
                DateCompleted = DateTime.Now.AddDays(2)
            },
            new DepartmentRequest
            {
                RequesteeGroupID = "Management",
                RequestorGroupID = "Management",
                DateAcknowledged = DateTime.Now,
                DateCompleted = DateTime.Now.AddDays(2)
            },
            new DepartmentRequest
            {
                RequesteeGroupID = "CustomerService",
                RequestorGroupID = "Inventory",
                DateAcknowledged = DateTime.Now
            },
            new DepartmentRequest
            {
                RequesteeGroupID = "CustomerService",
                RequestorGroupID = "CustomerService",
                DateAcknowledged = DateTime.Now
            },
            new DepartmentRequest
            {
                RequesteeGroupID = "Management",
                RequestorGroupID = "CustomerService"
            },
            new DepartmentRequest
            {
                RequesteeGroupID = "CustomerService",
                RequestorGroupID = "Inventory"
            }

        };

        List<string[]> EmployeeDepts = new List<string[]>
        {
            new string[] {"100000", "Management"},
            new string[] {"100001", "CustomerService"},
            new string[] {"100001", "Management"},
            new string[] {"100001", "Inventory"}
        };

        /// <summary>
        /// NAME: Ryan Morganti
        /// DATE: 2020-02-13
        /// CHECKED BY: Derek Taylor
        ///
        /// This is the mock access method for Active Requests
        /// queried based on DepartmentID and year value of DateAcknowledged
        /// and DateCompleted
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        ///
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public List<DepartmentRequest> SelectActiveRequestsByDepartmentID(string deptID)
        {
            var requests = (from r in _requests
                            where (r.RequesteeGroupID == deptID ||
                            r.RequestorGroupID == deptID) &&
                            (r.DateAcknowledged.Year > 2000 &&
                            r.DateCompleted.Year < 2000)
                            select r).ToList();

            return requests;
        }

        /// <summary>
        /// NAME: Ryan Morganti
        /// DATE: 2020-02-22
        /// CHECKED BY: Derek Taylor
        ///
        /// Mock Access Method for selecting a list of departments based on UserID
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        ///
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public List<string> SelectAllEmployeeDepartments(int userID)
        {
            var departments = (from e in EmployeeDepts
                               where e[0] == userID.ToString()
                               select e[1]).ToList();
            return departments;
        }


        /// <summary>
        /// NAME: Ryan Morganti
        /// DATE: 2020-02-13
        /// CHECKED BY: Derek Taylor
        ///
        /// This is the mock access method for Complete Requests
        /// queried based on DepartmentID and year values of DateAcknowledged
        /// and DateCompleted
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        ///
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public List<DepartmentRequest> SelectCompleteRequestsByDepartmentID(string deptID)
        {
            var requests = (from r in _requests
                            where (r.RequesteeGroupID == deptID ||
                            r.RequestorGroupID == deptID) &&
                            (r.DateAcknowledged.Year > 2000 &&
                            r.DateCompleted.Year > 2000)
                            select r).ToList();

            return requests;
        }

        /// <summary>
        /// NAME: Ryan Morganti
        /// DATE: 2020-02-13
        /// CHECKED BY: Derek Taylor
        ///
        /// This is the mock access method for New Requests
        /// queried based on DepartmentID and year values of DateAcknowledged
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        ///
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public List<DepartmentRequest> SelectNewRequestsByDepartmentID(string deptID)
        {
            var requests = (from r in _requests
                            where (r.RequesteeGroupID == deptID ||
                            r.RequestorGroupID == deptID) &&
                            r.DateAcknowledged.Year < 2000
                            select r).ToList();

            return requests;
        }


        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/7
        ///  APPROVER: Jordan Lindo
        ///  
        ///   Method that retrieves all the dummy Requests, for testing
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<RequestVM> SelectAllRequests()
        {
            return (from r in requests
                    select r).ToList();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/7
        ///  APPROVER: Jordan Lindo
        ///  
        ///   Method that approves a dummy Request, for testing
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public int ApproveRequest(int requestID, int userID)
        {
            requests[1].ApprovingUserID = userID;
            requests[1].ApprovalDate = DateTime.Now.ToString();

            return 1;
        }




    }
}
