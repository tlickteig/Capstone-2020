using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataTransferObjects;
using DataAccessInterfaces;
using DataAccessFakes;
using LogicLayer;

namespace LogicLayerTests
{ /// <summary>
  /// Creator: Tener karar
  /// Created: 2020/02/7
  /// Approver: Zach Behrensmeyer
  ///
  /// The test class for item and bake stock menger
  /// Contains all test methods for manging the stock record and item functions
  /// </summary>

    [TestClass]
    public class BackRecordMangerTester
    {
        private IbackstockAccessor _BackRecordAccessorFakes;
        private ManageBackstockRecords manageBackstockRecords;

        [TestInitialize]
        public void TestSetup()
        {
            _BackRecordAccessorFakes = new BackRecordAccessorFakes();
            manageBackstockRecords = new ManageBackstockRecords(_BackRecordAccessorFakes);

        }
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Zach Behrensmeyer
        /// 
        // testing the  Edit Item Location method 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>

        [TestMethod]
        public void TestEditItemLocation()
        {
            // arrange

            int itemID = 1000;
            int itemLocationID = 1000;
            int NewItemLocation = 1003;

            // act
            bool result = manageBackstockRecords.EditItemLocation(itemID, itemLocationID, NewItemLocation);

            // assert
            Assert.AreEqual(true, result);

        }
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Zach Behrensmeyer
        /// 
        //testing the  getItemLocations method
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>

        [TestMethod]
        public void TestGetItemLocations()
        {
            // arrange

            int item = 1000;
            List<int> itemLocationTest = new List<int>();

            // act
            itemLocationTest = manageBackstockRecords.getItemLocations(item);

            // assert
            Assert.AreEqual(2, itemLocationTest.Count);

        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Zach Behrensmeyer
        /// 
        // this test method for geting  Pets In Back Room 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestGetPetsInBackRoom()
        {
            // arrange
            List<Item> pets = new List<Item>();

            // act
            pets = manageBackstockRecords.getPetsInBackRoom();

            // assert
            Assert.AreEqual(1, pets.Count);
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Zach Behrensmeyer
        /// 
        /// Method to reset all variable for next test run.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA 
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _BackRecordAccessorFakes = null;
        }
    }
}
