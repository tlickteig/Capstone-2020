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
    /// Updater: Ethan Murphy
    /// Updated: 4/2/2020
    /// Update: Added more funtionality
    /// </remarks>
    public class AnimalActivityManager : IAnimalActivityManager
    {
        private IAnimalActivityAccessor _activityAccessor;
        private List<AnimalActivity> animalActivities = null;

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
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Adds an animal activity record to the DB
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="animalActivity">Activity record to be added</param>
        /// <returns>Result of insert</returns>
        public bool AddAnimalActivityRecord(AnimalActivity animalActivity)
        {
            try
            {
                return _activityAccessor.InsertAnimalActivityRecord(animalActivity) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to add record", ex);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Retrieves list of animal activity types
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <returns>List of animal activity types</returns>
        public List<AnimalActivityType> RetrieveAllAnimalActivityTypes()
        {
            try
            {
                return _activityAccessor.GetAnimalActivityTypes();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve activity types", ex);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Retrieves animal activities by activity type
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="activityType">Activity type ID</param>
        /// <returns>List of animal activities</returns>
        public List<AnimalActivity> RetrieveAnimalActivitiesByActivityType(string activityType)
        {
            try
            {
                animalActivities = _activityAccessor.GetAnimalActivityRecordsByActivityType(activityType);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve activities", ex);
            }
            return animalActivities;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Searches the list of animal activity records with the
        /// specified animal name and returns results with similar names
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="animalName">The name of the animal</param>
        /// <param name="activityType">The activity type to search</param>
        /// <returns>List of animal activity types</returns>
        public List<AnimalActivity> RetrieveAnimalActivitiesByPartialAnimalName(string animalName, string activityType)
        {
            if (animalActivities == null)
            {
                RetrieveAnimalActivitiesByActivityType(activityType);
            }
            return (from a in animalActivities
                    where a.AnimalName.ToLower().IndexOf(animalName.ToLower()) > -1
                    select a).ToList();
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
