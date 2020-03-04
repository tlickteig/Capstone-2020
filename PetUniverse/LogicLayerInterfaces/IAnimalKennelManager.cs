using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/14/2020
    /// Approver: Chuck Baxter, 2/14/2020
    /// 
    /// Interface for Kennel Managers
    /// </summary>
    public interface IAnimalKennelManager
    {
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Adds a new kennel record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennel"></param>
        /// <returns> Returns true if the method succeeds </returns>
        bool AddKennelRecord(AnimalKennel kennel);
    }
}
