using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Jordan Lindo
    /// DATE: 2/6/2020
    /// CHECKED BY: Alex Diers
    /// 
    /// This is an interface method.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public interface IDepartmentManager
    {
        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is an interface method for adding a department.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <param name="description"></param>
        /// <returns>bool</returns>
        bool AddDepartment(string departmentId, string description);

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is an interface method for getting a list of departments.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        List<Department> RetrieveAllDepartments();

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is an interface method getting a department by id.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="DepartmentId"></param>
        /// <returns>Department</returns>
        Department RetrieveDepartmentByID(string DepartmentId);

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is an interface method update a department.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="oldDepartmentId"></param>
        /// <param name="newDepartmentId"></param>
        /// <returns>bool</returns>
        bool EditDepartment(Department oldDepartment, Department newDepartment);

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
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
        /// <returns>bool</returns>
        bool DeleteDepartment(string departmentId);
    }
}
