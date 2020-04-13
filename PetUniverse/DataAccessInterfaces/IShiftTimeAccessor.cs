using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Lane Sandburg
    /// Created: 02/06/2020
    /// Approver: Alex Diers
    /// 
    /// the shiftTime Accessor Interface.
    /// </summary>
    public interface IShiftTimeAccessor
    {

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2020
        /// Approver: Alex Diers
        /// 
        /// definition for Insert a new ShiftTime and sets parameters for insertion
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
        /// Approver: Alex Diers
        /// 
        /// definition for update a new ShiftTime and sets parameters for insertion
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
        /// Approver: Alex Diers
        /// 
        /// definition for select all ShiftTime and sets parameters for insertion
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: (example: Fixed a problem when user inputs bad data)
        /// </remarks>
        List<PetUniverseShiftTime> SelectAllShiftTimes();

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 03/05/2020
        /// Approver: Kaleb Bachert
        /// 
        /// definition for Deleteing a new ShiftTime and sets parameters for delete
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: (example: Fixed a problem when user inputs bad data)
        /// </remarks>
        /// <param name="shiftTime"></param>
        int DeleteShiftTime(int shiftTimeID);


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// This is an interface method for selecting Shift times by departmentID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        List<PetUniverseShiftTime> SelectShiftTimeByDepartment(string departmentID);
    }
}