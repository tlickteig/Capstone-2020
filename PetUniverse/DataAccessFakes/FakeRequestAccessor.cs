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
