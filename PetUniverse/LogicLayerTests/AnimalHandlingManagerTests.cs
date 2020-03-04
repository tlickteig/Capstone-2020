using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessInterfaces;
using DataAccessFakes;
using DataTransferObjects;
using System.Collections.Generic;
using LogicLayerInterfaces;
using LogicLayer;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/21/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver:
    /// 
    /// Test class for the Animal Handling Notes features
    /// </summary>
    [TestClass]
    public class AnimalHandlingManagerTests
    {
        private IAnimalHandlingAccessor _handlingAccessor;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Initialize tests
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _handlingAccessor = new FakeAnimalHandlingAccessor();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver:  Chuck Baxter, 2/21/2020
        /// 
        /// Get handling notes by ID good value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestGetHandlingNotesByIDGoodValue()
        {
            // Arrange
            List<AnimalHandlingNotes> handlingNotes = new List<AnimalHandlingNotes>();
            IAnimalHandlingManager handlingManager = new AnimalHandlingManager(_handlingAccessor);

            // Act
            handlingNotes.Add(handlingManager.GetHandlingNotesByID(100000));

            // Assert
            Assert.AreEqual(1, handlingNotes.Count);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get handling notes by ID bad value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestGetHandlingNotesByIDBadValue()
        {

            // Arrange
            List<AnimalHandlingNotes> handlingNotes = new List<AnimalHandlingNotes>();
            IAnimalHandlingManager handlingManager = new AnimalHandlingManager(_handlingAccessor);

            // Act
            handlingNotes.Add(handlingManager.GetHandlingNotesByID(0));

            // Assert
            Assert.AreEqual(1, handlingNotes.Count);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get handling notes details by animal ID good value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestGetHandlingNotesByAnimalIDGoodValue()
        {
            // Arrange
            List<AnimalHandlingNotes> handlingNotes;
            IAnimalHandlingManager handlingManager = new AnimalHandlingManager(_handlingAccessor);

            // Act
            handlingNotes = handlingManager.GetAllHandlingNotesByAnimalID(100000);

            // Assert
            Assert.AreEqual(1, handlingNotes.Count);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get animal handling notes details by animal ID bad value 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestGetHandlingNotesByAnimalIDBadValue()
        {
            // Arrange
            List<AnimalHandlingNotes> handlingNotes;
            IAnimalHandlingManager handlingManager = new AnimalHandlingManager(_handlingAccessor);

            // Act
            handlingNotes = handlingManager.GetAllHandlingNotesByAnimalID(0);

            // Assert
            Assert.AreEqual(0, handlingNotes.Count);
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Test Cleanup. You know what this does
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestCleanup]
        public void TestTeardown()
        {
            _handlingAccessor = null;
        }
    }
}
