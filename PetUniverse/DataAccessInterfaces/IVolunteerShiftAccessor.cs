using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     CONTRIBUTERS: Kaleb Bachert
    ///     DATE: 2020-02-05
    ///     CHECKED BY: Zoey McDonald
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public interface IVolunteerShiftAccessor
    {
        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-17
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <returns>A list of shifts from the database</returns>
        List<VolunteerShift> SelectAllShifts();

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-01
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteerID to query</param>
        /// <returns>A list of shifts from the database</returns>
        List<VolunteerShift> SelectAllShiftsForAVolunteer(int volunteerID);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-01
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="shiftID">The shiftID to query</param>
        /// <returns>A shift from the database</returns>
        VolunteerShift SelectShift(int shiftID);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-10
        ///     CHECKED BY: Zoey McDonald
        ///     Method for editing a shift inside the DB
        /// </summary>
        /// <param name="oldShift">The shift to be updated</param>
        /// <param name="newShift">The new shift</param>
        /// <returns>Number of rows affected</returns>
        int UpdateShift(VolunteerShift oldShift, VolunteerShift newShift);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        ///     Method for removing a shift from the DB
        /// </summary>
        /// <param name="shiftID">ShiftID to be removed</param>
        /// <returns>Number of rows affected</returns>
        int RemoveShift(int shiftID);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-07
        ///     CHECKED BY: Zoey McDonald
        ///     Method for adding a shif to the DB
        /// </summary>
        /// <param name="shift">Shift Object to be added</param>
        /// <returns>Number of rows affected</returns>
        int AddShift(VolunteerShift shift);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-02
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The number of rows affected</returns>
        int SignVolunteerUpForShift(int volunteerID, int volunteerShiftID);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-08
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The number of rows affected</returns>
        int CancelVolunteerShift(int volunteerID, int volunteerShiftID);
    }
}
