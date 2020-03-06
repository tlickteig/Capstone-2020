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
    /// Creator: Carl Davis
    /// Created: 2/28/2020
    /// Approver: Ethan Murphy 3/6/2020
    /// Approver: 
    /// 
    /// Accessor class thsat interacts with the database through stored procedures
    /// </summary>
    public class FacilityInspectionAccessor : IFacilityInspectionAccessor
    {
        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Method to insert a FacilityInspection Record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspection"></param>
        /// <returns>1 or 0 int depending if record was added</returns>
        public int InsertFacilityInspectionRecord(FacilityInspection facilityInspection)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_facility_inspection", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = facilityInspection.UserID;

            cmd.Parameters.Add("@InspectorName", SqlDbType.NVarChar);
            cmd.Parameters["@InspectorName"].Value = facilityInspection.InspectorName;

            cmd.Parameters.Add("@InspectionDate", SqlDbType.Date);
            cmd.Parameters["@InspectionDate"].Value = facilityInspection.InspectionDate;

            cmd.Parameters.Add("@InspectionDescription", SqlDbType.NVarChar);
            cmd.Parameters["@InspectionDescription"].Value = facilityInspection.InspectionDescription;

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
