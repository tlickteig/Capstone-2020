using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
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
    public interface IVolunteerShiftManager
    {
        int AddVolunteerShift(VolunteerShift shift);

        int RemoveVolunteerShift(int shiftID);

        int EditVolunteerShift(VolunteerShift oldShift, VolunteerShift newShift);

        List<VolunteerShift> ReturnAllVolunteerShifts();
    }
}
