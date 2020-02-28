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
        Customer retrieveCustomerByCustomerName(string customerLastName);
        AdoptionApplication retrieveCustomerAdoptionApplicaionByCustomerID(int customerID);
        bool SubmitReviewerDecision(int adoptionApplicationID, string decision);
        List<CustomerQuestionnarVM> retrieveCustomerQuestionnar(int customerID);
    }
}
