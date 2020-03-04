using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/21/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver:
    /// 
    /// Manager class for AnimalHandlingNotes
    /// </summary>
    public class AnimalHandlingManager : IAnimalHandlingManager
    {
        private IAnimalHandlingAccessor _handlingAccessor;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Constructor for the manager class. Real data access class.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalHandlingManager()
        {
            _handlingAccessor = new AnimalHandlingAccessor();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Constructor for the manager. Fake data access class.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="handlingAccessor"></param>
        public AnimalHandlingManager(IAnimalHandlingAccessor handlingAccessor)
        {
            _handlingAccessor = handlingAccessor;
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get Handling notes list by animal ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns>List of animal objects</returns>
        public List<AnimalHandlingNotes> GetAllHandlingNotesByAnimalID(int animalID)
        {
            try
            {
                return _handlingAccessor.SelectAllHandlingNotesByAnimalID(animalID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Notes not found", ex);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get single animal handling notes object
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="handlingNotesID"></param>
        /// <returns>A single animal handling notes object</returns>
        public AnimalHandlingNotes GetHandlingNotesByID(int handlingNotesID)
        {
            try
            {
                return _handlingAccessor.SelectHandlingNotesByID(handlingNotesID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Notes not found", ex);
            }
        }
    }
}
