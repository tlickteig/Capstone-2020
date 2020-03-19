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
        private AdoptionCustomer customer;

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
        /// <remark>
        /// Updated by Awaab Elamin
        /// Date: 3/15/2020
        /// According to DB update, change customer id to be customer Email
        /// </remark>
        public List<AdoptionApplication> retrieveCustomersFilledQuestionnair()
        {
            List<AdoptionApplication> adoptionApplications = new List<AdoptionApplication>();
            List<AdoptionApplication> customersFilledQuestionnair = new List<AdoptionApplication>();
            List<CustomerQuestionnar> customerQuestionnar = new List<CustomerQuestionnar>();
            adoptionApplications = adoptionAccessor.getAllAdoptionApplication();
            
            foreach (AdoptionApplication adoptionApplication in adoptionApplications)
            {
               
                customerQuestionnar = adoptionAccessor.getCustomerQuestionnair(adoptionApplication.CustomerEmail);
                if (null != customerQuestionnar && customerQuestionnar.Count >= 1)
                {

                    customersFilledQuestionnair.Add(adoptionApplication);
                }
            }


            return customersFilledQuestionnair;
        }

        /// <summary>
        /// Retrieve A customer's Questionnar by a customerID
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        /// <remark>
        /// Updated by: Awaab Elamin
        /// Date: 3/15/2020
        /// After DB updated in Customer Table, We don't need to below method
        /// </remark>
        public List<CustomerQuestionnar> retrieveCustomerQuestionnar(string customerEmail)
        {
           List<CustomerQuestionnar> customerQuestionnars = new List<CustomerQuestionnar>();
            if (customerEmail !=null && customerEmail != "")
            {
                customerQuestionnars = adoptionAccessor.getCustomerQuestionnair(customerEmail);
            }
            else
            {
                //customerQuestionnars = adoptionAccessor.getAllQuestions();
            }
           
          // List<CustomerQuestionnar> customerQuestionnars = new List<CustomerQuestionnar>();
        //    foreach (CustomerQuestionnar customerQ in customerQuestionnars)
        //    {
        //        CustomerQuestionnarVM customerQuestionnarVM = new CustomerQuestionnarVM();
        //        customerQuestionnarVM.AdoptionApplicationID = customerQ.AdoptionApplication;
        //        customerQuestionnarVM.CustomerLastName =
        //            adoptionAccessor.getCustomerLastName(customerQ.CustomerID);
        //        customerQuestionnarVM.QuestionDescription =
        //            adoptionAccessor.getQestionDescription(customerQ.QuestionID);
        //        customerQuestionnarVM.CustomerAnswer = customerQ.Answer;
        //        customerQuestionnarVMs.Add(customerQuestionnarVM);

        //    }
           return customerQuestionnars;
        }

        /// <summary>
        ///retrieve a customer record by his last name
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        public AdoptionCustomer retrieveCustomerByCustomerName(string customerLastName)
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
        public AdoptionApplication retrieveCustomerAdoptionApplicaionByCustomerEmail(string customerEmail)
        {
            adoptionApplication = adoptionAccessor.getAdoptionApplicationByCustomerEmail(customerEmail);
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

        public bool addAdoptionApplication(MVCAdoptionApplication adoptionApplication)
        {
            bool result = false;
            try
            {
                if (adoptionAccessor.insertAdoptionApplication(adoptionApplication))
                {
                    result = true;
                } 
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        //public List<string> retrieveCustomerQuestionnar()
        //{
        //    List<string> questionnairs = new List<string>();
        //    List<CustomerQuestionnar> customerQuestions = new List<CustomerQuestionnar>();
        //    try
        //    {
        //        customerQuestions = adoptionAccessor.getAllQuestions();
        //        foreach (var item in customerQuestions)
        //        {
        //            questionnairs.Add(item.QuestionDescription);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return questionnairs;
        //}
    }
}
