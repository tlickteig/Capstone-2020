using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 4/09/2020
    /// Approver: Chase Schulte
    /// 
    /// Schedule logic
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class ScheduleManager : IScheduleManager
    {
        private IScheduleAccessor _scheduleAccessor;
        private IShiftTimeAccessor _shiftTimeAccessor;
        private IScheduleHoursManager _scheduleHoursManager;
        private List<PUUserVMHours> _employeeHours;
        private List<OpenPosition> _openPositions;



        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/09/2020
        /// Approver: Chase Schulte
        /// 
        /// Schedule manager constructor.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public ScheduleManager()
        {
            _scheduleAccessor = new ScheduleAccessor();
            _scheduleHoursManager = new ScheduleHoursManager();
            _shiftTimeAccessor = new ShiftTimeAccessor();

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/09/2020
        /// Approver: Chase Schulte
        /// 
        /// Schedule manager constructor.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="scheduleAccessor"></param>
        public ScheduleManager(IScheduleAccessor scheduleAccessor,
            IShiftTimeAccessor shiftTimeAccessor)
        {
            _scheduleAccessor = scheduleAccessor;
            _shiftTimeAccessor = shiftTimeAccessor;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// Method for inserting a Schedule
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public int AddSchedule(ScheduleVM scheduleVM)
        {
            try
            {
                return _scheduleAccessor.InsertSchedule(scheduleVM);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Schedule not added. ", ex);
            }

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// Method for adding the hours scheduled.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
        public bool AddScheduledHours(int scheduleID)
        {
            bool result = false;
            if (_employeeHours != null && _employeeHours.Count != 0)
            {
                result = (_employeeHours.Count ==
                    _scheduleHoursManager.AddAllScheduleHours(scheduleID, _employeeHours));
            }
            else
            {
                throw new ApplicationException("No employees to add.");
            }
            return result;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// Method for generating a schedule
        /// </summary>
        /// <remarks>
        /// Updater: Jordan Lindo
        /// Updated: 4/28/2020
        /// Update: Added limit to the number allowed.
        /// 
        /// </remarks>
        /// <param name="date"></param>
        /// <param name="lines"></param>
        /// <returns></returns>
        public ScheduleVM GenerateSchedule(DateTime date, List<BaseScheduleLine> lines)
        {
            ScheduleVM schedule = new ScheduleVM();
            schedule.ScheduleLines = new List<ShiftUserVM>();
            int daysInSchedule = 14;
            schedule.StartDate = date;
            schedule.EndDate = date.AddDays(daysInSchedule);
            _openPositions = new List<OpenPosition>();

            // List for storing which employee is scheduled by day
            List<List<int>> employeeIDsInSchedule = new List<List<int>>();

            // List for recording the count of hours for each employee;
            _employeeHours = new List<PUUserVMHours>();
            try
            {
                int scheduleCount = _scheduleAccessor.GetCountOfActiveSchedules();

                if (scheduleCount < 4)
                {
                    // A loop for repeating for each day in the schedule.
                    for (int i = 0; i < daysInSchedule; i++)
                    {

                        // The list representing the day of the week
                        employeeIDsInSchedule.Add(new List<int>());

                        // A loop to work through a base schedule
                        foreach (BaseScheduleLine line in lines)
                        {
                            // Skip if none are needed.
                            if (line.Count > 0)
                            {
                                // Get a list of possible choices.
                                List<PUUserVMAvailability> shuffle = _scheduleAccessor.GetListOfAvailableEmployees(date.AddDays(i), line);
                                List<PUUserVMAvailability> avaliable = listShuffle(shuffle);
                                // Skip if no choices are available.
                                if (avaliable != null && avaliable.Count > 0)
                                {
                                    PetUniverseShiftTime shiftTime = _shiftTimeAccessor.SelectShiftTimeByID(line.ShiftTimeID);
                                    DateTime shiftStart = DateTime.Parse(shiftTime.StartTime);
                                    DateTime shiftEnd = DateTime.Parse(shiftTime.EndTime);
                                    TimeSpan shiftLength = shiftEnd - shiftStart;
                                    double minimumHoursToWork = 6;

                                    bool end = false;
                                    // A loop for the number of positions to fill.
                                    for (int j = line.Count; j > 0 && !end; j--)
                                    {
                                        bool found = false;
                                        int index = 0;
                                        PUUserVMAvailability candidate = avaliable[index];
                                        PUUserVMAvailability chosen = null;
                                        int next = index;
                                        do
                                        {
                                            // Check if the candidate is already scheduled on a day.
                                            if (!employeeIDsInSchedule[i].Contains(candidate.PUUserID))
                                            {
                                                DateTime availabilityStart = DateTime.Parse(candidate.Availability.StartTime);
                                                DateTime availabilityEnd = DateTime.Parse(candidate.Availability.EndTime);
                                                TimeSpan availableLength = availabilityEnd.Subtract(availabilityStart);

                                                // Short availabilities will be skipped.
                                                if (availableLength.TotalHours >= minimumHoursToWork)
                                                {
                                                    if (shiftStart.CompareTo(availabilityStart) <= 0)
                                                    {
                                                        if (shiftEnd.CompareTo(availabilityEnd) >= 0)
                                                        {
                                                            if (shiftLength.Subtract(availabilityStart
                                                                - shiftStart).TotalHours >= minimumHoursToWork)
                                                            {
                                                                found = true;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            found = true;
                                                        }
                                                    }
                                                    else if ((shiftEnd.Subtract(availabilityStart)).TotalHours >= minimumHoursToWork)
                                                    {
                                                        found = true;
                                                    }

                                                    if (found)
                                                    {
                                                        bool allowed = true;
                                                        foreach (PUUserVMHours userVMHours in _employeeHours)
                                                        {
                                                            if (userVMHours.PUUserID.Equals(candidate.PUUserID))
                                                            {
                                                                if (i < (daysInSchedule / 2))
                                                                {
                                                                    if (userVMHours.Week1Hours >= 40)
                                                                    {
                                                                        allowed = false;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (userVMHours.Week2Hours >= 40)
                                                                    {
                                                                        allowed = false;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        if (allowed)
                                                        {
                                                            employeeIDsInSchedule[i].Add(candidate.PUUserID);
                                                            chosen = candidate;
                                                            bool inList = false;
                                                            foreach (PUUserVMHours userVMHours in _employeeHours)
                                                            {
                                                                if (userVMHours.PUUserID.Equals(chosen.PUUserID))
                                                                {
                                                                    inList = true;
                                                                    if (i < (daysInSchedule / 2))
                                                                    {
                                                                        userVMHours.Week1Hours += (decimal)(shiftEnd.Subtract(availabilityStart)).TotalHours;
                                                                    }
                                                                    else
                                                                    {
                                                                        userVMHours.Week2Hours += (decimal)(shiftEnd.Subtract(availabilityStart)).TotalHours;
                                                                    }
                                                                }
                                                            }
                                                            if (!inList)
                                                            {
                                                                PUUserVMHours userVMHours = new PUUserVMHours
                                                                {
                                                                    PUUserID = chosen.PUUserID,
                                                                    Email = chosen.Email,
                                                                    FirstName = chosen.FirstName,
                                                                    LastName = chosen.LastName
                                                                };
                                                                if (i < (daysInSchedule / 2))
                                                                {
                                                                    userVMHours.Week1Hours += (decimal)(shiftEnd.Subtract(availabilityStart)).TotalHours;
                                                                    userVMHours.Week2Hours = 0;
                                                                }
                                                                else
                                                                {
                                                                    userVMHours.Week1Hours = 0;
                                                                    userVMHours.Week2Hours += (decimal)(shiftEnd.Subtract(availabilityStart)).TotalHours;
                                                                }
                                                                _employeeHours.Add(userVMHours);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            found = false;
                                                        }
                                                    }
                                                }
                                            }
                                            next++;
                                            if (next != avaliable.Count)
                                            {
                                                candidate = avaliable[next];
                                            }
                                        } while (!found && next < avaliable.Count);

                                        if (found)
                                        {
                                            schedule.ScheduleLines.Add(new ShiftUserVM
                                            {
                                                ShiftTimeID = line.ShiftTimeID,
                                                ShiftDate = date.AddDays(i),
                                                RoleID = line.ERoleID,
                                                EmployeeID = chosen.PUUserID,
                                                EmployeeName = chosen.LastName + ", " + chosen.FirstName,
                                                ShiftStart = shiftStart.ToShortTimeString(),
                                                ShiftEnd = shiftEnd.ToShortTimeString()

                                            });
                                        }
                                        else
                                        {
                                            _openPositions.Add(new OpenPosition
                                            {
                                                ERoleID = line.ERoleID,
                                                count = j
                                            });
                                            end = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    throw new ApplicationException("That schedule is too far in the future.");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return schedule;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/27/2020
        /// Approver: Chase Schulte
        /// 
        /// List Shuffle method.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<PUUserVMAvailability> listShuffle(List<PUUserVMAvailability> list)
        {
            Random random = new Random();
            int number = list.Count;
            int sides = 2;
            int chance = random.Next(sides);
            if (number > 2 || chance > 0)
            {
                while (number > 1)
                {
                    int randInt = random.Next(number);
                    number--;
                    PUUserVMAvailability temp = list[randInt];
                    list[randInt] = list[number];
                    list[number] = temp;
                }
            }
            return list;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// Method for retrieving active schedules.
        /// </summary>
        /// <remarks>
        /// Updater: Jordan Lindo
        /// Updated: Added a counter to find and deactivate old schedules.
        /// Update: 4/28/2020
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<ScheduleVM> RetrieveAllSchedules(bool active = true)
        {
            double daysAfterEnd = 3;

            try
            {
                List<ScheduleVM> temp = _scheduleAccessor.SelectAllSchedules(active);
                List<ScheduleVM> activeSchedules = new List<ScheduleVM>();


                foreach (var item in temp)
                {
                    if (item.EndDate.AddDays(daysAfterEnd).CompareTo(DateTime.Now) < 0)
                    {
                        _scheduleAccessor.DeactivateSchedule(item.ScheduleID);
                    }
                    else
                    {
                        activeSchedules.Add(item);
                    }
                }

                return activeSchedules;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Schedule not added. ", ex);
            }
        }
    }

}
