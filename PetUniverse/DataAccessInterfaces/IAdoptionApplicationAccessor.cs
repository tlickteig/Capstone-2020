using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{

    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/18/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Interface that contains methods that relate to adoption application
    /// data access methods
    /// </summary>
    public interface IAdoptionApplicationAccessor
    {

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/18/2020
        /// Approver: Thomas Dupuy
        /// 
        /// selects a list of ApplicationVMs by on Email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<ApplicationVM> SelectAdoptionApplicationsByEmail(string email);
    }
}
