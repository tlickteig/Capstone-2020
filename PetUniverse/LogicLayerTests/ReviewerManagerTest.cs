using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataTransferObjects;
using DataAccessInterfaces;
using DataAccessFakes;
using System.Collections.Generic;
using LogicLayerInterfaces;
using LogicLayer;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/04
    /// Approver : Mohamed Elamin , 2/21/2020
    ///
    /// Test the reviewer manager
    /// </summary>
    [TestClass]
    public class ReviewerManagerTest
    {
        private IAdoptionAccessor fakeReviewerAccessor;
        private ReviewerManager reviewerManager;

        /// <summary>
        /// initialize the fakeReviewerAccessor and assgined the reviewer mananger object
        /// to the fake data access, So we can test the reviewer manager without effecting the real DB
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            fakeReviewerAccessor = new FakeReviewerAccessor();
            reviewerManager = new ReviewerManager(fakeReviewerAccessor);
        }

        /// <summary>
        /// Test the RetrieveCustomersFilledQuestionnair method
        /// to pass the test must retrieve 1
        /// (The count of the fake rows on the fake DB)
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        [TestMethod]
        public void TestRetrieveCustomersFilledQuestionnair()
        {
            //arrange
            List<AdoptionApplication> adoptionApplications = new List<AdoptionApplication>();

            //Acct
            adoptionApplications = reviewerManager.retrieveCustomersFilledQuestionnair();
            if (adoptionApplications != null)
            {
                Assert.AreEqual(1, adoptionApplications.Count);
            }

        }

        /// <summary>
        /// Test GetCustomerBuyCustomerName method
        /// to pass the test must retrieve "Elamin"
        /// (The value that we assgined to the parameter must match the last name of one
        /// of the Fake customers)
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        [TestMethod]
        public void TestGetCustomerBuyCustomerName()
        {
            //arrange
            Customer customer = null;
            string customerName = "Elamin";

            //acct
            customer = reviewerManager.retrieveCustomerByCustomerName(customerName);
            //assert
            Assert.AreEqual(customerName, customer.lastName);

        }

        /// <summary>
        /// Test  for RetrieveCustomerQuestionnair method
        /// to pass the test must retrieve "10"
        /// (The value that we assgined to the parameter (10000) must match with 10 rows on our fake DB)
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        [TestMethod]
        public void TestRetrieveCustomerQuestionnair()
        {
            //arrange
            List<CustomerQuestionnarVM> customerQuestionnars = new List<CustomerQuestionnarVM>();
            int customerID = 10000;

            //acct
            customerQuestionnars = reviewerManager.retrieveCustomerQuestionnar(customerID);

            //Assert
            Assert.AreEqual(10, customerQuestionnars.Count);

        }

        /// <summary>
        /// Test  for SubmitReviewerDecision
        /// to pass the test must retrieve "true"
        /// (That means the status changed to Interviewer or Deny)
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        [TestMethod]
        public void TestSubmitReviewerDecision()
        {
            // bool (int adoptionApplicationID, string decision);
            int adoptionApplicationID = 10000;
            string decision = "approved";
            bool expect = true;
            bool result = reviewerManager.SubmitReviewerDecision(adoptionApplicationID, decision);
            Assert.AreEqual(expect, result);
        }
    }
}
