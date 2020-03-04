using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     DATE: 2020-02-07
    ///     CHECKED BY: Zoey McDonald
    ///     Class for acessing the database for shift records
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public class VolunteerShiftAccessor : IVolunteerShiftAccessor
    {
        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-07
        ///     CHECKED BY: Zoey McDonald
        ///     Method for adding a shif to the DB
        /// </summary>
        /// <param name="shift">Shift Object to be added</param>
        /// <returns>Number of rows affected</returns>
        public int AddShift(VolunteerShift shift)
        {
            //Declare variables
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_volunteer_shift");

            //Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Add parameters
            cmd.Parameters.Add("@ShiftDescription", SqlDbType.NVarChar, 1080);
            cmd.Parameters.Add("@ShiftTitle", SqlDbType.NVarChar, 500);
            cmd.Parameters.Add("@ShiftDate", SqlDbType.Date);
            cmd.Parameters.Add("@ShiftStartTime", SqlDbType.Time);
            cmd.Parameters.Add("@ShiftEndTime", SqlDbType.Time);
            cmd.Parameters.Add("@IsSpecialEvent", SqlDbType.Bit);
            cmd.Parameters.Add("@Recurrance", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@ShiftNotes", SqlDbType.NVarChar, 1080);
            cmd.Parameters.Add("@ScheduleID", SqlDbType.Int);

            //Set parameter values
            cmd.Parameters["@ShiftDescription"].Value = shift.ShiftDescription;
            cmd.Parameters["@ShiftTitle"].Value = shift.ShiftTitle;
            cmd.Parameters["@ShiftDate"].Value = shift.VolunteerShiftDate;
            cmd.Parameters["@ShiftStartTime"].Value = shift.ShiftStartTime;
            cmd.Parameters["@ShiftEndTime"].Value = shift.ShiftEndTime;
            cmd.Parameters["@Recurrance"].Value = shift.Recurrance;
            cmd.Parameters["@ShiftNotes"].Value = shift.ShiftNotes;
            cmd.Parameters["@ScheduleID"].Value = shift.ScheduleID;
            cmd.Parameters["@IsSpecialEvent"].Value = shift.IsSpecialEvent;

            //Try to execute the query
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
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        ///     Method for removing a shift from the DB
        /// </summary>
        /// <param name="shiftID">ShiftID to be removed</param>
        /// <returns>Number of rows affected</returns>
        public int RemoveShift(int shiftID)
        {
            //Declare variables
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_volunteer_shift");

            //Setup cmd object
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            //Add Parameters
            cmd.Parameters.Add("@ShiftID", SqlDbType.Int);
            cmd.Parameters["@ShiftID"].Value = shiftID;

            //Try to execute the query
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
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-17
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <returns>A list of shifts from the database</returns>
        public List<VolunteerShift> SelectAllShifts()
        {
            //Declare variables
            List <VolunteerShift> shifts = new List<VolunteerShift>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_volunteer_shifts");

            //Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Try to execute the query
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VolunteerShift shift = new VolunteerShift();
                    shift.VolunteerShiftID = Convert.ToInt32(reader.GetValue(0));
                    shift.ShiftDescription = Convert.ToString(reader.GetValue(1));
                    shift.ShiftTitle = Convert.ToString(reader.GetValue(2));
                    shift.ShiftStartTime = (TimeSpan)(reader.GetValue(3));
                    shift.ShiftEndTime = (TimeSpan)(reader.GetValue(4));
                    shift.Recurrance = Convert.ToString(reader.GetValue(5));
                    shift.IsSpecialEvent = Convert.ToBoolean(reader.GetValue(6));
                    shift.ShiftNotes = Convert.ToString(reader.GetValue(7));
                    shift.VolunteerShiftDate = Convert.ToDateTime(reader.GetValue(8));
                    shift.ScheduleID = Convert.ToInt32(reader.GetValue(9));
                    shifts.Add(shift);
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

            return shifts;
        }

        public VolunteerShift SelectShift(int shiftID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-10
        ///     CHECKED BY: Zoey McDonald
        ///     Method for editing a shift inside the DB
        /// </summary>
        /// <param name="oldShift">The shift to be updated</param>
        /// <param name="newShift">The new shift</param>
        /// <returns>Number of rows affected</returns>
        public int UpdateShift(VolunteerShift oldShift, VolunteerShift newShift)
        {
            //Declare variables
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_volunteer_shift");

            //Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Add Parameters
            cmd.Parameters.Add("@VolunteerShiftID", SqlDbType.Int);
            cmd.Parameters.Add("@ShiftDescription", SqlDbType.NVarChar, 1080);
            cmd.Parameters.Add("@ShiftDate", SqlDbType.Date);
            cmd.Parameters.Add("@ShiftTitle", SqlDbType.NVarChar, 500);
            cmd.Parameters.Add("@ShiftStartTime", SqlDbType.Time);
            cmd.Parameters.Add("@ShiftEndTime", SqlDbType.Time);
            cmd.Parameters.Add("@Recurrance", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@IsSpecialEvent", SqlDbType.Bit);
            cmd.Parameters.Add("@ShiftNotes", SqlDbType.NVarChar, 1080);
            cmd.Parameters.Add("@ScheduleID", SqlDbType.Int);

            //Set Parameter values
            cmd.Parameters["@VolunteerShiftID"].Value = oldShift.VolunteerShiftID;
            cmd.Parameters["@ShiftDescription"].Value = newShift.ShiftDescription;
            cmd.Parameters["@ShiftDate"].Value = newShift.VolunteerShiftDate;
            cmd.Parameters["@ShiftTitle"].Value = newShift.ShiftTitle;
            cmd.Parameters["@ShiftStartTime"].Value = newShift.ShiftStartTime;
            cmd.Parameters["@ShiftEndTime"].Value = newShift.ShiftEndTime;
            cmd.Parameters["@Recurrance"].Value = newShift.Recurrance;
            cmd.Parameters["@IsSpecialEvent"].Value = newShift.IsSpecialEvent;
            cmd.Parameters["@ShiftNotes"].Value = newShift.ShiftNotes;
            cmd.Parameters["@ScheduleID"].Value = newShift.ScheduleID;

            //Try to execute the query
            try
            {
                conn.Open();
                rows = Convert.ToInt32(cmd.ExecuteScalar());
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
    }
}
