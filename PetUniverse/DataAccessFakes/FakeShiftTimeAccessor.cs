using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Lane Sandburg
    /// Created: 02/05/2019
    /// Approver: Alex Diers
    /// 
    /// the fake class for shift time accessor
    /// </summary>
    public class FakeShiftTimeAccessor : IShiftTimeAccessor
    {
        private List<PetUniverseShiftTime> shiftTimes;

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public FakeShiftTimeAccessor()
        {
            shiftTimes = new List<PetUniverseShiftTime>()
            {
                new PetUniverseShiftTime()
                {
                    ShiftTimeID = 100001,
                    DepartmentID = "Sales",
                    StartTime = "08:45:00",
                    EndTime = "5:45:00"
                }
            };
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 03/05/2019
        /// Approver: Kaleb Bachert
        /// 
        /// Fake Logic for deleting a shift time
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int DeleteShiftTime(int shiftTimeID)
        {
            int result = 1;
            PetUniverseShiftTime shiftTime = null;
            foreach (var s in shiftTimes)
            {
                if (shiftTimeID == s.ShiftTimeID)
                {
                    shiftTime = s;
                }
            }

            if (shiftTime == null)
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// Fake Logic for inserting a shift time
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        public int InsertShiftTime(PetUniverseShiftTime shiftTime)
        {
            int result = 0;
            PetUniverseShiftTime newShiftTime = new PetUniverseShiftTime();
            newShiftTime = shiftTime;

            try
            {
                shiftTimes.Add(newShiftTime);
                result = 1;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// Fake Logic for selecting all shift times
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        public List<PetUniverseShiftTime> SelectAllShiftTimes()
        {
            return (from s in shiftTimes
                    select s).ToList();
        }


        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/13/2019
        /// Approver: Alex Diers
        /// 
        /// Fake Logic for updating a shift time
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        public int UpdateShiftTime(PetUniverseShiftTime oldShiftTime, PetUniverseShiftTime newShiftTime)
        {
            int result = 0;
            PetUniverseShiftTime ShiftTime = oldShiftTime;

            try
            {
                oldShiftTime = newShiftTime;
                result = 1;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return result;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a method for selecting shift times by department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public List<PetUniverseShiftTime> SelectShiftTimeByDepartment(string departmentID)
        {
            List<PetUniverseShiftTime> times = new List<PetUniverseShiftTime>();

            foreach (PetUniverseShiftTime time in shiftTimes)
            {
                if (time.DepartmentID.Equals(departmentID))
                {
                    times.Add(time);
                }
            }
            return times;
        }
    }
}
