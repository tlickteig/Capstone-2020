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
        List<VolunteerShift> SelectAllShifts();

        VolunteerShift SelectShift(int shiftID);

        int UpdateShift(VolunteerShift oldShift, VolunteerShift newShift);

        int RemoveShift(int shiftID);

        int AddShift(VolunteerShift shift);
    }
}
