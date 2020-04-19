using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator : Derek Taylor
    /// Created: 2/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// This class tests the ApplicantManager Class
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// CHANGE: NA
    /// 
    /// </remarks>
    [TestClass]
    public class ApplicantManagerTests
    {
        private IApplicantAccessor _fakeApplicantAccessor;
        private ApplicantManager _applicantManager;

        /// <summary>
        /// Creator : Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This is the fake constructor. Initializes the test class.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeApplicantAccessor = new FakeApplicantAccessor();
            _applicantManager = new ApplicantManager(_fakeApplicantAccessor);
        }

        /// <summary>
        /// Creator : Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This Method is test for the SelectAllApplicants() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>  
        [TestMethod]
        public void TestSelectAllApplicants()
        {
            // Arrange
            List<Applicant> selectedApplicants;
            // Act
            selectedApplicants = _applicantManager.RetrieveApplicants();
            // Assert
            Assert.AreEqual(3, selectedApplicants.Count);
        }

        /// <summary>
        /// Creator : Ryan Morganti
        /// Created: 2020/03/19
        /// Approver: Derek Taylor
        /// 
        /// TestMethod for SelectAllJobPositions() 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>  
        [TestMethod]
        public void TestSelectAllJobPositions()
        {
            // Arrange
            List<JobListing> jobs;

            // Act
            jobs = _applicantManager.RetrieveAllPositions();

            // Assert
            Assert.AreEqual(3, jobs.Count);
        }

        /// <summary>
        /// Creator : Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This is the test cleanup method
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _fakeApplicantAccessor = null;
            _applicantManager = null;
        }
    }
}
