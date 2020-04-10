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
    /// Created: 3/5/2020
    /// Approver: Thomas Dupuy
    /// 
    /// This class contains Data Access fakes for data pertaining to Adoption Appointments.
    /// </summary>
    public interface IAdoptionAnimalAccessor
    {
        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// This class contains Data Access fakes for data pertaining to Adoption Appointments.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<AdoptionAnimalVM> SelectAdoptionAnimalsByActive(bool active);
    }
}
