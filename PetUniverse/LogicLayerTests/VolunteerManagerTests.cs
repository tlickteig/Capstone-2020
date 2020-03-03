using System;
using DataAccessInterfaces;
using DataAccessFakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataTransferObjects;
using LogicLayerInterfaces;
using LogicLayer;
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
        public void TestVolunteerManagerInsertVolunteer() {
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
    }
}
