using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     CONTRIBUTERS: Kaleb Bachert
    ///     DATE: 2020-02-05
    ///     CHECKED BY: Zoey McDonald
    ///     Class for emulating an actual data access class for volunteer shifts
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public class VolunteerShiftAccessorFake : IVolunteerShiftAccessor
    {
        private List<VolunteerShift> _volunteerShifts = new List<VolunteerShift>();

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        ///     Main constructor for the class
        /// </summary>
        public VolunteerShiftAccessorFake()
        {
            _volunteerShifts.Add(new VolunteerShift()
            {
                VolunteerShiftID = 1,
                VolunteerID = 1,
                ShiftTitle = "Custodian",
                IsSpecialEvent = false,
                VolunteerShiftDate = DateTime.Now,
                ScheduleID = 1,
                ShiftNotes = "Blah blah blah",
                VolunteerTaskID = 1,
                Recurrance = "Once",
                ShiftDescription = "Let's clean everything",
                ShiftStartTime = TimeSpan.Zero,
                ShiftEndTime = TimeSpan.Zero + TimeSpan.Parse("6")
            });

            _volunteerShifts.Add(new VolunteerShift()
            {
                VolunteerShiftID = 2,
                VolunteerID = 1,
                ShiftTitle = "Veterinarian",
                IsSpecialEvent = false,
                VolunteerShiftDate = DateTime.Now,
                ScheduleID = 1,
                ShiftNotes = "Blah blah blah",
                VolunteerTaskID = 1,
                Recurrance = "Once",
                ShiftDescription = "Let's heal everything",
                ShiftStartTime = TimeSpan.Zero,
                ShiftEndTime = TimeSpan.Zero + TimeSpan.Parse("6")
            });
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="shift">Volunteer shift to be added</param>
        /// <returns>The number of rows affected</returns>
        public int AddShift(VolunteerShift shift)
        {
            _volunteerShifts.Add(shift);
            return 1;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-08
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The number of rows affected</returns>
        public int CancelVolunteerShift(int volunteerID, int volunteerShiftID)
        {
            foreach (VolunteerShift shift in _volunteerShifts)
            {
                if (volunteerShiftID == shift.VolunteerShiftID)
                {
                    shift.VolunteerID = 0;
                }
            }
            return 1;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-08
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="shift">ID of the Volunteer shift to remove</param>
        /// <returns>The number of rows affected</returns>
        public int RemoveShift(int shiftID)
        {
            int rows = 0;
            VolunteerShift shiftToRemove = new VolunteerShift();

            foreach (VolunteerShift shift in _volunteerShifts)
            {
                if (shiftID == shift.VolunteerShiftID)
                {
                    shiftToRemove = shift;
                    rows++;
                }
            }
            _volunteerShifts.Remove(shiftToRemove);
            return rows;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-17
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <returns>A list of shifts from the list</returns>
        public List<VolunteerShift> SelectAllShifts()
        {            
            return _volunteerShifts;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-01
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteerID to query</param>
        /// <returns>A list of shifts from the emulated database</returns>
        public List<VolunteerShift> SelectAllShiftsForAVolunteer(int volunteerID)
        {
            List<VolunteerShift> tempList = new List<VolunteerShift>();

            foreach (VolunteerShift shift in _volunteerShifts)
            {
                if (shift.VolunteerID == volunteerID)
                {
                    tempList.Add(shift);
                }
            }

            return tempList;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-01
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="shiftID">The shiftID to query</param>
        /// <returns>A shift from the emulated database</returns>
        public VolunteerShift SelectShift(int shiftID)
        {
            VolunteerShift shift = new VolunteerShift();

            foreach (VolunteerShift shift2 in _volunteerShifts)
            {
                if (shift2.VolunteerShiftID == shiftID)
                {
                    shift = shift2;
                }
            }

            return shift;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-02
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The simluated number of rows affected</returns>
        public int SignVolunteerUpForShift(int volunteerID, int volunteerShiftID)
        {
            foreach (VolunteerShift shift in _volunteerShifts)
            {
                if (volunteerShiftID == shift.VolunteerShiftID)
                {
                    shift.VolunteerID = volunteerID;
                }
            }
            return 1;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-10
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="oldShift">Old shift to be replaced</param>
        /// <param name="newShift">New shift as replacement</param>
        /// <returns>The number of rows affected</returns>
        public int UpdateShift(VolunteerShift oldShift, VolunteerShift newShift)
        {
            int rows = 0;
            int index = 0;

            foreach (VolunteerShift tempShift in _volunteerShifts)
            {                
                if (tempShift.VolunteerShiftID == oldShift.VolunteerShiftID)
                {                    
                    rows = 1;
                    break;
                }
                index++;
            }

            if (rows == 1)
            {
                _volunteerShifts[index] = newShift;
            }

            return rows;
        }
    }
}
