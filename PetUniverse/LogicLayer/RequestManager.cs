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
	}
}
