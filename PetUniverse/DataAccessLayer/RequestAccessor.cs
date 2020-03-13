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
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/9
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method retrieves all Requests from the Database by status.
        ///  
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATER: Kaleb Bachert
        /// UPDATED: 2020/3/6
        /// UPDATE: Changed the Request DTO, updated fields here
        /// 
        /// </remarks>
        public List<Request> SelectRequestsByStatus(bool open)
        {
            List<Request> requests = new List<Request>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_requests_by_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("OpenStatus", open);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Request request = new Request();

                        request.RequestID = reader.GetInt32(0);
                        request.RequestTypeID = reader.GetString(1);
                        request.RequestingUserID = reader.GetInt32(2);
                        request.DateCreated = reader.GetDateTime(3);

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
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/19
        ///  APPROVER: NA
        ///  
        ///  This method approves a currently unapproved, and open request in the database
        /// </summary>
        /// <remarks>
        /// UPDATER: Kaleb Bachert
        /// UPDATED: 2020/3/7
        /// UPDATE: Changes Stored Procedure name based on requestType
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        public int ApproveRequest(int requestID, int userID, string requestType)
        {
            int requestsChanged = 0;

            var conn = DBConnection.GetConnection();
            SqlCommand cmd;

            switch (requestType)
            {
                case "Time Off":
                    cmd = new SqlCommand("sp_approve_time_off_request", conn);
                    break;
                default:
                    throw new ApplicationException("Request Type has no method for approving requests.");
            }
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

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/3
        ///  APPROVER: NA
        ///  
        ///  This method creates a Time Off Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        public int InsertTimeOffRequest(TimeOffRequest request, int requestingUserID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_time_off_request", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EffectiveStart", request.EffectiveStart);
            cmd.Parameters.AddWithValue("@EffectiveEnd", request.EffectiveEnd);
            cmd.Parameters.AddWithValue("@RequestingUserID", requestingUserID);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/7
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method gets a TimeOffRequest by RequestID
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="requestID"></param>
        /// <param name="userID"></param>
        public TimeOffRequestVM SelectTimeOffRequestByRequestID(int requestID)
        {
            TimeOffRequestVM request = null;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_time_off_request_by_requestid", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("RequestID", requestID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    {
                        request = new TimeOffRequestVM();

                        request.TimeOffRequestID = reader.GetInt32(0);
                        request.EffectiveStart = reader.GetDateTime(1).ToString();
                        request.EffectiveEnd = reader.IsDBNull(2) ? "" : reader.GetDateTime(2).ToString();
                        request.ApprovalDate = reader.IsDBNull(3) ? "" : reader.GetDateTime(3).ToString();
                        request.ApprovingUserID = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                        request.RequestID = reader.GetInt32(5);
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

            return request;
        }

    }
}
