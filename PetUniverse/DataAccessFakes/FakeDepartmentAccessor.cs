using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    /// <summary>
    /// NAME: Jordan Lindo
    /// DATE: 2/6/2020
    /// CHECKED BY: Alex Diers
    /// 
    /// This is a DataAccessFake used for unit testing.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class FakeDepartmentAccessor : IDepartmentAccessor
    {
        private List<Department> departments;

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a DataAccessFake constructor used for unit testing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public FakeDepartmentAccessor()
        {
            departments = new List<Department>()
            {
                new Department()
                {
                    DepartmentID ="Fake Department",
                    Description ="Fake Description"
                }
            };
        }


        public int DeleteDepartment(string departmentId)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is the data access fake for adding a department to the table.
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
            Department department = new Department()
            {
                DepartmentID = departmentId,
                Description = description
            };

            departments.Add(department);

            if (departments.Contains(department))
            {
                rows = 1;
            }

            return rows;
        }

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is the data access fake for selecting all departments.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public List<Department> SelectAllDepartments()
        {
            return departments;
        }

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is the data access fake for selecting a department by id.
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
            foreach (var aDepartment in departments)
            {
                if (aDepartment.DepartmentID.Equals(departmentId))
                {
                    department = aDepartment;
                }
            }
            return department;
        }

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/18/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is the data access fake for update department
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public int UpdateDepartment(Department oldDepartment, Department newDepartment)
        {
            int rows = 1;
            return rows;
        }
    }
}
