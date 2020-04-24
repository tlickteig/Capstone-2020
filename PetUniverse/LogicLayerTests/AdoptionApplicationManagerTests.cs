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
    /// NAME: Austin Gee
    /// DATE: 3/19/2020
    /// CHECKED BY: 
    /// 
    /// This class is used to unit test the AdopterApplicationManager
    /// </summary>
    [TestClass]
    public class AdoptionApplicationManagerTests
    {
        private IAdoptionApplicationAccessor _fakeAdoptionApplicationAccessor;

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Michael Thompson
        /// 
        /// constructor for this class
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public AdoptionApplicationManagerTests()
        {
            _fakeAdoptionApplicationAccessor = new FakeApplicationAccessor();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Micheal Thompson,
        /// 
        /// Tests
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionApplicationManagerRetrieveAdoptionApplicationByEmail()
        {
            // arrange
            var adoptionApplications = new List<ApplicationVM>();
            IAdoptionApplicationManager adoptionApplicationManager = new AdoptionApplicationManager(_fakeAdoptionApplicationAccessor);

            // act
            adoptionApplications = adoptionApplicationManager.RetrieveAdoptionApplicationsByEmailAndActive("Fake@fake.com");

            //assert
            Assert.AreEqual(1, adoptionApplications.Count);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Micheal Thompson,
        /// 
        /// Tests
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionApplicationManagerRetrieveAdoptionApplicationByID()
        {
            // arrange
            IAdoptionApplicationManager adoptionApplicationManager = new AdoptionApplicationManager(_fakeAdoptionApplicationAccessor);

            // act
            var adoptionApplication = adoptionApplicationManager.RetrieveAdoptionApplicationByID(000);

            //assert
            Assert.AreEqual(000, adoptionApplication.AdoptionApplicationID);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/22/2020
        /// Approver: Michael Thompson
        /// 
        /// Tests
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionApplicationManagerDeactivateAdoptionApplicationByID()
        {
            // arrange
            IAdoptionApplicationManager adoptionApplicationManager = new AdoptionApplicationManager(_fakeAdoptionApplicationAccessor);

            // act
            bool result = adoptionApplicationManager.DeactivateAdoptionApplication(000);

            //assert
            Assert.AreEqual(result, true);
        }
    }
}
