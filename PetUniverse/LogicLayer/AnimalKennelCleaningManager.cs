using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessLayer;
using DataAccessInterfaces;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/4/2020
    /// Approver:
    /// 
    /// Interface for the kennel cleaning manager
    /// </summary>
    public class AnimalKennelCleaningManager : IAnimalKennelCleaningManager
    {
        private IAnimalKennelCleaningAccessor _cleaningAccessor;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// Approver:
        /// 
        /// Constructor for the real data access class
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalKennelCleaningManager()
        {
            _cleaningAccessor = new AnimalKennelCleaningAccessor();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Constructor for the fake data access class
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="cleaningAccessor"></param>
        public AnimalKennelCleaningManager(IAnimalKennelCleaningAccessor cleaningAccessor)
        {
            _cleaningAccessor = cleaningAccessor;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Adds the kennel cleaning record to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="cleaningRecord"></param>
        /// <returns></returns>
        public bool AddKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord)
        {
            bool result = false;

            try
            {
                result = _cleaningAccessor.InsertKennelCleaningRecord(cleaningRecord) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Record not added.", ex);
            }

            return result;
        }
    }
}
