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
    /// Created: 2/21/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver: Chuck Baxter, 2/21/2020
    /// 
    /// Interface for the Animal handling notes features manager class
    /// </summary>
    public interface IAnimalHandlingManager
    {
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get handling notes by animal handling notes ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="handlingNotesID"></param>
        /// <returns>Single instance of AnimalHandlingNotes</returns>
        AnimalHandlingNotes GetHandlingNotesByID(int handlingNotesID);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get a list of animal handling notes by the animal's ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns>List of AnimalHandlingNotes objects</returns>
        List<AnimalHandlingNotes> GetAllHandlingNotesByAnimalID(int animalID);
    }
}
