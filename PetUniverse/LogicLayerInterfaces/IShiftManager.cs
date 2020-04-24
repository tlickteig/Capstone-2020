using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    ///  CREATOR: Kaleb Bachert
    ///  CREATED: 2020/3/31
    ///  APPROVER: Lane Sandburg
    ///  
    ///  Interface for ShiftManager
    /// </summary>
    public interface IShiftManager
    {
        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/31
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for getting the scheduled Shifts for a User
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        List<ShiftVM> RetrieveShiftsByUser(int userID);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/31
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for getting the schedule and hours containing the date specified
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="dateInSchedule"></param>
        ScheduleWithHoursWorked RetrieveScheduleHoursByUserAndDate(int userID, DateTime dateInSchedule);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for updating hours worked for an employee
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="scheduleID"></param>
        /// <param name="weekNumber"></param>
        /// <param name="changeAmount"></param>
        /// <returns></returns>
        bool EditEmployeeHoursWorked(int userID, int scheduleID, int weekNumber, double changeAmount);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for updating which user is working a shift
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="shiftID"></param>
        /// <param name="newUserWorking"></param>
        /// <param name="oldUserWorking"></param>
        /// <returns></returns>
        bool EditShiftUserWorking(int shiftID, int newUserWorking, int oldUserWorking);
    }
}
