using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using LogicLayerInterfaces;
using DataTransferObjects;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 2/6/2020
    /// Approver: Alex Diers
    /// 
    /// This is the Logic layer Department Manager for interacting between the Presentation and the Data Access.
    /// </summary>
    public class DepartmentManager : IDepartmentManager
    {

        private IDepartmentAccessor _departmentAccessor;


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the no argument constructor.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        public DepartmentManager()
        {
            _departmentAccessor = new DepartmentAccessor();
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This constructor requires an IDepartmentAccessor.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="departmentAccessor"></param>
        public DepartmentManager(IDepartmentAccessor departmentAccessor)
        {
            _departmentAccessor = departmentAccessor;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method to add a department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool AddDepartment(string departmentId, string description)
        {
            bool added = false;
            if (null != departmentId && departmentId.Length <= 50 && description.Length <= 200)
            {
                try
                {
                    if (null == _departmentAccessor.SelectDepartmentByID(departmentId))
                    {
                        if (_departmentAccessor.InsertDepartment(departmentId, description) == 1)
                        {
                            added = true;
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return added;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method to retrieve all departments.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        public List<Department> RetrieveAllDepartments()
        {

            try
            {
                return _departmentAccessor.SelectAllDepartments();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method to select a department by id.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public Department RetrieveDepartmentByID(string departmentId)
        {
            Department department;
            department = _departmentAccessor.SelectDepartmentByID(departmentId);
            return department;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method to update a department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="oldDepartmentId"></param>
        /// <param name="newDepartmentId"></param>
        /// <returns></returns>
        public bool EditDepartment(Department oldDepartment, Department newDepartment)
        {
            bool result = false;

            if (oldDepartment.DepartmentID.Equals(newDepartment.DepartmentID)
                && oldDepartment.DepartmentID.Length <= 50
                && newDepartment.DepartmentID.Length <= 50
                 && oldDepartment.Description.Length <= 200
                 && newDepartment.Description.Length <= 200)
            {
                List<Department> departments = RetrieveAllDepartments();
                foreach (Department department in departments)
                {
                    if (department.DepartmentID == oldDepartment.DepartmentID && department.Description == oldDepartment.Description)
                    {
                        result = (1 == _departmentAccessor.UpdateDepartment(oldDepartment, newDepartment));
                    }
                }
            }
            return result;
        }

        public bool DeleteDepartment(string departmentId)
        {
            throw new NotImplementedException();
        }

    }
}
