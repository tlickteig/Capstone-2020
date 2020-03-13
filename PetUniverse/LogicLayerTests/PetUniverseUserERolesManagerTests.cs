using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessInterfaces;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayerInterfaces;
using LogicLayer;

namespace LogicLayerTests
{
    /// <summary>
    /// Summary description for PetUniverseUserERolesManagerTests
    /// </summary>
    [TestClass]
    public class PetUniverseUserERolesManagerTests
    {
        private IPetUniverseUserERolesAccessor _pUUserERoleAccessor;
        public PetUniverseUserERolesManagerTests()
        {
            _pUUserERoleAccessor = new FakePetUniverseUserERolesAccessor();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/02/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Retrieval success from "FakePetUniverseUserERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestPUUserERolesRetrieveSuccess()
        {
            int sameValues = 0;
            //Arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser() { PUUserID = 100000 };
            IPetUniverseUserERolesManager _userERoleManager = new PetUniverseUserERolesManager(_pUUserERoleAccessor);
            //Act
            List<string> actualResult = _userERoleManager.RetrievePetUniverseUserERolesByPetUniverseUser(petUniverseUser.PUUserID);
            List<string> expectedResult = new List<string>() { "Manager" };
            //Assert
            foreach (var actual in actualResult)
            {
                foreach (var expected in expectedResult)
                {
                    if (expected == actual)
                    {
                        sameValues++;
                    }
                }
            }
            Assert.AreEqual(sameValues, 1);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/02/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Retrieval multiple Eroles from "FakePetUniverseUserERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestPUUserERolesRetrieveMutipleERoles()
        {
            int sameValues = 0;
            //Arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser() { PUUserID = 100001 };
            IPetUniverseUserERolesManager _userERoleManager = new PetUniverseUserERolesManager(_pUUserERoleAccessor);
            //Act
            List<string> actualResult = _userERoleManager.RetrievePetUniverseUserERolesByPetUniverseUser(petUniverseUser.PUUserID);
            List<string> expectedResult = new List<string>() { "Cashier", "Event Organizer" };
            foreach (var actual in actualResult)
            {
                foreach (var expected in expectedResult)
                {
                    if (expected == actual)
                    {
                        sameValues++;
                    }
                }
            }
            //Assert
            Assert.AreEqual(sameValues, 2);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/02/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Retrieval failure due to non-existant pk from "FakePetUniverseUserERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestPUUserERolesRetrieveNonExistantUserID()
        {
            //Arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser() { PUUserID = 100003 };
            IPetUniverseUserERolesManager _userERoleManager = new PetUniverseUserERolesManager(_pUUserERoleAccessor);
            //Act
            List<string> actualResult = _userERoleManager.RetrievePetUniverseUserERolesByPetUniverseUser(petUniverseUser.PUUserID);

        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/02/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Delete success from "FakePetUniverseUserERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestPUUserERolesDeleteSuccess()
        {
            //Arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser() { PUUserID = 100000, ERoleID = "Manager" };
            IPetUniverseUserERolesManager _userERoleManager = new PetUniverseUserERolesManager(_pUUserERoleAccessor);
            //Act
            bool actualResult = _userERoleManager.DeletePetUniverseUserERole(petUniverseUser.PUUserID, petUniverseUser.ERoleID);
            bool expectedResult = true;
            //Assert
            Assert.AreEqual(actualResult, expectedResult);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/02/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Delete failure due to nonexistant userID from "FakePetUniverseUserERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestPUUserERolesDeleteNonExistantUserID()
        {
            //Arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser() { PUUserID = 100003, ERoleID = "Manager" };
            IPetUniverseUserERolesManager _userERoleManager = new PetUniverseUserERolesManager(_pUUserERoleAccessor);
            //Act
            bool actualResult = _userERoleManager.DeletePetUniverseUserERole(petUniverseUser.PUUserID, petUniverseUser.ERoleID);

        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/02/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Delete failure due to nonexistant ERole from "FakePetUniverseUserERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestPUUserERolesDeleteNonExistantERole()
        {
            //Arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser() { PUUserID = 100000, ERoleID = "NotManager" };
            IPetUniverseUserERolesManager _userERoleManager = new PetUniverseUserERolesManager(_pUUserERoleAccessor);
            //Act
            bool actualResult = _userERoleManager.DeletePetUniverseUserERole(petUniverseUser.PUUserID, petUniverseUser.ERoleID);

        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/02/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Delete failure due to nonexistant ERole and UserID from "FakePetUniverseUserERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestPUUserERolesDeleteNonExistantERoleAndUserID()
        {
            //Arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser() { PUUserID = 100003, ERoleID = "NotManager" };
            IPetUniverseUserERolesManager _userERoleManager = new PetUniverseUserERolesManager(_pUUserERoleAccessor);
            //Act
            bool actualResult = _userERoleManager.DeletePetUniverseUserERole(petUniverseUser.PUUserID, petUniverseUser.ERoleID);

        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/02/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Add success from "FakePetUniverseUserERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestPUUserERolesAddSuccess()
        {
            //Arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser() { PUUserID = 100000, ERoleID = "Cashier" };
            IPetUniverseUserERolesManager _userERoleManager = new PetUniverseUserERolesManager(_pUUserERoleAccessor);
            //Act
            bool actualResult = _userERoleManager.AddPetUniverseUserERole(petUniverseUser.PUUserID, petUniverseUser.ERoleID);
            bool expectedResult = true;
            //Assert
            Assert.AreEqual(actualResult, expectedResult);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Add fail due to already existant userErole from "FakePetUniverseUserERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestPUUserERolesAddAlreadyExistantUserErole()
        {
            //Arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser() { PUUserID = 100000, ERoleID = "Manager" };
            IPetUniverseUserERolesManager _userERoleManager = new PetUniverseUserERolesManager(_pUUserERoleAccessor);
            //Act
            bool actualResult = _userERoleManager.AddPetUniverseUserERole(petUniverseUser.PUUserID, petUniverseUser.ERoleID);

        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/02/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Add failure due to nonexistant userID from "FakePetUniverseUserERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestPUUserERolesAddNonExistantUserID()
        {
            //Arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser() { PUUserID = 100003, ERoleID = "Manager" };
            IPetUniverseUserERolesManager _userERoleManager = new PetUniverseUserERolesManager(_pUUserERoleAccessor);
            //Act
            bool actualResult = _userERoleManager.AddPetUniverseUserERole(petUniverseUser.PUUserID, petUniverseUser.ERoleID);

        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/02/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Add failure due to nonexistant ERole from "FakePetUniverseUserERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestPUUserERolesAddNonExistantERole()
        {
            //Arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser() { PUUserID = 100000, ERoleID = "" };
            IPetUniverseUserERolesManager _userERoleManager = new PetUniverseUserERolesManager(_pUUserERoleAccessor);
            //Act
            bool actualResult = _userERoleManager.AddPetUniverseUserERole(petUniverseUser.PUUserID, petUniverseUser.ERoleID);

        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/02/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Add failure due to nonexistant ERole and UserID from "FakePetUniverseUserERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestPUUserERolesAddNonExistantERoleAndUserID()
        {
            //Arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser() { PUUserID = 100003, ERoleID = "NotManager" };
            IPetUniverseUserERolesManager _userERoleManager = new PetUniverseUserERolesManager(_pUUserERoleAccessor);
            //Act
            bool actualResult = _userERoleManager.AddPetUniverseUserERole(petUniverseUser.PUUserID, petUniverseUser.ERoleID);

        }
    }
}
