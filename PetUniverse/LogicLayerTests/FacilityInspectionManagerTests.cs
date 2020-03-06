using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/28/2020
    /// Approver: Ethan Murphy 3/6/2020
    /// Approver: 
    /// 
    /// Test Class to test the logic layer facility inspection class class
    /// </summary>
    [TestClass]
    public class FacilityInspectionManagerTests
    {
        private IFacilityInspectionAccessor _fakeFacilityInspectionAccessor;
        private FacilityInspectionManager _facilityInspectionManager;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// Method to set up the objects for the test
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestInitialize]
        public void TestSetUp()
        {
            _fakeFacilityInspectionAccessor = new FakeFacilityInspectionAccessor();
            _facilityInspectionManager = new FacilityInspectionManager(_fakeFacilityInspectionAccessor);
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Method to test the InsertFacilityInspectionRecord in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestInsertFacilityInspectionRecord()
        {
            // arrange
            FacilityInspection facilityInspection = new FacilityInspection()
            {
                FacilityInspectionID = 1000000,
                UserID = 100000,
                InspectorName = "Bob",
                InspectionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                InspectionDescription = "Inspect cracked window",
                InspectionCompleted = false
            };
            bool result = false;

            // act
            result = _facilityInspectionManager.AddFacilityInspectionRecord(facilityInspection);

            // assert
            Assert.IsTrue(result);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver:
        /// 
        /// Method to tear down the test and clear memory
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _fakeFacilityInspectionAccessor = null;
            _facilityInspectionManager = null;
        }
    }
}
