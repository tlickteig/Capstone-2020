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
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/14/2020
    /// Approver: Chuck Baxter, 2/14/2020
    /// 
    /// Unit tests for the kennel related methods
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    [TestClass]
    public class AnimalKennelManagerTests
    {
        private IAnimalKennelAccessor _kennelAccessor;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Constructor that assigns the fake accessor class to be the passed kennel accessor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalKennelManagerTests()
        {
            _kennelAccessor = new FakeAnimalKennelAccessor();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Test for adding a kennel record. Good value.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddKennelRecordSuccess()
        {
            //Arrange
            IAnimalKennelManager kennelManager = new AnimalKennelManager(_kennelAccessor);
            const bool expectedResult = true;
            AnimalKennel kennel = new AnimalKennel() { AnimalID = 1, AnimalKennelID = 1, UserID = 1, AnimalKennelInfo = "Info", AnimalKennelDateIn = DateTime.Now };

            //Act
            bool actualResult = kennelManager.AddKennelRecord(kennel);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Test for adding a kennel record. Will simulate a failure via an error
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestAddKennelRecordFail()
        {
            //Arrange
            IAnimalKennelManager kennelManager = new AnimalKennelManager(_kennelAccessor);
            AnimalKennel kennel = new AnimalKennel() { AnimalID = 1, AnimalKennelID = 0, UserID = 1, AnimalKennelInfo = "Info", AnimalKennelDateIn = DateTime.Now };
            //Act
            kennelManager.AddKennelRecord(kennel);
            //Assert
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Teardown method. You know what this is.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestCleanup]
        public void TestTeardown()
        {
            _kennelAccessor = null;
        }
    }
}
