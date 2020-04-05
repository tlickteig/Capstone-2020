using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/4/2020
    /// 
    /// Interface for Kennel Cleaning Record Managers
    /// </summary>
    public interface IAnimalKennelCleaningManager
    {
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Adds a kennel cleaning record to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="cleaningRecord"></param>
        /// <returns></returns>
        bool AddKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord);
    }
}
