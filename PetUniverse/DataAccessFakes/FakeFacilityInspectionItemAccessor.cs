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
    /// Created: 3/30/2020
    /// Approver: Ethan Murphy 4/3/2020
    /// Approver: 
    /// 
    /// Class to test the logic layer unit tests
    /// </summary>
    public class FakeFacilityInspectionItemAccessor : IFacilityInspectionItemAccessor
    {

        private List<FacilityInspectionItem> facilityInspectionItems = new List<FacilityInspectionItem>()
        {
            new FacilityInspectionItem()
            {
                FacilityInspectionItemID = 1000000,
                ItemName = "Pen",
                UserID = 100000,
                FacilityInpectionID = 1000000,
                ItemDescription = "To fill out reports"
            },
            new FacilityInspectionItem()
            {
                FacilityInspectionItemID = 1000001,
                ItemName = "Pen",
                UserID = 100001,
                FacilityInpectionID = 1000001,
                ItemDescription = "To fill out reports"
            },
            new FacilityInspectionItem()
            {
                FacilityInspectionItemID = 1000002,
                ItemName = "Pen",
                UserID = 100001,
                FacilityInpectionID = 1000001,
                ItemDescription = "To fill out reports"
            }
        };

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to insert a fake FacilityInspectionItem Record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionItem"></param>
        /// <returns>1 or 0 int depending if record was added</returns>
        public int InsertFacilityInspectionItemRecord(FacilityInspectionItem facilityInspectionItem)
        {

            if (facilityInspectionItem.FacilityInspectionItemID == 1000000 && facilityInspectionItem.ItemName == "Pen" && facilityInspectionItem.UserID == 100000
                && facilityInspectionItem.FacilityInpectionID == 1000000
                && facilityInspectionItem.ItemDescription == "To fill out reports")
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
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to test select all FacilityInspectionItem Records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectAllFacilityInspectionItem()
        {
            var selectedFacilityInspectionItems = (from f in facilityInspectionItems
                                                   select f).ToList();

            return selectedFacilityInspectionItems;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to test select FacilityInspectionItem Records by Facility Inspection ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectFacilityInspectionByFacilityInspectionID(int facilityInspectionID)
        {
            var selectedFacilityInspections = (from f in facilityInspectionItems
                                               where f.FacilityInpectionID == facilityInspectionID
                                               select f).ToList();

            return selectedFacilityInspections;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to test select FacilityInspectionItem Records by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionItemID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectFacilityInspectionByItemID(int facilityInspectionItemID)
        {
            var selectedFacilityInspections = (from f in facilityInspectionItems
                                               where f.FacilityInspectionItemID == facilityInspectionItemID
                                               select f).ToList();

            return selectedFacilityInspections;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to test select FacilityInspectionItem Records by userID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectFacilityInspectionByUserID(int userID)
        {
            var selectedFacilityInspections = (from f in facilityInspectionItems
                                               where f.UserID == userID
                                               select f).ToList();

            return selectedFacilityInspections;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to test select FacilityInspectionItem Records by item name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="itemName"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectFacilityInspectionItemByItemName(string itemName)
        {
            var selectedFacilityInspections = (from f in facilityInspectionItems
                                               where f.ItemName == itemName
                                               select f).ToList();

            return selectedFacilityInspections;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// Method to test update a facility inspection item record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityInspectionItem"></param>
        /// <param name="newFacilityInspectionItem"></param>
        /// <returns>1 or 0 int depending if record was updated</returns>
        public int UpdateFacilityInspectionItem(FacilityInspectionItem oldFacilityInspectionItem, FacilityInspectionItem newFacilityInspectionItem)
        {
            oldFacilityInspectionItem = newFacilityInspectionItem;

            if (oldFacilityInspectionItem.Equals(newFacilityInspectionItem))
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
