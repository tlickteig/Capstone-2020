using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/6/2020
    /// CHECKED BY: Mohamed Elamin, 02/07/2020
    /// 
    /// This class is a logic layer class that is used when dealing with data relating to Adoption Customers.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class AdoptionCustomerManager : IAdoptionCustomerManager
    {
        IAdoptionCustomerAccessor _adoptionCustomerAccessor;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Mohamed Elamin, 02/07/2020
        /// 
        /// This is the standard no argument constructor for this class.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AdoptionCustomerManager()
        {
            _adoptionCustomerAccessor = new AdoptionCustomerAccessor();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Mohamed Elamin, 02/07/2020
        /// 
        /// This is the constructor that is used when performing unit tests.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionCustomerAccessor"></param>
        public AdoptionCustomerManager(IAdoptionCustomerAccessor adoptionCustomerAccessor)
        {
            _adoptionCustomerAccessor = adoptionCustomerAccessor;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/18/2020
        /// CHECKED BY: 
        /// 
        /// This method accesses a AdoptionCutomerVM from the data access layer and sends it up
        /// to the presentation layer.
        /// </summary>
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public AdoptionCustomerVM RetrieveAdoptionCustomerByEmail(string email)
        {
            try
            {
                return _adoptionCustomerAccessor.SelectAdoptionCustomerByEmail(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Mohamed Elamin, 02/07/2020
        /// 
        /// This method accesses a list of AdoptionCutomerVM's from the data access layer and sends them up
        /// to the presentation layer.
        /// </summary>
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>

        /// <param name="active"></param>
        /// <returns></returns>
        public List<AdoptionCustomerVM> RetrieveAdoptionCustomersByActive(bool active = true)
        {
            List<AdoptionCustomerVM> adoptionCustomers = new List<AdoptionCustomerVM>();
            try
            {
                adoptionCustomers = _adoptionCustomerAccessor.SelectAdoptionCustomersByActive(active);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return adoptionCustomers;
        }
    }
}
