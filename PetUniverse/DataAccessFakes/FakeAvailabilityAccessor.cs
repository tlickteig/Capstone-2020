using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{
    public class FakeAvailabilityAccessor : IAvailabilityAccessor
    {
        private List<Availability> availabilities;

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Fake Availability Accessor Constructor, generates dummy data for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public FakeAvailabilityAccessor()
        {
            availabilities = new List<Availability>()
            {
                new Availability()
                {
                    UserID = 100000,
                    DayOfWeek = "Monday",
                    StartTime = new DateTime(2020, 4, 21, 10, 0, 0).ToString(),
                    EndTime = new DateTime(2020, 4, 21, 23, 0, 0).ToString()
                },
                new Availability()
                {
                    UserID = 100001,
                    DayOfWeek = "Tuesday",
                    StartTime = new DateTime(2020, 4, 21, 1, 0, 0).ToString(),
                    EndTime = new DateTime(2020, 4, 21, 23, 0, 0).ToString()
                },
                new Availability()
                {
                    UserID = 100000,
                    DayOfWeek = "Thursday",
                    StartTime = new DateTime(2020, 4, 21, 1, 0, 0).ToString(),
                    EndTime = new DateTime(2020, 4, 21, 23, 0, 0).ToString()
                },
                new Availability()
                {
                    UserID = 100001,
                    DayOfWeek = "Thursday",
                    StartTime = new DateTime(2020, 4, 21, 1, 0, 0).ToString(),
                    EndTime = new DateTime(2020, 4, 21, 23, 0, 0).ToString()
                }
            };
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///   Method that retrieves all the dummy Availabilities, for testing
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<Availability> SelectAllUsersAvailability()
        {
            return availabilities;
        }
    }
}
