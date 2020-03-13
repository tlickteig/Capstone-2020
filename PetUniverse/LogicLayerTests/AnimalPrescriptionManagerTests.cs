using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataTransferObjects;
using DataAccessInterfaces;
using DataAccessFakes;
using LogicLayerInterfaces;
using LogicLayer;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/16/2020
    /// Approver: Carl Davis 2/21/2020
    /// Approver: 
    /// 
    /// Test class for the animal prescription manager
    /// </summary>
    [TestClass]
    public class AnimalPrescriptionManagerTests
    {
        private IAnimalPrescriptionsAccessor _animalPrescriptionsAccessor;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver:
        /// 
        /// Default constructor that initializes the fake 
        /// animal prescriptions accessor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalPrescriptionManagerTests()
        {
            _animalPrescriptionsAccessor = new FakeAnimalPrescriptionsAccessor();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver:
        /// 
        /// Tests adding an animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddingNewAnimalPrescriptionsRecord()
        {
            // Arrange
            bool result = false;
            IAnimalPrescriptionManager animalPrescriptionManager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);
            AnimalPrescriptions animalPrescription = new AnimalPrescriptions()
            {
                AnimalID = 5,
                AnimalPrescriptionID = 5,
                AnimalVetAppointmentID = 5,
                PrescriptionName = "test5",
                Dosage = 2.0M,
                Interval = "2 times a day",
                AdministrationMethod = "Oral",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                Description = "test5",
                AnimalName = "wefyawaw"
            };

            // Act
            result = animalPrescriptionManager.AddAnimalPrescriptionRecord(animalPrescription);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Tests retrieving all animal prescription records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestSelectingAllAnimalPrescriptionRecords()
        {
            // Arrange
            List<AnimalPrescriptions> animalPrescriptions =
                new List<AnimalPrescriptions>();
            IAnimalPrescriptionManager animalPrescriptionManager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);

            // Act
            animalPrescriptions = animalPrescriptionManager.RetrieveAllAnimalPrescriptions();

            // Assert
            Assert.AreEqual(4, animalPrescriptions.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Tests retrieving animal prescription records
        /// for a specific animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestSelectPrescriptionRecordsByValidAnimalName()
        {
            // Arrange
            List<AnimalPrescriptions> animalPrescriptions =
                new List<AnimalPrescriptions>();
            IAnimalPrescriptionManager animalPrescriptionManager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);
            string animalName = "fawuief";

            // Act
            animalPrescriptions =
                animalPrescriptionManager.RetrievePrescriptionsByAnimalName(animalName);

            // Assert
            Assert.AreEqual(1, animalPrescriptions.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Tests retrieving animal prescription records
        /// for a specific animal that doesn't exist.
        /// Result should be 0
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestSelectPrescriptionRecordsByAnInvalidAnimalName()
        {
            // Arrange
            List<AnimalPrescriptions> animalPrescriptions =
                new List<AnimalPrescriptions>();
            IAnimalPrescriptionManager animalPrescriptionManager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);
            string animalName = "hrehahsea";

            // Act
            animalPrescriptions =
                animalPrescriptionManager.RetrievePrescriptionsByAnimalName(animalName);

            // Assert
            Assert.AreEqual(0, animalPrescriptions.Count);
        }
    }
}
