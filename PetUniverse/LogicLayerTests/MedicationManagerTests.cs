using System;
using System.Collections.Generic;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterfaces;
using DataAccessLayer;


namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/13/2020
    /// Approver: Chuck Baxter, 2/13/2020
    /// 
    /// Test class for medication manager
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>

    [TestClass]
    public class MedicationManagerTests
    {
        private FakeMedicationAccessor FakeMedAccessor;

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// No argument Constructor for medication manager tests
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public MedicationManagerTests()
        {
            FakeMedAccessor = new FakeMedicationAccessor();
        }
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Test method for retrieving Medication inventory with the correct value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        [TestMethod]
        public void TestRetrieveMedicationInventoryWithCorrectValue()
        {
            // arrange
            List<Medication> Meds;
            IMedicationManager Meds_ = new MedicationManager(FakeMedAccessor);

            // act
            Meds = Meds_.RetrieveMedicationInventory();

            // assert
            Assert.AreEqual(3, Meds.Count);

        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Test method cleanup
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            FakeMedAccessor = null;

        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Chuck Baxter, 2/21/2020 
        /// Approver: Ethan Murphy 2/21/2020
        /// 
        /// Test for creating a medication order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestCreateMedicationOrder()
        {
            // arrange
            bool meds;
            bool expResult = true;
            IMedicationManager medManager = new MedicationManager(FakeMedAccessor);

            int ItemID = 1;
            string ItemName = "Med_C";
            int ItemQuantity = 1;


            // act
            meds = medManager.CreateMedicationOrder(ItemID, ItemName, ItemQuantity);

            // assert
            Assert.AreEqual(expResult, meds);

        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// Approver:
        /// 
        /// Test method for CreateMedicationOrder- tests for throwing the correct exception
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateMedicationOrderThrowsCorrectException()
        {
            // arrange
            IMedicationManager _AnimalChecklistManager = new MedicationManager(FakeMedAccessor);

            int ItemID = 0;

            string ItemName = null;

            int ItemQuantity = 0;

            // act
            _AnimalChecklistManager.CreateMedicationOrder(ItemID, ItemName, ItemQuantity);

        }



        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/5/2020
        /// Approver: Carl Davis, 3/6/2020
        /// Approver:
        /// 
        /// Test method for RetrieveMedicationByLowQauntity
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveMedicationByLowQauntity()
        {
            // arrange
            List<Medication> Meds;
            IMedicationManager Meds_ = new MedicationManager(FakeMedAccessor);

            // act
            Meds = Meds_.RetrieveMedicationByLowQauntity();

            // assert
            Assert.AreEqual(0, Meds.Count);

        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/5/2020
        /// Approver: Carl Davis, 3/6/2020
        /// Approver:
        /// 
        /// Test method for RetrieveMedicationByLowQauntity- throws correct exception
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRetrieveMedicationByLowQauntityThrowsCorrectException()
        {
            // arrange
            IMedicationManager _AnimalMedManager = new MedicationManager(null);

            // act
            _AnimalMedManager.RetrieveMedicationByLowQauntity();

        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/5/2020
        /// Approver: Carl Davis, 3/6/2020
        /// Approver:
        /// 
        /// Test method for RetrieveMedicationByEmptyQauntity
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveMedicationByEmptyQauntity()
        {
            // arrange
            List<Medication> Meds;
            IMedicationManager Meds_ = new MedicationManager(FakeMedAccessor);

            // act
            Meds = Meds_.RetrieveMedicationByEmptyQauntity();

            // assert
            Assert.AreEqual(0, Meds.Count);

        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/5/2020
        /// Approver: Carl Davis, 3/6/2020 
        /// Approver:
        /// 
        /// Test method for RetrieveMedicationByEmptyQauntity- Throws correct exception
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRetrieveMedicationByEmptyQauntityThrowsCorrectException()
        {
            // arrange
            IMedicationManager _AnimalMedManager = new MedicationManager(null);

            // act
            _AnimalMedManager.RetrieveMedicationByEmptyQauntity();

        }



    }
}

