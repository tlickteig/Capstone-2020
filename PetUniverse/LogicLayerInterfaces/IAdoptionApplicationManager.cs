using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/19/2020
    /// CHECKED BY: Michael Thompson
    /// 
    /// Interface adoption application methods
    /// </summary>

    public interface IAdoptionApplicationManager
    {
        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
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
        List<ApplicationVM> RetrieveAdoptionApplicationsByEmailAndActive(string email, bool active = true);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/11/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Retrieves adoption applications by id
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns></returns>
        ApplicationVM RetrieveAdoptionApplicationByID(int adoptionApplicationID);
    }
}
