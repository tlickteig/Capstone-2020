using System;
using System.Collections.Generic;
using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
    /// <summary>
    ///  Creator: Kaleb Bachert
    ///  Created: 2/9/2020
    ///  Approver: Zach Behrensmeyer
    ///  
    ///  Test Class for RequestManager
    /// </summary>

    [TestClass]
    public class RequestManagerTests
    {
        private IRequestAccessor _requestAccessor;

        /// <summary>
        ///  Creator: Kaleb Bachert
        ///  Created: 2/9/2020
        ///  Approver: Zach Behrensmeyer
        ///  Approver: Jordan Lindo
        ///  
        ///  Constructor for instantiating FakeRequestAccessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public RequestManagerTests()
        {
            _requestAccessor = new FakeRequestAccessor();
        }

        /// <summary>
        ///  Creator: Kaleb Bachert
        ///  Created: 2/9/2020
        ///  Approver: Zach Behrensmeyer
        ///  Approver: Jordan Lindo
        ///  
        ///  Test method for retrieving all requests
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllRequests()
        {
            //arrange
            List<RequestVM> requests;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            requests = requestManager.RetrieveAllRequests();

            //assert
            Assert.AreEqual(2, requests.Count);
        }

        /// <summary>
        ///  Creator: Kaleb Bachert
        ///  Created: 2/19/2020
        ///  Approver: Zach Behrensmeyer
        ///  
        ///  Test method for approving a request
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestApproveRequest()
        {
            //arrange
            int requestsChanged;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            requestsChanged = requestManager.ApproveRequest(1000001, 1000000);

            //assert
            Assert.AreEqual(1, requestsChanged);
        }
    }
}
