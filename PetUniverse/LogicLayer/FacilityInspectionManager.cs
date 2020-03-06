using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/28/2020
    /// Approver: Ethan Murphy 3/6/2020
    /// Approver: 
    /// 
    /// Class to pass information from the Accessor to Presentation layer
    /// </summary>
    public class FacilityInspectionManager : IFacilityInspectionManager
    {

        public IFacilityInspectionAccessor _facilityInspectionAccessor;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver:
        /// 
        /// Constructor to instaniate instance variables
        /// </summary> 
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityInspectionManager()
        {
            _facilityInspectionAccessor = new FacilityInspectionAccessor();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Constructor to instaniate instance variables to the parameter for the fake accessor
        /// </summary> 
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionAccessor"></param>
        public FacilityInspectionManager(IFacilityInspectionAccessor facilityInspectionAccessor)
        {
            _facilityInspectionAccessor = facilityInspectionAccessor;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Method to add a FacilityInspectionRecord
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspection"></param>
        /// <returns>true or false depending on if record was updated</returns>
        public bool AddFacilityInspectionRecord(FacilityInspection facilityInspection)
        {
            bool result = true;

            try
            {
                result = 1 == _facilityInspectionAccessor.InsertFacilityInspectionRecord(facilityInspection);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to create record!", ex);
            }

            return result;
        }
    }
}
