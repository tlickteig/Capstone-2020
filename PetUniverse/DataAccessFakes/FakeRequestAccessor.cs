using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

/// <summary>
/// Creator: Kaleb Bachert
/// Created: 2/7/2020
/// Approver: Jordan Lindo
/// 
/// Fake Request Accessor Class for Unit Testing
/// </summary>

namespace DataAccessFakes
{
    public class FakeRequestAccessor : IRequestAccessor
    {
        private List<Request> requests;
        private List<TimeOffRequest> timeOffRequests;
        private List<TimeOffRequestVM> timeOffRequestVMs;
        private List<AvailabilityRequestVM> availabilityRequestVMs;

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 2/7/2020
        /// Approver: Jordan Lindo
        ///  
        /// Fake Request Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public FakeRequestAccessor()
        {
            requests = new List<Request>()
            {
                new Request()
                {
                    RequestID = 1000000,
                    RequestTypeID = "Time Off",
                    RequestingUserID = 1000001,
                    DateCreated = DateTime.Now.AddDays(-5),
                    Open = true
                },

                new Request()
                {
                    RequestID = 1000001,
                    RequestTypeID = "Time Off",
                    RequestingUserID = 1000001,
                    DateCreated = DateTime.Now.AddDays(-3),
                    Open = true
                },

                new Request()
                {
                    RequestID = 1000002,
                    RequestTypeID = "Availability Change",
                    RequestingUserID = 1000001,
                    DateCreated = DateTime.Now,
                    Open = true
                }
            };

            timeOffRequestVMs = new List<TimeOffRequestVM>()
            {
                new TimeOffRequestVM()
                {
                    TimeOffRequestID = 1000000,
                    EffectiveStart = DateTime.Now.ToString(),
                    EffectiveEnd = DateTime.Now.AddDays(1).ToString(),
                    RequestID = 1000000
                },

                new TimeOffRequestVM()
                {
                    TimeOffRequestID = 1000001,
                    EffectiveStart = DateTime.Now.ToString(),
                    EffectiveEnd = DateTime.Now.AddDays(7).ToString(),
                    RequestID = 1000001
                }
            };

            timeOffRequests = new List<TimeOffRequest>()
            {
                new TimeOffRequest()
                {
                    TimeOffRequestID = 1000000,
                    EffectiveStart = DateTime.Now,
                    EffectiveEnd = DateTime.Now.AddDays(1),
                    RequestID = 1000000
                },

                new TimeOffRequest()
                {
                    TimeOffRequestID = 1000001,
                    EffectiveStart = DateTime.Now,
                    EffectiveEnd = DateTime.Now.AddDays(7),
                    RequestID = 1000001
                }
            };

            availabilityRequestVMs = new List<AvailabilityRequestVM>()
            {
                new AvailabilityRequestVM()
                {
                    SundayStartTime = "TEST TIME",
                    SundayEndTime = "TEST TIME",
                    MondayStartTime = "TEST TIME",
                    MondayEndTime = "TEST TIME",
                    TuesdayStartTime = "TEST TIME",
                    TuesdayEndTime = "TEST TIME",
                    WednesdayStartTime = "TEST TIME",
                    WednesdayEndTime = "TEST TIME",
                    ThursdayStartTime = "TEST TIME",
                    ThursdayEndTime = "TEST TIME",
                    FridayStartTime = "TEST TIME",
                    FridayEndTime = "TEST TIME",
                    SaturdayStartTime = "TEST TIME",
                    SaturdayEndTime = "TEST TIME",
                    AvailabilityRequestID = 1000000,
                    RequestID = 1000002
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
        /// Creator: Ryan Morganti
        /// Created: 02/13/2020
        /// Approver: Derek Taylor
        ///
        /// This is the mock access method for Active Requests
        /// queried based on DepartmentID and year value of DateAcknowledged
        /// and DateCompleted
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns>List of requests</returns>
        public List<DepartmentRequest> SelectActiveRequestsByDepartmentID(string deptID)
        {
            return (from r in _requests
                    where (r.RequesteeGroupID == deptID ||
                    r.RequestorGroupID == deptID) &&
                    (r.DateAcknowledged.Year > 2000 &&
                    r.DateCompleted.Year < 2000)
                    select r).ToList();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 02/13/2020
        /// Approver: Derek Taylor
        ///
        /// Mock Access Method for selecting a list of departments based on UserID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public List<string> SelectAllEmployeeDepartments(int userID)
        {
            return (from e in EmployeeDepts
                    where e[0] == userID.ToString()
                    select e[1]).ToList();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 02/13/2020
        /// Approver: Derek Taylor
        ///
        /// This is the mock access method for Complete Requests
        /// queried based on DepartmentID and year values of DateAcknowledged
        /// and DateCompleted
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns>List of complete requests</returns>
        public List<DepartmentRequest> SelectCompleteRequestsByDepartmentID(string deptID)
        {
            return (from r in _requests
                    where (r.RequesteeGroupID == deptID ||
                    r.RequestorGroupID == deptID) &&
                    (r.DateAcknowledged.Year > 2000 &&
                    r.DateCompleted.Year > 2000)
                    select r).ToList();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 02/13/2020
        /// Approver: Derek Taylor
        ///
        /// This is the mock access method for New Requests
        /// queried based on DepartmentID and year values of DateAcknowledged
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns>List of new requests</returns>
        public List<DepartmentRequest> SelectNewRequestsByDepartmentID(string deptID)
        {
            return (from r in _requests
                    where (r.RequesteeGroupID == deptID ||
                    r.RequestorGroupID == deptID) &&
                    r.DateAcknowledged.Year < 2000
                    select r).ToList();
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 2/7/2020
        /// Approver: Jordan Lindo
        ///  
        /// Method that retrieves all the dummy Requests, for testing
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public List<Request> SelectRequestsByStatus(bool open)
        {
            return (from r in requests
                    where r.Open = open
                    select r).ToList();
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 2/7/2020
        /// Approver: Jordan Lindo
        ///  
        /// Method that approves a dummy Request, for testing
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int ApproveRequest(int requestID, int userID, string requestType)
        {
            timeOffRequests[1].ApprovingUserID = userID;
            timeOffRequests[1].ApprovalDate = DateTime.Now;

            return 1;
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 3/3/2020
        /// Approver: Lane Sandburg
        ///  
        /// Method that inserts a dummy Request, for testing
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int InsertTimeOffRequest(TimeOffRequest request, int requestingUserID)
        {
            int oldCount = timeOffRequests.Count;

            timeOffRequests.Add(request);

            return timeOffRequests.Count - oldCount;
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 3/5/2020
        /// Approver: Lane Sandburg
        ///  
        /// Method that retrieves a dummy request by ID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public TimeOffRequestVM SelectTimeOffRequestByRequestID(int RequestID)
        {
            return timeOffRequestVMs.Where(request => request.RequestID == RequestID).First();
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 3/17/2020
        /// Approver: Lane Sandburg
        ///  
        /// Method that inserts a new availability request
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int InsertAvailabilityRequest(AvailabilityRequestVM request, int requestingUserID)
        {
            int oldCount = availabilityRequestVMs.Count;

            availabilityRequestVMs.Add(request);

            return availabilityRequestVMs.Count - oldCount;
        }
    }
}
