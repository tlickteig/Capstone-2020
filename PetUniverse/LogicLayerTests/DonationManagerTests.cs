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
    ///  Creator: Ryan Morganti
    ///  Created: 2020/04/05
    ///  Approver: Matt Deaton
    ///  
    ///  Test Class for DonationManager
    /// </summary>
    [TestClass]
    public class DonationManagerTests
    {
        private IDonationAccessor _donationAccessor;
        private IDonationManager _donationManager;

        public DonationManagerTests()
        {
            _donationAccessor = new FakeDonationAccessor();
        }

        [TestInitialize]
        public void TestSetup()
        {
            _donationManager = new DonationManager(_donationAccessor);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/05
        /// Approver: Matt Deaton
        /// 
        /// Test Method for validating good output when asking for 
        /// a list of the past year's donation history.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllDonationsFromPastYear()
        {
            // Arrange
            List<Donation> donations = new List<Donation>();

            // Act
            donations = _donationManager.RetrieveAllDonationsFromPastYear();

            // Assert
            Assert.AreEqual(donations.Count, 3);
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _donationManager = null;
            _donationAccessor = null;
        }
    }
}
