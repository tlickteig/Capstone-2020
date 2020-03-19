using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME: Ethan Holmes
    /// DATE: 2/6/2020
    /// APPROVER: Josh Jackson, Timothy Licktieg
    /// 
    /// This interface outlines the interface for the Volunteer Task Accessor.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATE DATE: N/A
    /// CHANGE DESCRIPTION: N/A
    /// </remarks>
    public interface IVolunteerTaskAccessor
    {
        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// Create a Volunteer Task Interface definition.
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="taskType"></param>
        /// <param name="assignmentGroup"></param>
        /// <param name="taskDescription"></param>
        /// <param name="dueDate"></param>
        /// <returns></returns>
        int CreateVolunteerTask(string taskName, string taskType, string assignmentGroup, string taskDescription, DateTime dueDate);

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// Retrieves a volunteer task by task name.
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// </summary>
        /// <param name="volunteerTaskName"></param>
        /// <returns></returns>
        VolunteerTask GetVolunteerTaskByName(string volunteerTaskName);

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// Retrives all volunteer task objects.
        /// </summary>
        /// <returns></returns>
        List<VolunteerTaskVM> GetAllVolunteerTasks();

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg 
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="taskType"></param>
        /// <param name="assignmentGroup"></param>
        /// <param name="dueDate"></param>
        /// <param name="taskDescription"></param>
        /// <returns></returns>
        int UpdateVolunteerTask(string taskName, string taskType, string assignmentGroup, DateTime dueDate, string taskDescription);

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// 
        /// APPROVER: 
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns></returns>
        int DeleteVolunteerTask(string taskName);
    }
}
