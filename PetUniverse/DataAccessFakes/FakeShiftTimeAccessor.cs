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
    /// NAME:Lane Sandburg
    /// DATE: 02/05/2019
    /// CHECKED BY:Alex Diers
    /// 
    /// the fake class for shift time accessor
    /// </summary>
    /// <remarks>
    /// UPDATED BY:NA
    /// UPDATED DATE:
    /// WHAT WAS CHANGED:
    /// </remarks> 
    public class FakeShiftTimeAccessor : IShiftTimeAccessor
    {
        private List<PetUniverseShiftTime> shiftTimes;

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
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:Alex Diers
        /// 
        /// Fake Logic for inserting a shift time
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks> 
        public int InsertShiftTime(PetUniverseShiftTime shiftTime)
        {
            PetUniverseShiftTime newShiftTime = new PetUniverseShiftTime();

            newShiftTime = shiftTime;

            try
            {
                shiftTimes.Add(newShiftTime);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;

            }
        }


        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:Alex Diers
        /// 
        /// Fake Logic for selecting all shift times
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public List<PetUniverseShiftTime> SelectAllShiftTimes()
        {
            return (from s in shiftTimes
                    select s).ToList();
        }


        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/13/2019
        /// CHECKED BY:Alex Diers
        /// 
        /// Fake Logic for updating a shift time
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public int UpdateShiftTime(PetUniverseShiftTime oldShiftTime, PetUniverseShiftTime newShiftTime)
        {
            PetUniverseShiftTime ShiftTime = oldShiftTime;



            try
            {
                oldShiftTime = newShiftTime;
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;

            }
        }
    }
}
