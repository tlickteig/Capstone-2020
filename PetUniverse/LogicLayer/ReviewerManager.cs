using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;
using DataAccessLayer;
using LogicLayerInterfaces;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 4/2/2020
    /// Approver: Mohamed Elamin, 2/21/2020
    /// 
    /// Manager class for Reviewer precoesses
    /// </summary>
    public class ReviewerManager : IAdoptionManager
    {
        private IAdoptionAccessor adoptionAccessor;
        private AdoptionApplication adoptionApplication = new AdoptionApplication();
        private Customer customer;

        /// <summary>
        /// default constructor intial adoptionAccessor to
        /// reviewer manager accessor and customer object
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        public ReviewerManager()
        {
            adoptionAccessor = new ReviewerAccessor();
            customer = null;
        }


        /// <summary>
        /// construct assgined a fake data access to addoption application object
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        public ReviewerManager(IAdoptionAccessor fakeReviewerAccessor)
        {
            adoptionAccessor = fakeReviewerAccessor;
        }

        /// <summary>
        /// retrieve the data of the Questionnair
        /// </summary>
        /// <remarks>
        /// created: Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        public List<AdoptionApplication> retrieveCustomersFilledQuestionnair()
        {

            List<AdoptionApplication> adoptionApplications = new List<AdoptionApplication>();
            List<AdoptionApplication> customersFilledQuestionnair = new List<AdoptionApplication>();
            List<CustomerQuestionnarVM> customerQuestionnarVMs = new List<CustomerQuestionnarVM>();
            try
            {
                adoptionApplications = adoptionAccessor.getAllAdoptionApplication();
                customer = new Customer();
                foreach (AdoptionApplication adoptionApplication in adoptionApplications)
                {
                    customer = retrieveCustomerByCustomerName(adoptionApplication.CustomerName);
                    customerQuestionnarVMs = retrieveCustomerQuestionnar(customer.CustomerID);
                    if (null != customerQuestionnarVMs && customerQuestionnarVMs.Count >= 1)
                    {

                        customersFilledQuestionnair.Add(adoptionApplication);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            


            return customersFilledQuestionnair;
        }

        /// <summary>
        /// Retrieve A customer's Questionnar by a customerID
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        public List<CustomerQuestionnarVM> retrieveCustomerQuestionnar(int customerID)
        {
            List<CustomerQuestionnar> customerQuestionnars = new List<CustomerQuestionnar>();
            customerQuestionnars = adoptionAccessor.getCustomerQuestionnair(customerID);
            List<CustomerQuestionnarVM> customerQuestionnarVMs = new List<CustomerQuestionnarVM>();
            foreach (CustomerQuestionnar customerQ in customerQuestionnars)
            {
                CustomerQuestionnarVM customerQuestionnarVM = new CustomerQuestionnarVM();
                customerQuestionnarVM.AdoptionApplicationID = customerQ.AdoptionApplication;
                customerQuestionnarVM.CustomerLastName =
                    adoptionAccessor.getCustomerLastName(customerQ.CustomerID);
                customerQuestionnarVM.QuestionDescription =
                    adoptionAccessor.getQestionDescription(customerQ.QuestionID);
                customerQuestionnarVM.CustomerAnswer = customerQ.Answer;
                customerQuestionnarVMs.Add(customerQuestionnarVM);

            }
            return customerQuestionnarVMs;
        }

        /// <summary>
        ///retrieve a customer record by his last name
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        public Customer retrieveCustomerByCustomerName(string customerLastName)
        {
            customer = adoptionAccessor.getCustomerByCustomerName(customerLastName);

            return customer;
        }

        /// <summary>
        ///Retrieve A customer's AdoptionApplication by a customerID
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        public AdoptionApplication retrieveCustomerAdoptionApplicaionByCustomerID(int customerID)
        {
            adoptionApplication = adoptionAccessor.getAdoptionApplicationByCustomerID(customerID);
            return adoptionApplication;
        }

        /// <summary>
        /// update the status of the adoption application according the reviewer decision
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        public bool SubmitReviewerDecision(int adoptionApplicationID, string decision)
        {
            Boolean result = false;

            if (adoptionAccessor.changeAdoptionApplicationStatus(adoptionApplicationID, decision) == 1)
            {
                result = true;
            }

            return result;
        }
    }
}
