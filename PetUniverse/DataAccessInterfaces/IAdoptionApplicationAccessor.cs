using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/18/2020
    /// CHECKED BY: 
    /// 
    /// Interface that contains methods that relate to adoption application
    /// data access methods
    /// </summary>
    public interface IAdoptionApplicationAccessor
    {

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/18/2020
        /// CHECKED BY: 
        /// 
        /// selects a list of ApplicationVMs by on Email
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        List<ApplicationVM> SelectAdoptionApplicationsByEmail(string email);
    }
}
