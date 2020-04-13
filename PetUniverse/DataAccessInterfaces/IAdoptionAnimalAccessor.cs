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
    /// DATE: 3/5/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This class contains Data Access fakes for data pertaining to Adoption Appointments.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public interface IAdoptionAnimalAccessor
    {
        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/5/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This class contains Data Access fakes for data pertaining to Adoption Appointments.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        List<AdoptionAnimalVM> SelectAdoptionAnimalsByActive(bool active);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/4/2020
        /// CHECKED BY: Micheal Thompson, 4/9/2020
        /// 
        /// Deactivates an animal
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        int DeactivateAdoptionAnimal(int animalID);
    }
}
