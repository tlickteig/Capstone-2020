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
        /// Updater: Chuck Baxter
        /// Updated: 2/28/2020
        /// Update: Removed status and image location
        /// Approver: Austin Gee
        /// 
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
                CurrentlyHoused = true,
                Adoptable = true,
                Active = true,
                AnimalSpeciesID = "D"
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
        /// Created: 2/28/2020
        /// Approver: Jordan Lindo, 2/28/2020
        /// Approver: 
        /// 
        /// Test for getting a list of animals species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAnimalManagerSelectAnimalSpecies()
        {
            // arrange
            List<string> testSpecies;
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);

            // act
            testSpecies = animalManager.RetrieveAnimalSpecies();

            // assert
            Assert.IsNotNull(testSpecies);
        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/14/2020
        /// Approver: Austin Gee
        /// Approver: 
        /// 
        /// Test for getting a list of animal profiles
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAnimalManagerSelectAllAnimalProfiles()
        {
            // arrange
            List<Animal> testAnimals;
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);

            // act
            testAnimals = animalManager.RetrieveAllAnimalProfiles();

            // assert
            Assert.IsNotNull(testAnimals);
        }

        /// <summary>
        /// Creator: michael Thompson
        /// Created: 2/6/2020
        /// Approver: Austin Gee
        /// 
        /// Test for updating the animal profile
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAnimalManagerUpdateAnimalProfile()
        {
            // arrange
            bool result = false;
            int animalID = 100000;
            string profileDescription = "Test profile";
            string profileImagePath = "/images";
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);

            // act
            result = animalManager.UpdatePetProfile(animalID, profileDescription, profileImagePath);

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/12/2020
        /// Approver: Austin Gee, 3/12/2020
        /// 
        /// Test for updating an animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAnimalManagerEditAnimal()
        {
            // arrange
            bool result = false;
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);

            // act
            Animal animal1 = new Animal()
            {
                AnimalID = 1,
                AnimalName = "D",
                Dob = DateTime.Now.Date,
                AnimalBreed = "D",
                ArrivalDate = DateTime.Now.Date,
                CurrentlyHoused = true,
                Adoptable = true,
                Active = true,
                AnimalSpeciesID = "D"
            };
            Animal animal2 = new Animal()
            {
                AnimalID = 1,
                AnimalName = "D",
                Dob = DateTime.Now.Date,
                AnimalBreed = "D",
                ArrivalDate = DateTime.Now.Date,
                CurrentlyHoused = true,
                Adoptable = true,
                Active = true,
                AnimalSpeciesID = "D"
            };
            result = animalManager.EditAnimal(animal1, animal2);

            // assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Activate animal, pass a good value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestActivateAnimalGoodValue()
        {
            //arrange
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);
            const bool expectedResult = true;

            //act
            bool actualResult = animalManager.SetAnimalActiveState(true, 1);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Activate animal, pass a bad value
        /// </summary>
        /// <remarks>
        /// Coded by Ben Hanna - 2/5/2020
        /// reviewed by Carl Davis 2/7/2020
        /// reviewed by Chuck Baxter 2/7/2020
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestActivateAnimalBadValue()
        {

            //arrange
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);
            const bool expectedResult = false;

            //act
            bool actualResult = animalManager.SetAnimalActiveState(true, 0);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Deactivate animal, pass a good value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeactivateAnimalGoodValue()
        {

            //arrange
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);
            const bool expectedResult = true;

            //act
            bool actualResult = animalManager.SetAnimalActiveState(false, 1);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Dectivate animal, pass a bad value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeactivateAnimalBadValue()
        {

            //arrange
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);
            const bool expectedResult = false;

            //act
            bool actualResult = animalManager.SetAnimalActiveState(false, 0);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// House animal, pass a good value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestActivateHousedGoodValue()
        {

            //arrange
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);
            const bool expectedResult = true;

            //act
            bool actualResult = animalManager.SetAnimalHousedState(true, 1);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// House animal, pass a bad value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestActivateHousedBadValue()
        {

            //arrange
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);
            const bool expectedResult = false;

            //act
            bool actualResult = animalManager.SetAnimalHousedState(true, 0);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Unhouse animal, pass a good value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeactivateHousedGoodValue()
        {

            //arrange
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);
            const bool expectedResult = true;

            //act
            bool actualResult = animalManager.SetAnimalHousedState(false, 1);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Unhouse animal, pass a bad value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeactivateHousedBadValue()
        {

            //arrange
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);
            const bool expectedResult = false;

            //act
            bool actualResult = animalManager.SetAnimalHousedState(false, 0);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Set adoptable, pass a good value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestActivateAdoptableGoodValue()
        {

            //arrange
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);
            const bool expectedResult = true;

            //act
            bool actualResult = animalManager.SetAnimalAdoptableState(true, 1);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Set adoptable, pass a bad value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestActivateAdoptableBadValue()
        {

            //arrange
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);
            const bool expectedResult = false;

            //act
            bool actualResult = animalManager.SetAnimalAdoptableState(true, 0);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Unset adoptable, pass a good value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeactivateAdoptableGoodValue()
        {

            //arrange
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);
            const bool expectedResult = true;

            //act
            bool actualResult = animalManager.SetAnimalAdoptableState(false, 1);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Unset adoptable, pass a good value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeactivateAdoptableBadValue()
        {

            //arrange
            IAnimalManager animalManager = new AnimalManager(_animalAccessor);
            const bool expectedResult = false;

            //act
            bool actualResult = animalManager.SetAnimalAdoptableState(false, 0);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
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
