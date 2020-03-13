using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayerInterfaces;


namespace LogicLayer
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// 
    /// Interface for AnimalActivityManager
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public class AnimalActivityManager : IAnimalActivityManager
    {
        private IAnimalActivityAccessor _activityAccessor;


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// no argument constructor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        public AnimalActivityManager()
        {
            _activityAccessor = new AnimalActivityAccessor();
        }

        public AnimalActivityManager(IAnimalActivityAccessor animalActivityManager)
        {
            _activityAccessor = animalActivityManager;
        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Retrieves the animal feeding records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public List<AnimalActivity> RetrieveAnimalFeedingRecords()
        {
            List<AnimalActivity> records = null;

            try
            {
                records = _activityAccessor.GetAnimalFeedingRecords();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("records not found", ex);
            }

            return records;
        }




    }

}
