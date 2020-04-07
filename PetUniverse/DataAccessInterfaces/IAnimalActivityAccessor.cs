using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// 
    /// Interface for AnimalActivityAccessor
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public interface IAnimalActivityAccessor
    {

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Gets the animal feeding records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        List<AnimalActivity> GetAnimalFeedingRecords();

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Gets animal activity records by activity type
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="activity">Activity type ID</param>
        /// <returns>List of animal activity records</returns>
        List<AnimalActivity> GetAnimalActivityRecordsByActivityType(string activity);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Gets animal activity types
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal activity types</returns>
        List<AnimalActivityType> GetAnimalActivityTypes();


        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Inserts an animal activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalActivity">The record to insert</param>
        /// <returns>List of animal activity types</returns>
        int InsertAnimalActivityRecord(AnimalActivity animalActivity);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/6/2020
        /// Approver: Chuck Baxter 4/7/2020
        /// 
        /// Updates an existing animal activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalActivity">The existing record</param>
        /// <param name="newAnimalActivity">The updated record</param>
        /// <returns>Update successful</returns>
        int UpdateAnimalActivityRecord(AnimalActivity oldAnimalActivity,
            AnimalActivity newAnimalActivity);
    }
}
