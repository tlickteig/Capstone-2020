using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessLayer;
using DataAccessInterfaces;
using LogicLayerInterfaces;

namespace LogicLayer
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/19/2020
    /// CHECKED BY: 
    /// 
    /// contains manager methods that interact with adoption application objects
    /// </summary>
    public class AdoptionApplicationManager : IAdoptionApplicationManager
    {
        IAdoptionApplicationAccessor _adoptionApplicationAccessor;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/19/2020
        /// CHECKED BY: 
        /// 
        /// Default constructor
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AdoptionApplicationManager()
        {
            _adoptionApplicationAccessor = new AdoptionApplicationAccessor();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/19/2020
        /// CHECKED BY: 
        /// 
        /// Constructor used for tests
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AdoptionApplicationManager(IAdoptionApplicationAccessor adoptionApplicationAccessor)
        {
            _adoptionApplicationAccessor = adoptionApplicationAccessor;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/19/2020
        /// CHECKED BY: 
        /// 
        /// Retrieves adoption applications by email from the data access layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<ApplicationVM> RetrieveAdoptionApplicationsByEmail(string email)
        {
            try
            {
                return _adoptionApplicationAccessor.SelectAdoptionApplicationsByEmail(email);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not found", ex);
            }
        }
    }
}
