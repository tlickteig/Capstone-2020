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
    /// Creator: Carl Davis
    /// Created: 2/28/2020
    /// Approver: 
    /// Approver: 
    /// 
    /// Class to test the logic layer unit tests
    /// </summary>
    public class FakeFacilityInspectionAccessor : IFacilityInspectionAccessor
    {
        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Method to insert a fake FacilityInspectioneRecord
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspection"></param>
        /// <returns>1 or 0 depending if the record matches the data</returns>
        public int InsertFacilityInspectionRecord(FacilityInspection facilityInspection)
        {
            DateTime insepctionDate = new DateTime(2018, 7, 10, 7, 10, 24);
            if (facilityInspection.FacilityInspectionID == 1000000 && facilityInspection.UserID == 100000 && facilityInspection.InspectorName == "Bob"
                && facilityInspection.InspectionDate == insepctionDate
                && facilityInspection.InspectionDescription == "Inspect cracked window" 
                && facilityInspection.InspectionCompleted == false)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
