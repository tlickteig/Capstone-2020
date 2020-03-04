using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Creator: Kaleb Bachert
///  Created: 2/9/2020
///  Approver: Zach Behrensmeyer
///  
///  Accessor Class for Requests
/// </summary>
/// <remarks>
/// Updater: NA
/// Updated: NA
/// Update: NA
/// 
/// </remarks>

namespace DataAccessLayer
{
	public class RequestAccessor : IRequestAccessor
	{
		/// <summary>
		///  Creator: Kaleb Bachert
		///  Created: 2/9/2020
		///  Approver: Zach Behrensmeyer
		///  
		///  This method retrieves all Requests from the Database.
		///  
		///  Reader can't Get values if they're null, 
		///  if a value is null, it's saved as an empty string or 0
		/// 
		/// </summary>
		/// <remarks>
		/// Updater: Kaleb Bachert
		/// Updated: 2/14/2020
		/// Update: Converts the Request to a View Model to allow blank DateTime fields
		/// 
		/// </remarks>
		public List<RequestVM> SelectAllRequests()
		{
			List<RequestVM> requests = new List<RequestVM>();

			var conn = DBConnection.GetConnection();
			var cmd = new SqlCommand("sp_select_all_requests", conn);
			cmd.CommandType = CommandType.StoredProcedure;

			try
			{
				conn.Open();
				var reader = cmd.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						RequestVM request = new RequestVM();

						request.RequestID = reader.GetInt32(0);
						request.RequestTypeID = reader.GetString(1);
						request.EffectiveStart = reader.GetDateTime(2).ToString();
						if (!reader.IsDBNull(3))
						{
							request.EffectiveEnd = reader.GetDateTime(3).ToString();
						}
						else
						{
							request.EffectiveEnd = "";
						}
						if (!reader.IsDBNull(4))
						{
							request.ApprovalDate = reader.GetDateTime(4).ToString();
						}
						else
						{
							request.ApprovalDate = "";
						}
						request.RequestingEmployeeID = reader.GetInt32(5);
						if (!reader.IsDBNull(6))
						{
							request.ApprovingUserID = reader.GetInt32(6);
						}
						else
						{
							request.ApprovingUserID = 0;
						}

						requests.Add(request);
					}
					reader.Close();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				conn.Close();
			}

			return requests;
		}

		/// <summary>
		///  Creator: Kaleb Bachert
		///  Created: 2/19/2020
		///  Approver: Zach Behrensmeyer
		///  
		///  This method approves a currently unapproved, and open request in the database
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
			int requestsChanged = 0;

			var conn = DBConnection.GetConnection();
			var cmd = new SqlCommand("sp_approve_request", conn);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("RequestID", requestID);
			cmd.Parameters.AddWithValue("UserID", userID);

			try
			{
				conn.Open();
				requestsChanged = Convert.ToInt32(cmd.ExecuteScalar());
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				conn.Close();
			}

			return requestsChanged;
		}

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approvor: Derek Taylor
        ///
        /// Method for pulling Active Department Requests based on DepartmentIDs
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public List<DepartmentRequest> SelectActiveRequestsByDepartmentID(string deptID)
        {
            List<DepartmentRequest> requests = new List<DepartmentRequest>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_active_requests_by_departmentID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", deptID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DepartmentRequest newRequest = new DepartmentRequest();

                        newRequest.RequestID = reader.GetInt32(0);
                        newRequest.DateCreated = reader.GetDateTime(1);
                        newRequest.RequestTypeID = reader.GetString(2);
                        newRequest.RequestorID = reader.GetInt32(3);
                        newRequest.RequestorGroupID = reader.GetString(4);
                        newRequest.RequesteeGroupID = reader.GetString(5);
                        newRequest.DateAcknowledged = reader.GetDateTime(6);
                        newRequest.AcknowledgingEmployee = reader.GetInt32(7);
                        newRequest.Subject = reader.GetString(8);
                        newRequest.Topic = reader.GetString(9);
                        newRequest.Body = reader.GetString(10);

                        requests.Add(newRequest);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return requests;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/22
        /// Approver:  Derek Taylor
        ///
        /// Method for querying a list of departmentIDs associated with a userID 
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<string> SelectAllEmployeeDepartments(int userID)
        {
            List<string> depts = new List<string>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("select_all_departments_by_userID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string dept = reader.GetString(0);
                        depts.Add(dept);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return depts;

        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        ///
        /// Method for pulling Completed Department Requests based on DepartmentIDs
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public List<DepartmentRequest> SelectCompleteRequestsByDepartmentID(string deptID)
        {
            List<DepartmentRequest> requests = new List<DepartmentRequest>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_completed_requests_by_departmentID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", deptID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DepartmentRequest newRequest = new DepartmentRequest();

                        newRequest.RequestID = reader.GetInt32(0);
                        newRequest.DateCreated = reader.GetDateTime(1);
                        newRequest.RequestTypeID = reader.GetString(2);
                        newRequest.RequestorID = reader.GetInt32(3);
                        newRequest.RequestorGroupID = reader.GetString(4);
                        newRequest.RequesteeGroupID = reader.GetString(5);
                        newRequest.DateAcknowledged = reader.GetDateTime(6);
                        newRequest.AcknowledgingEmployee = reader.GetInt32(7);
                        newRequest.DateCompleted = reader.GetDateTime(8);
                        newRequest.CompletedEmployee = reader.GetInt32(9);
                        newRequest.Subject = reader.GetString(10);
                        newRequest.Topic = reader.GetString(11);
                        newRequest.Body = reader.GetString(12);

                        requests.Add(newRequest);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return requests;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approvor: Derek Taylor
        ///
        /// Method for pulling New Department Requests based on DepartmentIDs
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public List<DepartmentRequest> SelectNewRequestsByDepartmentID(string deptID)
        {
            List<DepartmentRequest> requests = new List<DepartmentRequest>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_new_requests_by_departmentID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", deptID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DepartmentRequest newRequest = new DepartmentRequest();

                        newRequest.RequestID = reader.GetInt32(0);
                        newRequest.DateCreated = reader.GetDateTime(1);
                        newRequest.RequestTypeID = reader.GetString(2);
                        newRequest.RequestorID = reader.GetInt32(3);
                        newRequest.RequestorGroupID = reader.GetString(4);
                        newRequest.RequesteeGroupID = reader.GetString(5);
                        newRequest.Subject = reader.GetString(6);
                        newRequest.Topic = reader.GetString(7);
                        newRequest.Body = reader.GetString(8);

                        requests.Add(newRequest);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return requests;
        }



    }
}
