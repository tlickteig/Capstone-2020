using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME: Jordan Lindo
    /// DATE: 2/6/2020
    /// CHECKED BY: Alex Diers
    /// 
    /// This is a DataAccessInterface that all data access classes should be based on.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public interface IDepartmentAccessor
    {
        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/14/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is an interface method for inserting a department.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <param name="description"></param>
        /// <returns>int</returns>
        int InsertDepartment(string departmentId, string description);

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/14/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is an interface method selecting all departments.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <returns>List<Department></DepartmentsV></returns>
        List<Department> SelectAllDepartments();

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/14/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is an interface method for selecting a department by id
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <returns>Department</returns>
        Department SelectDepartmentByID(string departmentId);

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/14/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is an interface method for updating a department.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="oldDepartment"></param>
        /// <param name="newDepartment"></param>
        /// <returns>int</returns>
        int UpdateDepartment(Department oldDepartment, Department newDepartment);

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/14/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is an interface method for deleting a department.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <returns>int</returns>
        int DeleteDepartment(string departmentId);
    }
}
