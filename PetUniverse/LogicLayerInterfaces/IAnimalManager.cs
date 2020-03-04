using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// Interface for the animal manager
    /// </summary>
    public interface IAnimalManager
    {
        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// Interface to add a new animal to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="animal"></param>
        /// <returns>true or false depending on if the animal was added</returns>
        bool AddNewAnimal(Animal animal);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// Interface to get a list of all animals that are marked as active
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <returns>a list of animal objects</returns>
        List<Animal> RetrieveAnimalsByActive(bool active = true);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// Interface to get a list of all animals that are marked as inactive
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <returns>a list of animal objects</returns>
        List<Animal> RetrieveAnimalsByInactive(bool active = false);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/28/2020
        /// Approver: Jordan Lindo, 2/28/2020
        /// Approver: 
        /// 
        /// Interface to get a list of strings of animal species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <returns>a list of animal objects</returns>
        List<string> RetrieveAnimalSpecies();

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// 
        /// Interface to update a anial profile
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <returns>a list of animal objects</returns>
        bool UpdatePetProfile(int animalID, string profileDescription, String profileImagePath);
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// 
        /// Interface to get a list of all animal profiles
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <returns>a list of animal objects</returns>
        List<Animal> RetrieveAllAnimalProfiles();

    }
}
