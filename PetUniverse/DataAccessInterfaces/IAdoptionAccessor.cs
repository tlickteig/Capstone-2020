using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/05
    /// Approver: Mohamed Elamin 2/21/2020
    ///
    ///Include all interface(public) methods for ReviewerManger (Logic Layer)
    /// </summary>
    public interface IAdoptionAccessor
    {
        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/5
        /// Approver: Mohamed Elamin , 2/21/2020
        /// 
        /// retrieve All Adoption Apllications
        /// </summary>
        /// <remarks>
        /// </remarks>
        List<AdoptionApplication> getAllAdoptionApplication();

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/5
        /// Approver: Mohamed Elamin , 2/21/2020
        /// 
        /// retrieve the customer data from the customer table by his last name
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="customerLastName"></param>
        AdoptionCustomer getCustomerByCustomerName(string customerLastName);

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/15
        /// Approver: Mohamed Elamin , 2/21/2020
        /// 
        /// retrieve Customer last name record from customer table by his ID
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="customerID"></param>
        string getCustomerLastName(int customerID);

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/15
        /// Approver: Mohamed Elamin , 2/21/2020
        /// 
        /// retrieve question syntax acoording to questionID
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="questionID"
        string getQestionDescription(int questionID);

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/15
        /// Approver: Mohamed Elamin , 2/21/2020
        /// 
        /// retrieve Adoption Apllication for a customer by his ID
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="customerID"></param>
        AdoptionApplication getAdoptionApplicationByCustomerEmail(string customerEmail);

        List<CustomerQuestionnar> getCustomerQuestionnair(string customerEmail);

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/15
        /// Approver: Mohamed Elamin , 2/21/2020
        /// 
        /// update the status of the adoption application
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="decision"></param>
        int changeAdoptionApplicationStatus(int adoptionApplicationID, string decision);
      
        bool insertAdoptionApplication(MVCAdoptionApplication adoptionApplication);
    }
}
