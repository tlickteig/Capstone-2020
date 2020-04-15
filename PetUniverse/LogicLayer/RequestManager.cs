using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Creator: Kaleb Bachert
///  Created: 2020/2/7
///  Approver: Zach Behrensmeyer
///  
///  Manager Class for Requests
/// </summary>

namespace LogicLayer
{
	public class RequestManager : IRequestManager
	{
		private IRequestAccessor _requestAccessor;

		/// <summary>
		///  Creator: Kaleb Bachert
		///  Created: 2/9/2020
		///  Approver: Zach Behrensmeyer
		///  
		///  Default Constructor for instantiating Accessor
		/// </summary>
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// 
		/// </remarks>
		public RequestManager()
		{
			_requestAccessor = new RequestAccessor();
		}

		/// <summary>
		///  Creator: Kaleb Bachert
		///  Created: 2/9/2020
		///  Approver: Zach Behrensmeyer
		///  
		///  Constructor for passing specific Accessor class
		/// </summary>
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// 
		/// </remarks>
		/// <param name="requestAccessor"></param>

		public RequestManager(IRequestAccessor requestAccessor)
		{
			_requestAccessor = requestAccessor;
		}

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/9
        ///  APPROVER: Jordan Lindo
        ///  
        ///  This method calls the SelectAllRequests method from the Accessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<Request> RetrieveRequestsByStatus(bool open)
        {
            try
            {
                return _requestAccessor.SelectRequestsByStatus(open);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Requests not found.", ex);
            }
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/19
        ///  APPROVER: NA
        ///  
        ///  This method calls the ApproveRequest method from the Accessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        public int ApproveRequest(int requestID, int userID, string requestType)
        {
            try
            {
                return _requestAccessor.ApproveRequest(requestID, userID, requestType);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Could not approve!", ex);
            }
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// This method is for performing multiple calls on the DataAccessLayer
        /// while iterating through a list of DepartmentIDs to select Active Requests,
        /// and merging the queried Lists<> before returning the final collection
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptIDs"></param>
        /// <returns></returns>
        public List<DepartmentRequest> RetrieveActiveRequestsByDepartmentID(List<string> deptIDs)
        {
            List<DepartmentRequest> requests = new List<DepartmentRequest>();
            try
            {
                foreach (string ID in deptIDs)
                {
                    requests = requests.Concat(_requestAccessor.SelectActiveRequestsByDepartmentID(ID)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to load requests", ex);
            }
            return requests;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/22
        /// Approver: Derek Taylor
        ///
        /// This method is for retrieving a list of departments linked to an employee
        /// based on that employee's userID.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> RetrieveAllDepartmentIDsByUserID(int userId)
        {
            List<string> depts = new List<string>();

            try
            {
                depts = _requestAccessor.SelectAllEmployeeDepartments(userId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to load departments", ex);
            }

            return depts;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// This method is for performing multiple calls on the DataAccessLayer
        /// while iterating through a list of DepartmentIDs to select Completed Requests,
        /// and merging the queried Lists<> before returning the final collection
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptIDs"></param>
        /// <returns></returns>
        public List<DepartmentRequest> RetrieveCompleteRequestsByDepartmentID(List<string> deptIDs)
        {
            List<DepartmentRequest> requests = new List<DepartmentRequest>();
            try
            {
                foreach (string ID in deptIDs)
                {
                    requests = requests.Concat(_requestAccessor.SelectCompleteRequestsByDepartmentID(ID)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to load requests", ex);
            }
            return requests;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// This method is for performing multiple calls on the DataAccessLayer
        /// while iterating through a list of DepartmentIDs to select New Requests,
        /// and merging the queried Lists<> before returning the final collection
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptIDs"></param>
        /// <returns></returns>
        public List<DepartmentRequest> RetrieveNewRequestsByDepartmentID(List<string> deptIDs)
        {
            List<DepartmentRequest> requests = new List<DepartmentRequest>();
            try
            {
                foreach (string ID in deptIDs)
                {

                    requests = requests.Concat(_requestAccessor.SelectNewRequestsByDepartmentID(ID)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to load requests", ex);
            }
            return requests;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/3
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method calls the InsertTimeOffRequest method from the Accessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        public bool AddTimeOffRequest(TimeOffRequest request, int requestingEmployeeID)
        {
            try
            {
                return 1 == _requestAccessor.InsertTimeOffRequest(request, requestingEmployeeID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/7
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method calls the SelectTimeOffRequestByRequestID method from the Accessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        public TimeOffRequestVM RetrieveTimeOffRequestByRequestID(int requestID)
        {
            try
            {
                return _requestAccessor.SelectTimeOffRequestByRequestID(requestID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/17
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method calls the InsertTimeOffRequest method from the Accessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        public bool AddAvailabilityRequest(AvailabilityRequestVM request, int requestingEmployeeID)
        {
            try
            {
                return 1 == _requestAccessor.InsertAvailabilityRequest(request, requestingEmployeeID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not added.", ex);
            }
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver:  Derek Taylor
        ///
        /// Method for calling on the DataAccessLayer to retrieve all request types.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <returns></returns>
        public List<string> RetriveAllRequestTypes()
        {
            List<string> types = new List<string>();

            try
            {
                types = _requestAccessor.SelectAllRequestTypes();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to load request types.", ex);
            }

            return types;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver:  Derek Taylor
        ///
        /// Method for calling on the DataAccessLayer to retrieve employee names and associated employee numbers.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <returns></returns>
        public List<string[]> RetrieveEmployeeNames()
        {
            List<string[]> names = new List<string[]>();
            try
            {
                names = _requestAccessor.SelectAllEmployeeNames();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to load employee info", ex);
            }
            return names;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver:  Derek Taylor
        ///
        /// Method for calling on the DataAccessLayer to retrieve all DepartmentRequest responses based on the requestID.
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="requestID"></param>
        /// <returns></returns>
        public List<RequestResponse> RetrieveAllResponsesByRequestID(int requestID)
        {
            List<RequestResponse> responses;

            try
            {
                responses = _requestAccessor.SelectAllRequestResponsesByRequestID(requestID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to load request responses.", ex);
            }

            return responses;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/16
        /// Approver:  Derek Taylor
        ///
        /// Method for calling on the DataAccessLayer update a DepartmentRequest status from 'new' to 'acknowledged'
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
        public int SetDeptRequestStatusToAcknowledged(int userID, int requestID)
        {
            try
            {
                return _requestAccessor.UpdateDepartmentRequestStatusToAcknowledged(userID, requestID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update request status.", ex);
            }
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/16
        /// Approver:  Derek Taylor
        ///
        /// Method for calling on the DataAccessLayer update a DepartmentRequest status from 'acknowledged' to 'completed'
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
        public int SetDeptRequestStatusToCompleted(int userID, int requestID)
        {
            try
            {
                return _requestAccessor.UpdateDepartmentRequestStatusToCompleted(userID, requestID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update request status.", ex);
            }
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/18
        /// Approver:  Derek Taylor
        ///
        /// Method for editing an existing DepartmentRequest's details.
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
        public int EditDepartmentRequestDetails(int userID, int requestID, string oldRequestedGroupID, string oldRequestTopic,
            string oldRequestBody, string newRequestedGroupID, string newRequestTopic, string newRequestBody)
        {
            try
            {
                return _requestAccessor.UpdateDepartmentRequest(userID, requestID, oldRequestedGroupID, oldRequestTopic, oldRequestBody,
                                                                newRequestedGroupID, newRequestTopic, newRequestBody);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update request status.", ex);
            }
        }
    }
}
