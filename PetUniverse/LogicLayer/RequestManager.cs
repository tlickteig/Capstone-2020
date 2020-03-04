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
		///  Creator: Kaleb Bachert
		///  Created: 2/9/2020
		///  Approver: Zach Behrensmeyer
		///  
		///  This method calls the SelectAllRequests method from the Accessor
		/// </summary>
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// 
		/// </remarks>
		public List<RequestVM> RetrieveAllRequests()
		{
			try
			{
				return _requestAccessor.SelectAllRequests();
			}

			catch (Exception ex)
			{
				throw new ApplicationException("Requests not found.", ex);
			}
		}

		/// <summary>
		///  Creator: Kaleb Bachert
		///  Created: 2/9/2020
		///  Approver: Zach Behrensmeyer
		///  
		///  This method calls the ApproveRequest method from the Accessor
		/// </summary>
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// 
		/// </remarks>
		/// <param name="requestID"></param>
		/// <param name="userID"></param>
		public int ApproveRequest(int requestID, int userID)
		{
			try
			{
				return _requestAccessor.ApproveRequest(requestID, userID);
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



    }
}
