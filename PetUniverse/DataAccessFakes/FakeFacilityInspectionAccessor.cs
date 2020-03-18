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

        private List<FacilityInspection> facilityInspections = new List<FacilityInspection>()
        {
            new FacilityInspection()
            {
                FacilityInspectionID = 1000000,
                UserID = 100000,
                InspectorName = "Bob",
                InspectionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                InspectionDescription = "Inspect cracked window",
                InspectionCompleted = false
            },
            new FacilityInspection()
            {
                FacilityInspectionID = 1000001,
                UserID = 100000,
                InspectorName = "Bob",
                InspectionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                InspectionDescription = "Inspect cracked window",
                InspectionCompleted = false
            },
            new FacilityInspection()
            {
                FacilityInspectionID = 1000002,
                UserID = 100001,
                InspectorName = "Bob",
                InspectionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                InspectionDescription = "Inspect cracked window",
                InspectionCompleted = false
            }
        };

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

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to test select all FacilityInspection Records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspection> SelectAllFacilityInspection(bool inspectionComplete)
        {
            var selectedFacilityInspections = (from f in facilityInspections
                                               select f).ToList();

            return selectedFacilityInspections;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to test select FacilityInspection Records by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionID"></param>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspection> SelectFacilityInspectionByID(int facilityInspectionID, bool inspectionComplete)
        {
            var selectedFacilityInspections = (from f in facilityInspections
                                               where f.FacilityInspectionID == facilityInspectionID
                                               select f).ToList();

            return selectedFacilityInspections;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to test select FacilityInspection Records by inspector name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="inspectorName"></param>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspection> SelectFacilityInspectionByInspectorName(string inspectorName, bool inspectionComplete)
        {
            var selectedFacilityInspections = (from f in facilityInspections
                                               where f.InspectorName == inspectorName
                                               select f).ToList();

            return selectedFacilityInspections;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to test select FacilityInspection Records by userID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspection> SelectFacilityInspectionByUserID(int userID, bool inspectionComplete)
        {
            var selectedFacilityInspections = (from f in facilityInspections
                                               where f.UserID == userID
                                               select f).ToList();

            return selectedFacilityInspections;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/13/2020
        /// Approver: Chuck Baxter, 3/18/2020
        /// 
        /// Method to update a facility maintenance record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityInspection"></param>
        /// <param name="newFacilityInspection"></param>
        /// <returns>1 or 0 int if they are equal</returns>
        public int UpdateFacilityInspection(FacilityInspection oldFacilityInspection, FacilityInspection newFacilityInspection)
        {
            oldFacilityInspection = newFacilityInspection;

            if (oldFacilityInspection.Equals(newFacilityInspection))
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
