using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataAccessInterfaces;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayerInterfaces;
using LogicLayer;


namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// Tests for the logic layer methods
    /// </summary>
    [TestClass]
    public class AnimalManagerTests
    {
        private IAnimalAccessor _animalAccessor;

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// passing in the fake data accessor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _animalAccessor = new FakeAnimalAccessor();
        }


        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// Test for adding a new animal to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAnimalManagerAddNewAnimal()
        {
            // arrange
            bool isValidAnimal = false;
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);

            // act
            Animal animal1 = new Animal()
            {
                AnimalID = 4,
                AnimalName = "D",
                Dob = DateTime.Now.Date,
                AnimalBreed = "D",
                ArrivalDate = DateTime.Now.Date,
                ImageLocation = "D",
                CurrentlyHoused = true,
                Adoptable = true,
                Active = true,
                AnimalSpeciesID = "D",
                StatusID = "D"
            };
            isValidAnimal = animalManager.AddNewAnimal(animal1);

            // assert
            Assert.IsTrue(isValidAnimal);
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// Test for getting a list of animals that are marked as active
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAnimalManagerSelectAnimalsByActive()
        {
            // arrange
            bool active = true;
            List<Animal> testAnimals;
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);

            // act
            testAnimals = animalManager.RetrieveAnimalsByActive(active);

            // assert
            Assert.IsNotNull(testAnimals);
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// Test for getting a list of animals that are marked as active
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAnimalManagerSelectAnimalsByInactive()
        {
            // arrange
            bool active = false;
            List<Animal> testAnimals;
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);

            // act
            testAnimals = animalManager.RetrieveAnimalsByActive(active);

            // assert
            Assert.IsNotNull(testAnimals);
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020 
        /// 
        /// Test clean up
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _animalAccessor = null;
        }
    }
}
