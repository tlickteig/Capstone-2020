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
            Assert.AreEqual(2, AnimalActivity.Count);

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

