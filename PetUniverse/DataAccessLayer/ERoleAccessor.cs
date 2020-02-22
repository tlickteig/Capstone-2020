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
    /// Creator: Chase Schulte
    /// Created: 2020/02/15
    /// Approver
    ///
    /// Reads and writes to database by invoking eRole Stored Procedures
    /// Class for the creation of User Objects with set data fields
    public class ERoleAccessor : IERoleAccessor
    {

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/09
        /// Approver: Kaleb Bachert
        /// 
        /// Activate a role id in the database by invoking the "sp_activate_eRole" stored procedure
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public int ActivateERole(string eRoleID)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();
            //Cmd
            var cmd = new SqlCommand("sp_activate_eRole", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ERoleID", eRoleID);
            try
            {
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nonQueryResults;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/09
        /// Approver: Kaleb Bachert
        /// 
        /// Deactivate a role id in the database by invoking the "sp_deactivate_eRole" stored procedure
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public int DeactivateERole(string eRoleID)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();
            //Cmd
            var cmd = new SqlCommand("sp_deactivate_eRole", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ERoleID", eRoleID);
            try
            {
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nonQueryResults;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/09
        /// Approver: Kaleb Bachert
        /// 
        /// Delete a role in the database by invoking the "sp_delete_eRole" stored procedure
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public int DeleteERole(string eRoleID)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();
            //Cmd
            var cmd = new SqlCommand("sp_delete_eRole", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ERoleID", eRoleID);
            try
            {
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nonQueryResults;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/07/09
        /// Approver: Kaleb Bachert
        /// 
        /// Insert a role the database by invoking the "sp_delete_eRole" stored procedure
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <param name="EDepartmentID"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public int InsertERole(ERole eRole)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();

            //Cmd
            var cmd = new SqlCommand("sp_insert_eRole", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Param
            cmd.Parameters.AddWithValue("@ERoleID", eRole.ERoleID);
            cmd.Parameters.AddWithValue("@EDepartmentID", eRole.EDepartmentID);
            cmd.Parameters.AddWithValue("@Description", eRole.Description);



            //Execute Command
            try
            {

                //Open conn
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return nonQueryResults;
        }
        /// <summary>
        /// NAME: Chase Schutle
        /// DATE: 2/7/2020
        /// CHECKED BY: N/A
        /// 
        /// Method grabs all eRoles
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// WHAT WAS CHAGED: N/A
        /// 
        /// </remarks>
        /// <returns></returns>
        public List<ERole> SelectAllERoles()
        {
            //Conn
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_eRoles", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            List<ERole> eRoles = new List<ERole>();
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                //Reader
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eRoles.Add(new ERole()
                        {
                            ERoleID = reader.GetString(0),
                            EDepartmentID = reader.GetString(1),
                            Description = reader.GetString(2),
                            Active = reader.GetBoolean(3)


                        });
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

            return eRoles;
        }
        /// <summary>
        /// NAME: Chase Schutle
        /// DATE: 2/16/2020
        /// CHECKED BY: N/A
        /// 
        /// Method grabs all eRoles by active state
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// WHAT WAS CHAGED: N/A
        /// 
        /// </remarks>
        /// <returns></returns>
        public List<ERole> SelectAllERolesByActive(bool active = true)
        {
            //Conn
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_active_eRoles", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Active", active);
            List<ERole> eRoles = new List<ERole>();
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                //Reader
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eRoles.Add(new ERole()
                        {
                            ERoleID = reader.GetString(0),
                            EDepartmentID = reader.GetString(1),
                            Description = reader.GetString(2),
                            Active = reader.GetBoolean(3)
                        });
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

            return eRoles;
        }
        /// <summary>
        /// NAME: Chase Schutle
        /// DATE: 2/16/2020
        /// CHECKED BY: N/A
        /// 
        /// Method grabs a eRole and allows it to be modified
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// WHAT WAS CHAGED: N/A
        /// 
        /// </remarks>
        /// <returns></returns>
        public int UpdateERole(ERole oldERole, ERole newERole)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();

            //Cmd
            var cmd = new SqlCommand("sp_update_eRole", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Vals
            cmd.Parameters.AddWithValue("OldERoleID", oldERole.ERoleID);
            cmd.Parameters.AddWithValue("OldEDepartmentID", oldERole.EDepartmentID);
            cmd.Parameters.AddWithValue("OldDescription", oldERole.Description);

            cmd.Parameters.AddWithValue("NewEDepartmentID", newERole.EDepartmentID);
            cmd.Parameters.AddWithValue("NewDescription", newERole.Description);




            //Execute Command
            try
            {

                //Open conn
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return nonQueryResults;
        }
    }
}
