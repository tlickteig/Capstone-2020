using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME:Lane Sandburg
    /// DATE: 02/05/2019
    /// CHECKED BY:NA
    /// 
    /// the shiftTime Accessor Interface.
    /// </summary>
    /// <remarks>
    /// UPDATED BY:NA
    /// UPDATED DATE:
    /// WHAT WAS CHANGED:
    /// </remarks> 
    public interface IShiftTimeAccessor
    {
        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2020
        /// Approver:Alex Diers
        /// 
        /// defenition for Insert a new ShiftTime
        /// and sets parameters for insertion
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: (example: Fixed a problem when user inputs bad data)
        /// </remarks>
        /// <param name="shiftTime"></param>
        int InsertShiftTime(PetUniverseShiftTime shiftTime);

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/13/2020
        /// Approver:Alex Diers
        /// 
        /// defenition for update a new ShiftTime
        /// and sets parameters for insertion
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: (example: Fixed a problem when user inputs bad data)
        /// </remarks>
        /// <param name="oldShiftTime"></param>
        /// <param name="newShiftTime"></param>
        int UpdateShiftTime(PetUniverseShiftTime oldShiftTime, PetUniverseShiftTime newShiftTime);

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/13/2020
        /// Approver:Alex Diers
        /// 
        /// defenition for select all ShiftTime
        /// and sets parameters for insertion
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: (example: Fixed a problem when user inputs bad data)
        /// </remarks>
        List<PetUniverseShiftTime> SelectAllShiftTimes();
    }
}
