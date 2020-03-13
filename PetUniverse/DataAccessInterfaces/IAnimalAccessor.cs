using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// an interface for accessing the animal data
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public interface IAnimalAccessor
    {
        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// a data access method for creating a new animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animal"></param>
        /// <returns>a 1 if successful, 0 if a failure</returns>
        int InsertAnimal(Animal animal);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/13/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Daulton Schilling, 2/14/2020
        /// 
        /// a data access method for retrieving a list of all animals that are listed as active
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of animal objects</returns>

        List<Animal> SelectAnimalsByActive(bool active = true);
        /// <summary>
        /// NAME: Michael Thompson
        /// DATE: 2/20/2020
        /// CHECKED BY: Austin Gee, 2/21/2020
        /// 
        /// Updates the animal with their forward facing description and image
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// CHANGE:
        /// </remarks>
        /// <param name="animal">The animal.</param>
        /// <param name="profileDescription">The profile description.</param>
        /// <param name="profileImagePath">The profile image path.</param>
        /// <returns>Bool</returns>

        bool UpdateAnimalProfile(int animalID, string profileDescription, string profileImagePath);
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// Approver: 
        /// 
        /// a data access Interface for retrieving a list of all animal profiles
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of animal objects</returns>
        List<Animal> SelectAllAnimnalProfiles();
        
        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// a data access method for retrieving a list of all animals that are listed as inactive
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of animal objects</returns>
        List<Animal> SelectAnimalsByInactive(bool active = false);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/28/2020
        /// Approver: Jordan Lindo, 2/28/2020
        /// Approver: 
        /// 
        /// a data access method for retrieving a list of all animals species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of animal species</returns>
        List<string> SelectAnimalSpeciesID();

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/12/2020
        /// Approver: Austin Gee, 3/12/2020
        /// Approver: 
        /// 
        /// a data access method for updating an animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>an int</returns>
        int UpdateAnimal(Animal oldAnimal, Animal newAnimal);
    }
}
