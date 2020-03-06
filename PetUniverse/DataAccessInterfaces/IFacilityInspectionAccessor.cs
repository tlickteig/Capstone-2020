using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/6/2020
    /// Approver: 
    /// Approver: 
    /// 
    /// Interface for the FacilityInspectionAccessor
    /// </summary>
    public interface IFacilityInspectionAccessor
    {
        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Method to insert a FacilityInspection Record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspection"></param>
        /// <returns>1 or 0 int depending if record was added</returns>
        int InsertFacilityInspectionRecord(FacilityInspection facilityInspection);
    }
}
