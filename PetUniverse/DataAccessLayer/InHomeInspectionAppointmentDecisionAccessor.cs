using DataAccessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver:  Awaab Elamin, 2020/02/21
    ///
    /// This Class for accessing InHome Inspection Appointment Decision Accessor
    /// data in the database.
    /// </summary>
    public class InHomeInspectionAppointmentDecisionAccessor : IInHomeInspectionAppointmentDecisionAccessor
    {
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:  Awaab Elamin, 2020/02/21
        /// 
        /// This method used to get Adoption Applications Aappointments ByAppointmen
        ///  tType
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        public List<HomeInspectorAdoptionAppointmentDecision> SelectAdoptionApplicationsAappointmentsByAppointmentType()
        {
            List<HomeInspectorAdoptionAppointmentDecision> inHomeInspectionAppointmentDecisions = new List<HomeInspectorAdoptionAppointmentDecision>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_inHomeInspectionAppointments_by_AppointmentType", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        var inHomeInspectionAppointmentDecision = new HomeInspectorAdoptionAppointmentDecision();



                        inHomeInspectionAppointmentDecision.AppointmentID = reader.GetInt32(0);
                        inHomeInspectionAppointmentDecision.AdoptionApplicationID = reader.GetInt32(1);
                        inHomeInspectionAppointmentDecision.AppointmentTypeID = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                        {
                            inHomeInspectionAppointmentDecision.DateTime = reader.GetDateTime(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            inHomeInspectionAppointmentDecision.Notes = reader.GetString(4);
                        }
                        else
                        {
                            inHomeInspectionAppointmentDecision.Notes = "";
                        }
                        if (!reader.IsDBNull(5))
                        {
                            inHomeInspectionAppointmentDecision.Decision = reader.GetString(5);
                        }
                        else
                        {
                            inHomeInspectionAppointmentDecision.Decision = "";
                        }
                        
                        inHomeInspectionAppointmentDecision.LocationID = reader.GetInt32(6);
                        inHomeInspectionAppointmentDecision.Active = reader.GetBoolean(7);

                        
                        inHomeInspectionAppointmentDecisions.Add(inHomeInspectionAppointmentDecision);
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
            return inHomeInspectionAppointmentDecisions;
        }


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:  Awaab Elamin, 2020/02/21
        /// 
        /// This method used to update an Adoptin Appliction decision.
        /// ID.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        public int UpdateAppoinment(HomeInspectorAdoptionAppointmentDecision
            oldHomeInspectorAdoptionAppointmentDecision, HomeInspectorAdoptionAppointmentDecision
            newHomeInspectorAdoptionAppointmentDecision)
        {
               int rows = 0;
                var conn = DBConnection.GetConnection();
                var cmd = new SqlCommand("sp_update_AdoptionApliction", conn);
                cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppointmentID", newHomeInspectorAdoptionAppointmentDecision
                .AppointmentID);

            cmd.Parameters.AddWithValue("@NewNotes", 
                newHomeInspectorAdoptionAppointmentDecision.Notes);
            cmd.Parameters.AddWithValue("@NewDecision",
                newHomeInspectorAdoptionAppointmentDecision.Decision);

            cmd.Parameters.AddWithValue("@OldNotes",
                oldHomeInspectorAdoptionAppointmentDecision.Notes);
            cmd.Parameters.AddWithValue("@OldDecision",
                oldHomeInspectorAdoptionAppointmentDecision.Decision);

            try
                {
                    conn.Open();
                    rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new ApplicationException("Record not found.");
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
                return rows;       
        }
    }
}

