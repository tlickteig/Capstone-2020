using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/2/7
///  APPROVER: Lane Sandburg
///  
///  Fake Shift Accessor Class for Unit Testing
/// </summary>
namespace DataAccessFakes
{
    public class FakeShiftAccessor : IShiftAccessor
    {
        private List<ShiftVM> shiftVMs;
        private List<ScheduleWithHoursWorked> scheduleHours;

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/1
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Fake Shift Accessor Constructor, generates dummy data for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public FakeShiftAccessor()
        {
            shiftVMs = new List<ShiftVM>()
            {
                new ShiftVM()
                {
                    ShiftID = 1000000,
                    EmployeeWorking = 100001,
                    Department = "Fake1",
                    Date = new DateTime(2020, 4, 21).ToShortDateString(),
                    StartTime = "14:00:00",
                    EndTime = "22:00:00",
                    ShiftTimeID = 1000000
                },
                new ShiftVM()
                {
                    ShiftID = 1000001,
                    EmployeeWorking = 100001,
                    Department = "Fake2",
                    Date = new DateTime(2020, 4, 21).ToShortDateString(),
                    StartTime = "8:45:00",
                    EndTime = "12:45:00",
                    ShiftTimeID = 1000001
                },
                new ShiftVM()
                {
                    ShiftID = 1000002,
                    EmployeeWorking = 100001,
                    Department = "Fake1",
                    Date = new DateTime(2020, 4, 22).ToShortDateString(),
                    StartTime = "14:00:00",
                    EndTime = "22:00:00",
                    ShiftTimeID = 1000000
                },
                new ShiftVM()
                {
                    ShiftID = 1000003,
                    EmployeeWorking = 100000,
                    Department = "Fake1",
                    Date = new DateTime(2020, 4, 21).ToShortDateString(),
                    StartTime = "4:00:00",
                    EndTime = "7:00:00",
                    ShiftTimeID = 1000000
                }
            };

            scheduleHours = new List<ScheduleWithHoursWorked>()
            {
                new ScheduleWithHoursWorked()
                {
                    ScheduleID = 1000000,
                    ScheduleStartDate = DateTime.Now,
                    ScheduleEndDate = DateTime.Now.AddDays(13),
                    FirstWeekHours = 40,
                    SecondWeekHours = 20
                },
                new ScheduleWithHoursWorked()
                {
                    ScheduleID = 1000001,
                    ScheduleStartDate = DateTime.Now.AddDays(14),
                    ScheduleEndDate = DateTime.Now.AddDays(27),
                    FirstWeekHours = 35,
                    SecondWeekHours = 25
                }
            };
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that retrieves all the dummy ShiftVMs on a specified date, for testing
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<ShiftVM> SelectShiftsByDay(DateTime date)
        {
            return (from s in shiftVMs
                    where s.Date.Equals(date.ToShortDateString())
                    select s).ToList();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/1
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that retrieves all the dummy ShiftVMs for a user, for testing
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        public List<ShiftVM> SelectShiftsByUser(int userID)
        {
            return (from s in shiftVMs
                    where s.EmployeeWorking == userID
                    select s).ToList();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that retrieves the dummy hours worked for a dummy user within the dummy schedule
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="dateInSchedule"></param>
        public ScheduleWithHoursWorked SelectScheduleHoursByUserAndDate(int userID, DateTime dateInSchedule)
        {
            return (from s in scheduleHours
                    where s.ScheduleStartDate <= dateInSchedule
                    && s.ScheduleEndDate >= dateInSchedule
                    select s).First();
        }


        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that updates the dummy shift's dummy EmployeeWorking
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
        public int UpdateShiftUserWorking(int shiftID, int newUserWorking, int oldUserWorking)
        {
            int recordsUpdated = 0;

            foreach (ShiftVM shift in shiftVMs)
            {
                if (shift.ShiftID == shiftID && shift.EmployeeWorking == oldUserWorking)
                {
                    shift.EmployeeWorking = newUserWorking;
                    recordsUpdated++;
                }
            }

            return recordsUpdated;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that updates the dummy hours worked forthe dummy shift of the given week number
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
        public int UpdateEmployeeHoursWorked(int userID, int scheduleID, int weekNumber, double changeAmount)
        {
            int recordsUpdated = 0;

            foreach (ScheduleWithHoursWorked hoursWorked in scheduleHours)
            {
                if (hoursWorked.ScheduleID == scheduleID)
                {
                    if (weekNumber == 1)
                    {
                        hoursWorked.FirstWeekHours += changeAmount;
                        recordsUpdated++;
                    }
                    else if (weekNumber == 2)
                    {
                        hoursWorked.SecondWeekHours += changeAmount;
                        recordsUpdated++;
                    }
                }
            }

            return recordsUpdated;
        }
    }
}
