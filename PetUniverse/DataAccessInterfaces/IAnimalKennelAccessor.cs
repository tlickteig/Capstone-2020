using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/14/2020
    /// Approver: Chuck Baxter, 2/14/2020
    /// 
    /// Interface for the kennel accessor methods
    /// </summary>
    public interface IAnimalKennelAccessor
    {
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Adds a kennel record to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennel"></param>
        /// <returns> Integer representing how many rows were effected. Should be exactly 1 </returns>
        int InsertKennelRecord(AnimalKennel kennel);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/12/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Gets a list of all the kennel records in the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// </summary>
        /// <returns> List of kennel records </returns>
        List<AnimalKennel> RetriveAllAnimalKennels();
    }
}
