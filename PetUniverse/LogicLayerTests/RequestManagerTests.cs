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

        //Test Variables
        private IRequestAccessor _fakeRequestAccessor;
        private RequestManager _requestManager;

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/9
        ///  APPROVER: Jordan Lindo
        ///  
        ///  Constructor for instantiating FakeRequestAccessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public RequestManagerTests()
        {
            _requestAccessor = new FakeRequestAccessor();
        }

        [TestInitialize]
        public void TestSetup()
        {
            _fakeRequestAccessor = new FakeRequestAccessor();
            _requestManager = new RequestManager(_fakeRequestAccessor);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/9
        ///  APPROVER: Jordan Lindo
        ///  
        ///  Test method for retrieving all open requests
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveRequestsByStatusOpen()
        {
            //arrange
            List<Request> requests;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            requests = requestManager.RetrieveRequestsByStatus(true);

            //assert
            Assert.AreEqual(3, requests.Count);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/9
        ///  APPROVER: Jordan Lindo
        ///  
        ///  Test method for retrieving all closed requests
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveRequestsByStatusClosed()
        {
            //arrange
            List<Request> requests;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            requests = requestManager.RetrieveRequestsByStatus(false);

            //assert
            Assert.AreEqual(0, requests.Count);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/19
        ///  APPROVER: NA
        ///  
        ///  Test method for approving a request
        /// </summary>
        /// <remarks>
        /// UPDATER: Kaleb Bachert
        /// UPDATED: 2020/3/7
        /// UPDATE: Added parameter for RequestType
        /// 
        /// </remarks>
        [TestMethod]
        public void TestApproveRequest()
        {
            //arrange
            int requestsChanged;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            requestsChanged = requestManager.ApproveRequest(1000001, 1000000, "Time Off");

            //assert
            Assert.AreEqual(1, requestsChanged);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/14
        /// Approver:Derek Taylor
        /// 
        /// Test Method for validating good input results when retrieving
        /// new Requests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveNewRequestsByDepartmentID()
        {
            // arrange
            List<DepartmentRequest> _selectedRequest = new List<DepartmentRequest>();
            List<DepartmentRequest> _selectedRequest2 = new List<DepartmentRequest>();
            List<string> requestID = new List<string>() { "CustomerService" };
            List<string> requestID2 = new List<string>() { "Management" };

            // act
            _selectedRequest = _requestManager.RetrieveNewRequestsByDepartmentID(requestID);
            _selectedRequest2 = _requestManager.RetrieveNewRequestsByDepartmentID(requestID2);

            // assert
            Assert.AreEqual(1, _selectedRequest2.Count);
            Assert.AreEqual(2, _selectedRequest.Count);

        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/14
        /// Approver:Derek Taylor
        /// 
        /// Test Method for validating NULL input results when retrieving
        /// new Requests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestExceptionRetrieveNewRequestsByDepartmentID()
        {
            // arrange
            List<DepartmentRequest> _selectedRequest = new List<DepartmentRequest>();
            List<string> deptID = null;

            // act
            _selectedRequest = _requestManager.RetrieveNewRequestsByDepartmentID(deptID);
        }


        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/14
        /// Approver:Derek Taylor
        /// 
        /// Test Method for validating good input results when retrieving
        /// Completed Requests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveCompleteRequestsByDepartmentID()
        {
            // arrange
            List<DepartmentRequest> _selectedRequest = new List<DepartmentRequest>();
            List<DepartmentRequest> _selectedRequest2 = new List<DepartmentRequest>();
            List<string> requestID = new List<string>() { "CustomerService" };
            List<string> requestID2 = new List<string>() { "Management" };

            // act
            _selectedRequest = _requestManager.RetrieveCompleteRequestsByDepartmentID(requestID);
            _selectedRequest2 = _requestManager.RetrieveCompleteRequestsByDepartmentID(requestID2);

            // assert
            Assert.AreEqual(2, _selectedRequest2.Count);
            Assert.AreEqual(1, _selectedRequest.Count);

        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/14
        /// Approver:Derek Taylor
        /// 
        /// Test Method for validating NULL input results when retrieving
        /// Completed Requests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestExceptionRetrieveCompleteRequestsByDepartmentID()
        {
            // arrange
            List<DepartmentRequest> _selectedRequest = new List<DepartmentRequest>();
            List<string> deptID = null;

            // act
            _selectedRequest = _requestManager.RetrieveCompleteRequestsByDepartmentID(deptID);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/14
        /// Approver:Derek Taylor
        /// 
        /// Test Method for validating good input results when retrieving
        /// Active Requests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveActiveRequestsByDepartmentID()
        {
            // arrange
            List<DepartmentRequest> _selectedRequest = new List<DepartmentRequest>();
            List<DepartmentRequest> _selectedRequest2 = new List<DepartmentRequest>();
            List<string> requestID = new List<string>() { "CustomerService" };
            List<string> requestID2 = new List<string>() { "Management" };

            // act
            _selectedRequest = _requestManager.RetrieveActiveRequestsByDepartmentID(requestID);
            _selectedRequest2 = _requestManager.RetrieveActiveRequestsByDepartmentID(requestID2);

            // assert
            Assert.AreEqual(0, _selectedRequest2.Count);
            Assert.AreEqual(2, _selectedRequest.Count);

        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/14
        /// Approver:Derek Taylor
        /// 
        /// Test Method for validating NULL input results when retrieving
        /// Active Requests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestExceptionRetrieveActiveRequestsByDepartmentID()
        {
            // arrange
            List<DepartmentRequest> _selectedRequest = new List<DepartmentRequest>();
            List<string> deptID = null;

            // act
            _selectedRequest = _requestManager.RetrieveActiveRequestsByDepartmentID(deptID);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/22
        /// Approver: Derek Taylor
        /// 
        /// Test Method for validating good input results when retrieving
        /// DepartmentIDs.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllDepartmentIDsByUserID()
        {
            // arrange
            int userID = 100001;
            List<string> deptIDs = new List<string>();

            // act
            deptIDs = _requestManager.RetrieveAllDepartmentIDsByUserID(userID);

            // assert
            Assert.AreEqual(3, deptIDs.Count);

        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/19
        ///  APPROVER: NA
        ///  
        ///  Test method for creating a request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestCreateTimeOffRequest()
        {
            //arrange
            bool singleRequestAdded;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            singleRequestAdded = requestManager.AddTimeOffRequest(new TimeOffRequest()
            {
                TimeOffRequestID = 1000002,
                EffectiveStart = DateTime.Now.AddDays(1),
                EffectiveEnd = DateTime.Now.AddDays(2),
                RequestID = 1000002
            }, 1000000);

            //assert
            Assert.AreEqual(true, singleRequestAdded);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/19
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Test method for retrieving a TimeOffRequestByRequestID
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveTimeOffRequestByRequestID()
        {
            // arrange
            TimeOffRequestVM request = null;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            // act
            request = requestManager.RetrieveTimeOffRequestByRequestID(1000000);

            // assert
            Assert.IsNotNull(request);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/19
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Test method for creating an availability request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestCreateAvailabilityRequest()
        {
            //arrange
            bool singleRequestAdded;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            singleRequestAdded = requestManager.AddAvailabilityRequest(new AvailabilityRequestVM()
            {
                RequestID = 1000003
            }, 1000000);

            //assert
            Assert.AreEqual(true, singleRequestAdded);
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _fakeRequestAccessor = null;
            _requestManager = null;
        }

    }
}
