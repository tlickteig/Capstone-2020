using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/04
    /// Approver : Mohamed Elamin , 2/21/2020
    ///
    /// interface contains public method for reviewer manager
    /// </summary>
    public interface IAdoptionManager
    {

        List<AdoptionApplication> retrieveCustomersFilledQuestionnair();
        AdoptionCustomer retrieveCustomerByCustomerName(string customerLastName);
        AdoptionApplication retrieveCustomerAdoptionApplicaionByCustomerEmail(string customerID);
        bool SubmitReviewerDecision(int adoptionApplicationID, string decision);
        List<CustomerQuestionnar> retrieveCustomerQuestionnar(string customerEmail);
        bool addAdoptionApplication(MVCAdoptionApplication adoptionApplication);
       // List<string> retrieveCustomerQuestionnar();
    }
}
