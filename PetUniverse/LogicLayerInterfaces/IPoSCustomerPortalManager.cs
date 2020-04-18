using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{

    /// <summary>
    /// CREATOR: Ethan Holmes
    /// DATE: 4/14/2020
    /// APPROVER: Rasha Mohammed 
    /// 
    /// Interface for Customer Portal methods.
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks>
    public interface IPoSCustomerPortalManager
    {

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Reports a shipping error.
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="errorDesc"></param>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        int ReportShippingError(string errorType, string errorDesc);

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Adds a credit card.
        /// </summary>
        /// <param name="cardType"></param>
        /// <param name="cardNumber"></param>
        /// <param name="securityCode"></param>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        int AddCreditCard(string cardType, string cardNumber, string securityCode);

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Returns a list of all credit card records.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<CreditCardVM2> GetAllCreditCards();

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Deletes a credit card record.
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        int DeleteCreditCard(string cardNumber);
    }
}
