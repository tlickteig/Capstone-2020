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
    /// NAME: Jordan Lindo
    /// DATE: 2/6/2020
    /// CHECKED BY: Alex Diers
    /// 
    /// This is a DataAccess class for TSQL it implements the IDepartmentAccessor
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class DepartmentAccessor : IDepartmentAccessor
    {
        public int DeleteDepartment(string departmentId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a method for inserting a department into the tsql database.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public int InsertDepartment(string departmentId, string description)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_department", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
            cmd.Parameters.AddWithValue("@Description", description);

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
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a method for selecting all departments from the tsql database.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public List<Department> SelectAllDepartments()
        {
            List<Department> departments = new List<Department>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_departments", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        departments.Add(new Department
                        {
                            DepartmentID = reader.GetString(0),
                            Description = reader.IsDBNull(1) ? "" : reader.GetString(1)
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
            return departments;
        }


        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is the method for selecting a department by id from the tsql database.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public Department SelectDepartmentByID(string departmentId)
        {
            Department department = null;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_department_by_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", departmentId);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    department = new Department()
                    {
                        DepartmentID = reader.GetString(0),
                        Description = reader.IsDBNull(1) ? "" : reader.GetString(1)
                    };
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
            return department;
        }


        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/15/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is the method for updating a department in the tsql database.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="oldDepartment"></param>
        /// <param name="newDepartment"></param>
        /// <returns></returns>
        public int UpdateDepartment(Department oldDepartment, Department newDepartment)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_department", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", oldDepartment.DepartmentID);
            cmd.Parameters.AddWithValue("@NewDescription", newDepartment.Description);

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
    }
}


