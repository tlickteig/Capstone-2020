using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/1
///  APPROVER: Lane Sandburg
///  
///  Accessor Class for Requests
/// </summary>
namespace DataAccessLayer
{
    public class ShiftAccessor : IShiftAccessor
    {
		/// <summary>
		///  CREATOR: Kaleb Bachert
		///  CREATED: 2020/4/1
		///  APPROVER: Lane Sandburg
		///  
		///  This method retrieves all scheduled Shifts with ShiftTimes from the Database by user.
		/// 
		/// </summary>
		/// <remarks>
		/// UPDATER: NA
		/// UPDATED: NA
		/// UPDATE: NA
		/// 
		/// </remarks>
		public List<ShiftVM> SelectShiftsByUser(int userID)
        {
			List<ShiftVM> shiftVMs = new List<ShiftVM>();

			var conn = DBConnection.GetConnection();
			var cmd = new SqlCommand("sp_select_shifts_by_user", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("UserID", userID);

			try
			{
				conn.Open();
				var reader = cmd.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						ShiftVM shiftVM = new ShiftVM();

						shiftVM.ShiftID = reader.GetInt32(0);
						shiftVM.ShiftTimeID = reader.GetInt32(1);
						shiftVM.Date = reader.GetDateTime(3).ToShortDateString();
						shiftVM.EmployeeWorking = reader.GetInt32(4);
						shiftVM.Department = reader.GetString(6);
						shiftVM.StartTime = reader.GetString(7);
						shiftVM.EndTime = reader.GetString(8);

						shiftVMs.Add(shiftVM);
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

			return shiftVMs;
		}

		/// <summary>
		///  CREATOR: Kaleb Bachert
		///  CREATED: 2020/4/15
		///  APPROVER: Lane Sandburg
		///  
		///  This method retrieves all scheduled Shifts with ShiftTimes from the Database on the specified day.
		/// </summary>
		/// <remarks>
		/// UPDATER: NA
		/// UPDATED: NA
		/// UPDATE: NA
		/// 
		/// </remarks>
		/// <param name="date"></param>
		public List<ShiftVM> SelectShiftsByDay(DateTime date)
		{
			List<ShiftVM> shiftVMs = new List<ShiftVM>();

			var conn = DBConnection.GetConnection();
			var cmd = new SqlCommand("sp_select_shifts_by_day", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("Date", date.ToShortDateString());

			try
			{
				conn.Open();
				var reader = cmd.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						ShiftVM shiftVM = new ShiftVM();

						shiftVM.EmployeeWorking = reader.GetInt32(0);
						shiftVM.Date = reader.GetDateTime(1).ToShortDateString();
						shiftVM.StartTime = reader.GetString(2);
						shiftVM.EndTime = reader.GetString(3);

						shiftVMs.Add(shiftVM);
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

			return shiftVMs;
		}

		/// <summary>
		///  CREATOR: Kaleb Bachert
		///  CREATED: 2020/4/15
		///  APPROVER: Lane Sandburg
		///  
		///  This method retrieves a User's scheduled hours for a given Schedule
		/// </summary>
		/// <remarks>
		/// UPDATER: NA
		/// UPDATED: NA
		/// UPDATE: NA
		/// 
		/// </remarks>
		/// <param name="userID"></param>
		/// <param name="dateInSchedule"></param>
		public ScheduleWithHoursWorked SelectScheduleHoursByUserAndDate(int userID, DateTime dateInSchedule)
		{
			ScheduleWithHoursWorked scheduleHours = new ScheduleWithHoursWorked();

			var conn = DBConnection.GetConnection();
			var cmd = new SqlCommand("sp_select_schedule_hours_by_user_and_date", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("UserID", userID);
			cmd.Parameters.AddWithValue("DateInSchedule", dateInSchedule);

			try
			{
				conn.Open();
				var reader = cmd.ExecuteReader();

				if (reader.HasRows)
				{
					if (reader.Read())
					{
						scheduleHours.ScheduleID = reader.GetInt32(0);
						scheduleHours.ScheduleStartDate = reader.GetDateTime(1);
						scheduleHours.ScheduleEndDate = reader.GetDateTime(2);
						scheduleHours.FirstWeekHours = Convert.ToDouble(reader.GetDecimal(3));
						scheduleHours.SecondWeekHours = Convert.ToDouble(reader.GetDecimal(4));
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

			return scheduleHours;
		}

		/// <summary>
		///  CREATOR: Kaleb Bachert
		///  CREATED: 2020/4/16
		///  APPROVER: Lane Sandburg
		///  
		///  This method updates the Employee Working for a given shift
		/// </summary>
		/// <remarks>
		/// UPDATER: NA
		/// UPDATED: NA
		/// UPDATE: NA
		/// 
		/// </remarks>
		/// <param name="shiftID"></param>
		/// <param name="newUserWorking"></param>
		/// <param name="oldUserWorking"></param>
		public int UpdateShiftUserWorking(int shiftID, int newUserWorking, int oldUserWorking)
		{
			int rowsAffected = 0;

			var conn = DBConnection.GetConnection();
			var cmd = new SqlCommand("sp_update_shift_user_working", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("ShiftID", shiftID);
			cmd.Parameters.AddWithValue("NewUserWorking", newUserWorking);
			cmd.Parameters.AddWithValue("OldUserWorking", oldUserWorking);

			try
			{
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				conn.Close();
			}

			return rowsAffected;
		}

		/// <summary>
		///  CREATOR: Kaleb Bachert
		///  CREATED: 2020/4/16
		///  APPROVER: Lane Sandburg
		///  
		///  This method updates the hours worked for an Employee on a given week of a given schedule by a given amount
		/// </summary>
		/// <remarks>
		/// UPDATER: NA
		/// UPDATED: NA
		/// UPDATE: NA
		/// 
		/// </remarks>
		/// <param name="userID"></param>
		/// <param name="scheduleID"></param>
		/// <param name="weekNumber"></param>
		/// <param name="changeAmount"></param>
		public int UpdateEmployeeHoursWorked(int userID, int scheduleID, int weekNumber, double changeAmount)
		{
			int rowsAffected = 0;

			var conn = DBConnection.GetConnection();
			var cmd = new SqlCommand("sp_update_employee_hours_worked", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("UserID", userID);
			cmd.Parameters.AddWithValue("ScheduleID", scheduleID);
			cmd.Parameters.AddWithValue("WeekNumber", weekNumber);
			cmd.Parameters.AddWithValue("ChangeAmount", changeAmount);

			try
			{
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				conn.Close();
			}

			return rowsAffected;
		}
	}
}
