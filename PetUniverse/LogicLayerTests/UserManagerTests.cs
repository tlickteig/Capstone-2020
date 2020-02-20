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
    /// CREATOR: Steven Cardona
    /// DATE: 02/07/2020
    /// APPROVER: Zach Behrensmeyer
    /// </summary>
    [TestClass]
    public class UserManagerTests
    {
        private PetUniverseUser _user;
        private FakeUserAccessor _fakeUserAccessor;
        private UserManager _userManager;

        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/07/2020
        /// APPROVER: Zach Behrensmeyer
        /// Setup for tests to run
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        ///     UPDATE: N/A
        /// APPROVER: N/A
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeUserAccessor = new FakeUserAccessor();
            _userManager = new UserManager(_fakeUserAccessor);
        }

        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/07/2020
        /// APPROVER: Zach Behrensmeyer
        /// Test for Creating a user
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        ///     UPDATE: N/A
        /// APPROVER: N/A
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
        /// CREATOR: Steven Cardona
        /// DATE: 02/07/2020
        /// APPROVER: Zach Behrensmeyer
        /// Test method to retrieve all Pet Universe Users
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        ///     UPDATE: N/A
        /// APPROVER: N/A
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
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/3/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This Method hashes the given password for tests
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
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
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/3/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This Method is a passing test for the UserAuthentication() method
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
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
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/5/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This Method is a failing test for the UserAuthentication() method
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
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
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/5/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This Method is a failing test for the UserAuthentication() method
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
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
        /// CREATOR: Steven Cardona
        /// DATE: 02/07/2020
        /// APPROVER: Zach Behrensmeyer
        /// Method to reset all variable for next test run.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        ///     UPDATE: N/A
        /// APPROVER: N/A
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
