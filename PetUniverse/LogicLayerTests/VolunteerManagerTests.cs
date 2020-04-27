using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Josh Jackson
    /// DATE: 02/07/2020
    /// Checked By: Ethan H, Gabi L
    /// This is a test class used to test all the methods involving Volunteer Records
    /// </summary>
    /// <remarks>
    /// UPDATED BY: Josh Jackson
    /// UPDATE DATE: 02/14/2020
    /// WHAT WAS CHANGED: Added TestGetVolunteerByName() method
    /// </remarks>
    [TestClass]
    public class VolunteerManagerTests
    {
        private IVolunteerAccessor _volunteerAccessor;
        public VolunteerManagerTests()
        {
            _volunteerAccessor = new FakeVolunteerAccessor();
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H
        /// this test method tests the InsertVolunteer method
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        [TestMethod]
        public void TestVolunteerManagerInsertVolunteer()
        {
            // arrange
            IVolunteerManager volunteerManager = new VolunteerManager(_volunteerAccessor);
            // act
            bool row = volunteerManager.AddVolunteer(new Volunteer()
            {
                VolunteerID = 101,
                FirstName = "Tony",
                LastName = "Stark",
                Email = "ironman@starkent.com",
                PhoneNumber = "13334445567",
                OtherNotes = "Test",
                Active = true
            });
            // assert
            Assert.IsTrue(row);
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H
        /// this test method tests the GetAllSkills method
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        [TestMethod]
        public void TestGetAllSkills()
        {
            // arrange
            List<string> skills;
            IVolunteerManager volunteerManager = new VolunteerManager(_volunteerAccessor);
            // act
            skills = volunteerManager.GetAllSkills();
            // assert
            Assert.AreEqual(2, skills.Count);
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/13/2020
        /// Checked By: Gabi L
        /// this test method tests the GetVolunteerByName method
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        [TestMethod]
        public void TestGetVolunteerByName()
        {
            // arrange 
            List<Volunteer> volunteers;
            IVolunteerManager volunteerManager = new VolunteerManager(_volunteerAccessor);
            // Act
            volunteers = volunteerManager.GetVolunteerByName("Tony", "Stark");
            // assert
            Assert.AreEqual(1, volunteers.Count);
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/13/2020
        /// Checked By: Gabi L
        /// this test method tests the GetVolunteerByFirstName method
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        [TestMethod]
        public void TestGetVolunteerByFirstName()
        {
            // arrange 
            List<Volunteer> volunteers;
            IVolunteerManager volunteerManager = new VolunteerManager(_volunteerAccessor);
            // Act
            volunteers = volunteerManager.GetVolunteerByFirstName("Tony");
            // assert
            Assert.AreEqual(1, volunteers.Count);
        }

        /// <summary>
        /// NAME: Gabi Legrand
        /// DATE: 2/13/2020
        /// CHECKED BY: Timothy Lickteig
        /// 
        /// This test method is used for testing when all active employees are accessed
        /// 
        /// </summary>
        [TestMethod]
        public void TestRetrieveVolunteerListByActive()
        {
            // arrange
            List<Volunteer> selectedVolunteers = new List<Volunteer>();
            const bool active = true;


            // act
            selectedVolunteers = _volunteerAccessor.SelectVolunteersByActive(active);

            // assert
            Assert.AreEqual(2, selectedVolunteers.Count);
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 3/3/2020
        /// CHECKED BY: Timothy Lickteig
        /// 
        /// This test method is used for testing when a volunteer is updated. 
        /// 
        /// </summary>
        [TestMethod]
        public void TestUpdateVolunteer()
        {
            // arrange
            Volunteer oldVolunteer = new Volunteer()
            {
                VolunteerID = 1,
                FirstName = "Tony",
                LastName = "Stark",
                Email = "ironman@gmail.com",
                PhoneNumber = "15554443322",
                OtherNotes = "test",
                Active = true,
                Skills = new List<string>() { "Dogwalker", "Groomer" }
            };
            Volunteer newVolunteer = new Volunteer()
            {
                VolunteerID = 1,
                FirstName = "Tony",
                LastName = "Stark",
                Email = "ironman@gmail.com",
                PhoneNumber = "15554443322",
                OtherNotes = "suh dude",
                Active = true,
                Skills = new List<string>() { "Dogwalker", "Groomer" }
            };
            IVolunteerManager _volunteerManager = new VolunteerManager(_volunteerAccessor);
            //Act
            bool expectedResults = true;
            bool actualResult = _volunteerManager.UpdateVolunteer(oldVolunteer, newVolunteer);
            //Assert
            Assert.AreEqual(actualResult, expectedResults);
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 3/12/2020
        /// CHECKED BY: Timothy Lickteig
        /// 
        /// This test method is used for testing when a volunteer is reactivated. 
        /// 
        /// </summary>
        [TestMethod]
        public void TestActivateVolunteer()
        {
            //Arrange
            Volunteer volunteer = new Volunteer()
            {
                VolunteerID = 3,
                FirstName = "Gordon",
                LastName = "Ramsey",
                Email = "beefwellington@gmail.com",
                PhoneNumber = "15556669988",
                OtherNotes = "test",
                Active = false,
                Skills = new List<string>() { "Dogwalker", "Groomer" }
            };
            IVolunteerManager _volunteerManager = new VolunteerManager(_volunteerAccessor);
            //Act
            bool expectedResults = true;
            bool isChecked = true;
            bool actualResult = _volunteerManager.ChangeVolunteerActiveStatus(isChecked, volunteer.VolunteerID);
            //Assert
            Assert.AreEqual(actualResult, expectedResults);
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 3/12/2020
        /// CHECKED BY: Timothy Lickteig
        /// 
        /// This test method is used for testing when a volunteer is deactivated. 
        /// 
        /// </summary>
        [TestMethod]
        public void TestDeactivateVolunteer()
        {
            //Arrange
            Volunteer volunteer = new Volunteer()
            {
                VolunteerID = 1,
                FirstName = "Tony",
                LastName = "Stark",
                Email = "ironman@gmail.com",
                PhoneNumber = "15554443322",
                OtherNotes = "test",
                Active = true,
                Skills = new List<string>() { "Dogwalker", "Groomer" }
            };
            IVolunteerManager _volunteerManager = new VolunteerManager(_volunteerAccessor);
            //Act
            bool expectedResults = true;
            bool isChecked = false;
            bool actualResult = _volunteerManager.ChangeVolunteerActiveStatus(isChecked, volunteer.VolunteerID);
            //Assert
            Assert.AreEqual(actualResult, expectedResults);
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 4/16/2020
        /// CHECKED BY: 
        /// 
        /// This test method is used for testing sort volunteers by skill
        /// 
        /// </summary>
        [TestMethod]
        public void TestSortVolunteersBySkill()
        {
            // arrange 
            List<Volunteer> volunteers;
            IVolunteerManager volunteerManager = new VolunteerManager(_volunteerAccessor);
            // Act
            volunteers = volunteerManager.GetVolunteersBySkill("Dogwalker");
            // assert
            Assert.AreEqual(3, volunteers.Count);
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 4/26/2020
        /// CHECKED BY: 
        /// 
        /// This test method is used for testing create foster
        /// 
        /// </summary>
        [TestMethod]
        public void TestCreateFoster()
        {
            // arrange
            IVolunteerManager volunteerManager = new VolunteerManager(_volunteerAccessor);
            Volunteer volunteer = new Volunteer { VolunteerID = 1 };
            // act
            bool row = volunteerManager.CreateFoster(volunteer, new Foster()
            {
                AddressLineOne = "111 Poppy St",
                AddressLineTwo = "",
                City = "Los Angeles",
                State = "CA",
                Zip = "44452",
            });
            // assert
            Assert.IsTrue(row);
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 4/26/2020
        /// CHECKED BY: 
        /// 
        /// This test method is used for testing get foster details by volunteer id
        /// 
        /// </summary>
        [TestMethod]
        public void TestGetFosterDetailsByVolunteerID()
        {
            // arrange 
            Foster foster;
            IVolunteerManager volunteerManager = new VolunteerManager(_volunteerAccessor);
            // Act
            foster = volunteerManager.GetFosterDetailsByVolunteerID(3);
            // assert
            Assert.AreEqual(3, foster.VolunteerID);
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 4/26/2020
        /// CHECKED BY:
        /// 
        /// This test method is used for testing when a foster record is updated. 
        /// 
        /// </summary>
        [TestMethod]
        public void TestUpdateFoster()
        {
            // arrange
            Foster oldFoster = new Foster()
            {
                FosterID = 1,
                VolunteerID = 3,
                AddressLineOne = "22 Hell St",
                AddressLineTwo = "#666",
                City = "Cedar Rapids",
                State = "IA",
                Zip = "52403"
            };
            Foster newFoster = new Foster()
            {
                FosterID = 1,
                VolunteerID = 3,
                AddressLineOne = "221 Hell St",
                AddressLineTwo = "#666",
                City = "Cedar Rapids",
                State = "IA",
                Zip = "52403"
            };
            IVolunteerManager _volunteerManager = new VolunteerManager(_volunteerAccessor);
            //Act
            bool expectedResults = true;
            bool actualResult = _volunteerManager.UpdateFoster(oldFoster, newFoster);
            //Assert
            Assert.AreEqual(actualResult, expectedResults);
        }
    }
}
