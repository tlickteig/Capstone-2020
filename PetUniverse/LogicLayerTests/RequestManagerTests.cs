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


        [TestInitialize]
        public void TestSetup()
        {
            _fakeRequestAccessor = new FakeRequestAccessor();
            _requestManager = new RequestManager(_fakeRequestAccessor);
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
            //IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            requests = _requestManager.RetrieveAllRequests();

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
            //IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            requestsChanged = _requestManager.ApproveRequest(1000001, 1000000);

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

        [TestCleanup]
        public void TestTearDown()
        {
            _fakeRequestAccessor = null;
            _requestManager = null;
        }

    }
}
