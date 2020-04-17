using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{

    /// <summary>
    /// Creator: Steven Cardona
    /// Created: 02/07/2020
    /// Approver: Zach Behrensmeyer
    /// 
    /// The tests for the user manager
    /// </summary>
    [TestClass]
    public class UserManagerTests
    {
        private PetUniverseUser _user;
        private FakeUserAccessor _fakeUserAccessor;
        private UserManager _userManager;

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/07/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Setup for tests to run
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeUserAccessor = new FakeUserAccessor();
            _userManager = new UserManager(_fakeUserAccessor);
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/07/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Test for Creating a user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// </remarks>
        [TestMethod]
        public void TestCreateNewUser()
        {
            // arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "jdoe@PetUniverse.com",
                City = "Cedar Rapids",
                PhoneNumber = "2255448796",
                State = "IA",
                ZipCode = "52404"
            };

            bool created = false;
            bool expectedResult = true;

            // act
            created = _userManager.CreateNewUser(petUniverseUser);

            // assert
            Assert.AreEqual(expectedResult, created);
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/07/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Test method to retrieve all Pet Universe Users
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllPetUniverseUsers()
        {
            // arrange
            List<PetUniverseUser> users = null;
            int expectedCount = 2;

            // act
            users = _userManager.RetrieveAllActivePetUniverseUsers();

            // assert
            Assert.AreEqual(expectedCount, users.Count);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method hashes the given password for tests
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// <param name="source"></param>
        /// <returns>Hashed Password</returns>
        private string hashPassword(string source)
        {
            string result = null;

            byte[] data;

            using (SHA256 sha256hash = SHA256.Create())
            {
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            var s = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            result = s.ToString().ToUpper();

            return result;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is a passing test for the UserAuthentication() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>        
        [TestMethod]
        public void TestUserManagerAuthentication()
        {
            //Arrange            
            string email = "j.doe@RandoGuy.com";
            string password = "passwordtest";
            //Act
            _user = _userManager.AuthenticateUser(email, password);
            //Assert    
            Assert.AreEqual(email, _user.Email);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is a passing test for the TestCheckIfUserExists() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks> 
        [TestMethod]
        public void TestCheckIfUserExists()
        {
            //Arrange
            string Email = "j.doe@RandoGuy.com";
            bool exists = false;
            //Act
            exists = _userManager.CheckIfUserExists(Email);
            //Assert
            Assert.IsTrue(exists);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is a passing test for the TestCheckIfUserExistsException() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestCheckIfUserExistsException()
        {
            //Arrange            
            string email = "zbehrens@RandoGuy.com";
            bool exists = false;
            //Act
            exists = _userManager.CheckIfUserExists(email);
            //Assert not needed
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is a passing test for the TestLockoutUser() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        [TestMethod]
        public void TestLockoutUser()
        {
            //Arrange
            string Email = "j.doe@RandoGuy.com";
            bool isLocked = false;
            //Act
            isLocked = _userManager.LockoutUser(Email, DateTime.Now.AddMinutes(15), DateTime.Now);
            //Assert
            Assert.IsTrue(isLocked);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is a passing test for the TestLockoutUserException() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestLockoutUserException()
        {
            //Arrange            
            string email = "zbehrens@RandoGuy.com";
            bool isLocked = false;
            //Act
            isLocked = _userManager.LockoutUser(email, DateTime.Now, DateTime.Now.AddMinutes(15));
            //Assert not needed
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is a passing test for the TestLockoutUserBadCurrentDateException() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestLockoutUserBadCurrentDateException()
        {
            //Arrange            
            string email = "zbehrens@RandoGuy.com";
            bool isLocked = false;
            //Act
            isLocked = _userManager.LockoutUser(email, DateTime.Now.AddMinutes(15), DateTime.Now);
            //Assert not needed
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is a passing test for the TestUnlockUserByTime() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        [TestMethod]
        public void TestUnlockUserByTime()
        {
            //Arrange
            string Email = "j.doe@RandoGuy.com";
            bool isLocked = false;
            //Act
            isLocked = _userManager.CheckIfUserExists(Email);
            //Assert
            Assert.IsTrue(isLocked);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is a passing test for the TestFetchUnlockDate() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        [TestMethod]
        public void TestFetchUnlockDate()
        {
            //Arrange
            string Email = "j.doe@RandoGuy.com";
            DateTime date = DateTime.Now;

            //Act
            DateTime unlockdate = _userManager.fetchUnlockDate(Email);
            //Assert
            Assert.AreEqual(date, unlockdate);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is a passing test for the TestFetchUnlockDateException() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestFetchUnlockDateException()
        {
            //Arrange            
            string Email = "zbehrens@RandoGuy.com";
            DateTime date = DateTime.Now;
            //Act
            DateTime unlockDate = _userManager.fetchUnlockDate(Email);
            //Assert not needed
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is a passing test for the TestUnlockUserByTimeException() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUnlockUserByTimeException()
        {
            //Arrange            
            string email = "zbehrens@RandoGuy.com";
            bool isLocked = false;
            //Act
            isLocked = _userManager.UnlockUserByTime(email);
            //Assert not needed
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is a failing test for the UserAuthentication() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUserManagerAuthenticationPasswordException()
        {
            //return this value to determine if its a real user
            bool isValidUser = false;
            //Arrange            
            string email = "j.doe@RandoGuy.com";
            //Value you want PasswordHash() to return
            //Hashing Password
            string goodPasswordHash = hashPassword("newuser");
            //Act
            _user = _userManager.AuthenticateUser(email, goodPasswordHash);
            //Assert not needed
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is a failing test for the UserAuthentication() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUserManagerAuthenticationUserNameException()
        {
            //Arrange            
            string email = "j.blue@RandoGuy.com";
            //Value you want PasswordHash() to return
            //Hashing Password
            string goodPasswordHash = hashPassword("passwordtest");
            //Act
            _user = _userManager.AuthenticateUser(email, goodPasswordHash);
            //Assert not needed   
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 2/15/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Tests for an application exception
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// </remarks>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestCreateNewUserException()
        {
            // arrange
            PetUniverseUser petUniverseUser = new PetUniverseUser()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "",
                City = "Cedar Rapids",
                PhoneNumber = "2255448796",
                State = "IA",
                ZipCode = "52404"
            };

            bool created = false;

            // act
            created = _userManager.CreateNewUser(petUniverseUser);

        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 3/17/2020
        /// Approver: Kaleb Bachert
        /// 
        /// This Method is a passing test for the HasReadPoliciesAndStandards() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>        
        [TestMethod]
        public void TestUserManagerPoliciesHasRead()
        {
            //Arrange            
            int userID = 100000;
            bool Passed;
            //Act
            Passed = _userManager.HasReadPoliciesAndStandards(userID);
            //Assert    
            Assert.IsTrue(Passed);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/1/2020
        /// Approver: Steven Cardona
        /// 
        /// Test to get user by ID
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// </remarks>
        /// 
        /// </summary>
        [TestMethod]
        public void TestGetUserByID()
        {
            //Arrange                        
            int userID = 100000;
            //Act
            _user = _userManager.getUserByUserID(userID);
            //Assert 
            Assert.IsNotNull(_user);
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Test to verify updateUser is working properly
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TestUpdateUser()
        {
            // Arrange
            PetUniverseUser originalUser = new PetUniverseUser()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "jdoe@PetUniverse.com",
                City = "Cedar Rapids",
                PhoneNumber = "2255448796",
                State = "IA",
                ZipCode = "52404",
                Active = true
            };

            // Arrange
            PetUniverseUser updatedUser = new PetUniverseUser()
            {
                FirstName = "Jon",
                LastName = "Donut",
                Email = "jdonut@PetUniverse.com",
                City = "Grand Rapids",
                PhoneNumber = "7775448796",
                State = "MI",
                ZipCode = "52403",
                Active = true
            };

            // Call the method
            bool success = _userManager.UpdateUser(originalUser, updatedUser);

            // Assert
            Assert.AreEqual(true, success);
        }


        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/07/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Method to reset all variable for next test run.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA 
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _fakeUserAccessor = null;
            _userManager = null;
            _user = null;
        }
    }
}
