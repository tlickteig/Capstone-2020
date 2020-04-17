using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{
    public class FakePoSCustomerPortalAccessor : IPoSCustomerPortalAccessor
    {
        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// Fake Accessor Method for Customer Portal testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public FakePoSCustomerPortalAccessor()
        {

            CustomerErrorVM fakeError = new CustomerErrorVM()
            {
                ErrorType = "FAKE Error",
                ErrorDesc = "Fake DESC"

            };

            List<CustomerErrorVM> errorList = new List<CustomerErrorVM>()
            {
                new CustomerErrorVM()
                {
                    ErrorType = "FAKE Error",
                    ErrorDesc = "Fake DESC"
                }

            };

            List<CreditCardVM2> cardrList = new List<CreditCardVM2>()
            {
                new CreditCardVM2()
                {
                    CardType = "FAKE TYPE",
                    CardNumber = "1234 JJJJ 5678 KKKK"
                }

            };

        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// Fake Add Credit Card Method.
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
        public int AddCreditCard(string cardType, string cardNumber, string securityCode)
        {
            if (cardType != null && cardNumber != "")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// Fake Delete Credit Card Method.
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int DeleteCreditCard(string cardNumber)
        {
            if(cardNumber == "1234 5555 JJFF KFD2")
            {
                return 1;
            } else
            {
                return 0;
            }
        }

       
        
        public List<CreditCardVM2> GetAllCreditCards()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// Fake Report Shipping Error Method.
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="errorDesc"></param>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public int ReportShippingError(string errorType, string errorDesc)
        {
            if (errorType != null && errorDesc != "")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
