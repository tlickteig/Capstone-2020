using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using LogicLayerInterfaces;
using DataAccessInterfaces;
using DataAccessFakes;
using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/6/2020
    /// CHECKED BY: Mohamed Elamin, 02/07/2020
    /// 
    /// This class is used to unit test the AdopterCustomerManager
    /// </summary>

    [TestClass]
    public class AdoptionCustomerManagerTests
    {
        private IAdoptionCustomerAccessor _adoptionCustomerAccessor;

        
        public AdoptionCustomerManagerTests()
        {
            _adoptionCustomerAccessor = new FakeAdoptionCustomerAccessor();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Mohamed Elamin, 02/07/2020
        /// 
        /// This test method tests the RetriveAdoptionCustomersByActive method that is a part of the AdoptionCustomerManager class.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionCustomerRetrievesActiveAdoptionCustomers()
        {
            // arrange
            List<AdoptionCustomerVM> adoptionCustomerVMs;
            IAdoptionCustomerManager adoptionCustomerManager = new AdoptionCustomerManager(_adoptionCustomerAccessor);

            // act
            adoptionCustomerVMs = adoptionCustomerManager.RetrieveAdoptionCustomersByActive(true);

            // assert
            Assert.AreEqual(1, adoptionCustomerVMs.Count);
        }
    }
}
