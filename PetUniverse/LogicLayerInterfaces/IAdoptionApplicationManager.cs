using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/19/2020
    /// CHECKED BY: 
    /// 
    /// Interface adoption application methods
    /// </summary>
    
    public interface IAdoptionApplicationManager
    {
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
        List<ApplicationVM> RetrieveAdoptionApplicationsByEmail(string email);
    }
}
