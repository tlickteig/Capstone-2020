using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
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
        /// Approver: NA
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
            _fakeAdoptionApplicationAccessor = new FakeAdoptionApplicationAccessor();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: NA
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
            adoptionApplications = _fakeAdoptionApplicationAccessor.SelectAdoptionApplicationsByEmail("Fakest@fake.com");

            //assert
            Assert.AreEqual(1, adoptionApplications.Count);
        }
    }
}
