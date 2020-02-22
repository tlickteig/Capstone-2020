using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LogicLayer;
using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME : Derek Taylor
    /// DATE: 2/14/2020
    /// CHECKED BY: Ryan Morganti
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
        /// NAME : Derek Taylor
        /// DATE: 2/14/2020
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This is the fake constructor. Initializes the test class.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeApplicantAccessor = new FakeApplicantAccessor();
            _applicantManager = new ApplicantManager(_fakeApplicantAccessor);
        }
        /// <summary>
        /// NAME: Derek Taylor
        /// DATE: 2/14/2020
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This Method is test for the SelectAllApplicants() method
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
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
        /// CREATED BY: Derek Taylor
        /// DATE: 2/14/2020
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This is the test cleanup method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
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
