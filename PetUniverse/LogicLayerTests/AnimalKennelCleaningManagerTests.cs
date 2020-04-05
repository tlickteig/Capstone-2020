using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessInterfaces;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayerInterfaces;
using LogicLayer;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/4/2020
    /// 
    /// Unit tests for the kennel cleaning record related methods
    /// </summary>
    [TestClass]
    public class AnimalKennelCleaningManagerTests
    {
        private IAnimalKennelCleaningAccessor _cleaningAccessor;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Constructor to set up the fake data accessor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalKennelCleaningManagerTests()
        {
            _cleaningAccessor = new FakeAnimalKennelCleaningAccessor();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Test for adding a kennel cleaning record. Good value.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddKennelCleaningRecordSuccess()
        {
            //Arrange
            IAnimalKennelCleaningManager cleaningManager = new AnimalKennelCleaningManager(_cleaningAccessor);
            const bool expectedResult = true;
            AnimalKennelCleaningRecord cleaningRecord = new AnimalKennelCleaningRecord() { AnimalKennelID = 1, Date = DateTime.Now, FacilityKennelCleaningID = 3, Notes = "bubba", UserID = 1 };

            //Act
            bool actualResult = cleaningManager.AddKennelCleaningRecord(cleaningRecord);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Test for adding a kennel cleaning record. Simulated database error.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestAddKennelCleaningRecordFailure()
        {
            //Arrange
            IAnimalKennelCleaningManager cleaningManager = new AnimalKennelCleaningManager(_cleaningAccessor);
            AnimalKennelCleaningRecord cleaningRecord = new AnimalKennelCleaningRecord() { AnimalKennelID = 1, Date = DateTime.Now, FacilityKennelCleaningID = 0, Notes = "bubba", UserID = 1 };

            //Act
            bool actualResult = cleaningManager.AddKennelCleaningRecord(cleaningRecord);

            //Assert
        }

    }
}
