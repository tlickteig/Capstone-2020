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
                Dosage = 2.0,
                Interval = "2 times a day",
                AdministrationMethod = "Oral",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                Description = "test5"
            };

            // Act
            result = animalPrescriptionManager.AddAnimalPrescriptionRecord(animalPrescription);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
