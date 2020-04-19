using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 02/05/2020
    /// Approver: Mohamed Elamin, 2/21/2020
    ///
    /// Include all interface(public) methods for ReviewerManger (Logic Layer)
    /// </summary>
    public interface IAdoptionAccessor
    {
        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 02/5/2020
        /// Approver: Mohamed Elamin, 2/21/2020
        /// 
        /// retrieve All Adoption Apllications
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        List<AdoptionApplication> getAllAdoptionApplication();

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 02/5/2020
        /// Approver: Mohamed Elamin, 2/21/2020
        /// 
        /// retrieve the customer data from the customer table by his last name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="customerLastName"></param>
        AdoptionCustomer getCustomerByCustomerName(string customerLastName);

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2/15/2020
        /// Approver: Mohamed Elamin, 2/21/2020
        /// 
        /// retrieve Customer last name record from customer table by his ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="customerID"></param>
        string getCustomerLastName(int customerID);

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2/15/2020
        /// Approver: Mohamed Elamin, 2/21/2020
        /// 
        /// retrieve question syntax acoording to questionID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="questionID"
        string getQestionDescription(int questionID);

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2/15/2020
        /// Approver: Mohamed Elamin, 2/21/2020
        /// 
        /// retrieve Adoption Apllication for a customer by his ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="customerID"></param>
        AdoptionApplication getAdoptionApplicationByCustomerEmail(string customerEmail);

        List<CustomerQuestionnar> getCustomerQuestionnair(string customerEmail);

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2/15/2020
        /// Approver: Mohamed Elamin, 2/21/2020
        /// 
        /// update the status of the adoption application
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="decision"></param>
        int changeAdoptionApplicationStatus(int adoptionApplicationID, string decision);

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2/15/2020
        /// Approver: Mohamed Elamin, 2/21/2020
        /// 
        /// insert the status of the adoption application
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="adoptionApplication"></param>
        bool insertAdoptionApplication(MVCAdoptionApplication adoptionApplication);

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2/15/2020
        /// Approver: Mohamed Elamin, 2/21/2020
        /// 
        /// Get all questions
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// </remarks>
        List<string> getAllQuestions();
        bool inserQuestionnair(MVCQuestionnair questionnair);
    }
}
