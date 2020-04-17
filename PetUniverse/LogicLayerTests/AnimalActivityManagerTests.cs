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
    ///Test class for AnimalActivityManagerTests
    /// </summary>
    /// <remarks>
    /// Name: AnimalActivityManagerTests (Class)
    /// Date: 2/6/2020
    /// Created by: Daulton Schilling
    /// Reviewed by: Carl Davis, 2/7/2020
    /// Reviewed by: Chuck Baxter, 2/7/2020
    /// </remarks>
    [TestClass]
    public class AnimalActivityManagerTests
    {
        private IAnimalActivityAccessor _fakeActivityAccessor;


        /// <summary>
        ///Implements FakeAnimalActivityAccessor
        /// </summary>
        /// <remarks>
        /// Name: AnimalActivityManagerTests
        /// Date: 2/7/2020
        /// Created by: Daulton Schilling
        /// Reviewed by: Carl Davis, 2/7/2020
        /// Reviewed by: Chuck Baxter, 2/7/2020
        /// </remarks>

        public AnimalActivityManagerTests()
        {
            _fakeActivityAccessor = new FakeAnimalActivityAccessor();
        }

        /// <summary>
        /// Tests RetrieveAnimalFeedingRecords against the dataAccessFakes records
        /// </summary>
        /// <remarks>
        /// Name: TestRetrieveAnimalFeedingRecords
        /// Date: 2/7/2020
        /// Created by: Daulton Schilling
        /// Reviewed by: Carl Davis, 2/7/2020
        /// Reviewed by: Chuck Baxter, 2/7/2020
        /// </remarks>
        /// <param>
        /// </param>
        /// <returns>
        ///  Passed
        /// </returns>
        [TestMethod]
        public void TestRetrieveAnimalFeedingRecords()
        {
            // arrange
            List<AnimalActivity> AnimalActivity;
            IAnimalActivityManager _animalActivity = new AnimalActivityManager(_fakeActivityAccessor);

            // act
            AnimalActivity = _animalActivity.RetrieveAnimalFeedingRecords();

            // assert
            Assert.AreEqual(4, AnimalActivity.Count);

        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver:
        /// Approver:
        /// 
        /// Test method for RetrieveAnimalFeedingRecords- tests for throwing the correct exception
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestRetrieveAnimalByAnimalIDThrowsCorrectException()
        {

            // arrange
            _fakeActivityAccessor = null;
            IAnimalActivityManager _AnimalChecklistManager = new AnimalActivityManager(_fakeActivityAccessor);


            // act
            _AnimalChecklistManager.RetrieveAnimalFeedingRecords();

        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Tests retrieving animals by activity type.
        /// Tests both valid and invalid activity types
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAnimalActivityByActivityType()
        {
            // Arrange
            IAnimalActivityManager manager =
                new AnimalActivityManager(_fakeActivityAccessor);
            string validActivityType = "Play";
            string invalidActivityType = "the";
            List<AnimalActivity> validList;
            List<AnimalActivity> invalidList;

            // Act
            validList = manager.RetrieveAnimalActivitiesByActivityType(validActivityType);
            invalidList = manager.RetrieveAnimalActivitiesByActivityType(invalidActivityType);

            // Assert
            Assert.AreEqual(validList.Count, 2);
            Assert.AreEqual(invalidList.Count, 0);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Tests retrieving all activity types
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllAnimalActivityTypes()
        {
            // Arrange
            IAnimalActivityManager manager =
                new AnimalActivityManager(_fakeActivityAccessor);
            List<AnimalActivityType> activityTypes;

            // Act
            activityTypes = manager.RetrieveAllAnimalActivityTypes();

            // Assert
            Assert.AreEqual(activityTypes.Count, 2);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Tests inserting animal activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddingAnimalActivityRecord()
        {
            // Arrange
            IAnimalActivityManager manager =
                new AnimalActivityManager(_fakeActivityAccessor);
            bool result = false;
            AnimalActivity activity = new AnimalActivity()
            {
                AnimalActivityId = 1000,
                AnimalID = 1,
                UserID = 1,
                AnimalActivityTypeID = "Play"
            };

            // Act
            result = manager.AddAnimalActivityRecord(activity);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/6/2020
        /// Approver: Chuck Baxter 4/7/2020
        /// 
        /// Tests editing existing record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestEditingExistingActivityRecord()
        {
            // Arrange
            bool result = false;
            IAnimalActivityManager manager =
                new AnimalActivityManager(_fakeActivityAccessor);
            AnimalActivity existingRecord = new AnimalActivity()
            {
                AnimalActivityId = 1,
                AnimalID = 5,
                AnimalActivityTypeID = "Play"
            };
            AnimalActivity updatedRecord = new AnimalActivity()
            {
                AnimalActivityId = 1,
                AnimalID = 4,
                AnimalActivityTypeID = "Play"
            };

            // Act
            manager.AddAnimalActivityRecord(existingRecord);
            result = manager.EditExistingAnimalActivityRecord(
                existingRecord, updatedRecord);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/6/2020
        /// Approver: Chuck Baxter 4/7/2020
        /// 
        /// Tests editing a non existent record. Result should be false
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestEditingNonExistentActivityRecord()
        {
            // Arrange
            bool result = false;
            IAnimalActivityManager manager =
                new AnimalActivityManager(_fakeActivityAccessor);
            AnimalActivity nonExistentRecord = new AnimalActivity()
            {
                AnimalActivityId = 3,
                AnimalID = 6,
                AnimalActivityTypeID = "Feeding"
            };
            AnimalActivity updatedRecord = new AnimalActivity()
            {
                AnimalActivityId = 1,
                AnimalID = 4,
                AnimalActivityTypeID = "Play"
            };

            // Act
            result = manager.EditExistingAnimalActivityRecord(
                nonExistentRecord, updatedRecord);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// Tests inserting animal activity type record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddingAnimalActivityTypeRecord()
        {
            // Arrange
            IAnimalActivityManager manager = new AnimalActivityManager(_fakeActivityAccessor);
            bool result = false;
            AnimalActivityType activityType = new AnimalActivityType()
            {
                ActivityTypeId = "Sample Activity Type",
                Description = "This is a description"
            };

            // Act
            result = manager.AddAnimalActivityType(activityType);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// Tests updating animal activity type record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestUpdatingAnimalActivityTypeRecord()
        {
            // Arrange
            IAnimalActivityManager manager = new AnimalActivityManager(_fakeActivityAccessor);
            bool result = false;
            AnimalActivityType activityType = new AnimalActivityType()
            {
                ActivityTypeId = "Feeding",
                Description = "This is a description"
            };

            // Act
            result = manager.AddAnimalActivityType(activityType);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// Tests deleting animal activity type record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeletingAnimalActivityTypeRecord()
        {
            // Arrange
            IAnimalActivityManager manager = new AnimalActivityManager(_fakeActivityAccessor);
            bool result = false;
            AnimalActivityType activityType = new AnimalActivityType()
            {
                ActivityTypeId = "Feeding",
                Description = "This is a description"
            };

            // Act
            result = manager.AddAnimalActivityType(activityType);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tear down the test
        /// </summary>
        /// <remarks>
        /// Name: TestTearDown
        /// Date: 2/7/2020
        /// Created by: Daulton Schilling
        /// Reviewed by: Carl Davis, 2/7/2020
        /// Reviewed by: Chuck Baxter, 2/7/2020
        /// </remarks>

        [TestCleanup]
        public void TestTearDown()
        {
            _fakeActivityAccessor = null;

        }
    }
}

