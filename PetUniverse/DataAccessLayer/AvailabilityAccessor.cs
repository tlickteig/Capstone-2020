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
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/15
///  APPROVER: Lane Sandburg
///  
///  Accessor Class for Availability
/// </summary>
namespace DataAccessLayer
{
    public class AvailabilityAccessor : IAvailabilityAccessor
    {

		/// <summary>
		///  CREATOR: Kaleb Bachert
		///  CREATED: 2020/4/15
		///  APPROVER: Lane Sandburg
		///  
		///  This method retrieves all Users' Avilabilities
		/// </summary>
		/// <remarks>
		/// UPDATER: NA
		/// UPDATED: NA
		/// UPDATE: NA
		/// 
		/// </remarks>
		public List<Availability> SelectAllUsersAvailability()
		{
			List<Availability> availabilities = new List<Availability>();

			var conn = DBConnection.GetConnection();
			var cmd = new SqlCommand("sp_select_all_users_availabilities", conn);
			cmd.CommandType = CommandType.StoredProcedure;

			try
			{
				conn.Open();
				var reader = cmd.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						Availability availability = new Availability();

						availability.UserID = reader.GetInt32(0);
						availability.DayOfWeek = reader.GetString(1);
						availability.StartTime = reader.GetString(2);
						availability.EndTime = reader.GetString(3);

						availabilities.Add(availability);
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

			return availabilities;
		}
	}
}
