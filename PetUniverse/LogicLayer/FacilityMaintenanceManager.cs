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
    /// Created: 2/6/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// Class to pass information from the Accessor to Presentation layer
    /// </summary>
    public class FacilityMaintenanceManager : IFacilityMaintenanceManager
    {

        public IFacilityMaintenanceAccessor _facilityMaintenanceAccessor;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/6/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// Approver by Daulton Schilling, 2/7/2020
        /// 
        /// Constructor to instaniate instance variables
        /// </summary> 
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityMaintenanceManager()
        {
            _facilityMaintenanceAccessor = new FacilityMaintenanceAccessor();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/6/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// Constructor to instaniate instance variables to the parameter for the fake accessor
        /// </summary> 
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityMaintenanceAccessor"></param>
        public FacilityMaintenanceManager(IFacilityMaintenanceAccessor facilityMaintenanceAccessor)
        {
            _facilityMaintenanceAccessor = facilityMaintenanceAccessor;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/6/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// Method to add a FacilityMaintenanceRecord
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityMaintenance"></param>
        /// <returns>true or false depending on if record was updated</returns>
        public bool AddFacilityMaintenanceRecord(FacilityMaintenance facilityMaintenance)
        {
            bool result = true;

            try
            {
                result = 1 == _facilityMaintenanceAccessor.InsertFacilityMaintenanceRecord(facilityMaintenance);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to create record!", ex);
            }

            return result;
        }



        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to retrieve all facility maintenance records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List<FacilityMaintenance> objects</returns>
        public List<FacilityMaintenance> RetrieveAllFacilityMaintenance()
        {
            try
            {
                return _facilityMaintenanceAccessor.SelectAllFacilityMaintenance();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Facility Maintenance Record Not Found!", ex);
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to retrieve a facility maintenance record by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="facilityMaintenanceID"></param>
        /// <returns>FacilityMaintenance object</returns>
        public FacilityMaintenance RetrieveFacilityMaintenanceByFacilityMaintenanceID(int facilityMaintenanceID)
        {
            if (facilityMaintenanceID < 1000000)
            {
                throw new ArgumentOutOfRangeException("Facility Maintenance ID is out of range.");
            }
            try
            {
                return _facilityMaintenanceAccessor.SelectFacilityMaintenanceByFacilityMaintenanceID(facilityMaintenanceID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Facility Maintenance Record Not Found!", ex);
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to retrieve a facility maintenance record by user id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns>List<FacilityMaintenance> objects</returns>
        public List<FacilityMaintenance> RetrieveFacilityMaintenanceByUserID(int userID)
        {
            if (userID < 100000)
            {
                throw new ArgumentOutOfRangeException("User ID is out of range.");
            }
            try
            {
                return _facilityMaintenanceAccessor.SelectFacilityMaintenanceByUserID(userID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Facility Maintenance Record Not Found!", ex);
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to retrieve a facility maintenance record by maintenance name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityMaintenanceName"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityMaintenance> RetrieveFacilityMaintenanceFacilityMaintenanceName(string facilityMaintenanceName)
        {
            try
            {
                return _facilityMaintenanceAccessor.SelectFacilityMaintenanceFacilityMaintenanceName(facilityMaintenanceName);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Facility Maintenance Record Not Found!", ex);
            }
        }



        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/14/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Schilling, 2/21/2020
        /// 
        /// Method to Edit a facility maintenance record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityMaintenance"></param>
        /// <param name="newFacilityMaintenance"></param>
        /// <returns>1 or 0 int depending if record was updated</returns>
        public bool EditFacilityMaintenance(FacilityMaintenance oldFacilityMaintenance, FacilityMaintenance newFacilityMaintenance)
        {

            bool result = false;

            try
            {
                result = 1 == _facilityMaintenanceAccessor.UpdateFacilityMaintenance(oldFacilityMaintenance, newFacilityMaintenance);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update Maintenance Record Failed!", ex);
            }

            return result;
        }
    }


}
