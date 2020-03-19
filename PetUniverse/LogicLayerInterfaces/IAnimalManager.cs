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

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/12/2020
        /// Approver:  Austin Gee, 3/12/2020
        /// 
        /// Interface to update an animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="oldAnimal"></param>
        /// <param name="newAnimal"></param>
        /// <returns></returns>
        bool EditAnimal(Animal oldAnimal, Animal newAnimal);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Changes the animal's Active state
        /// </summary>
        /// <remarks>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="active"> The state Active is being changed to </param>
        /// <param name="animalID"> The primary key identifying the animal </param>
        /// <returns> Boolean value representig if the method succeeded or not. True is success. </returns>
        bool SetAnimalActiveState(bool active, int animalID);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Changes the animal's Adoptable state
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// Approver:
        /// </remarks>
        /// <param name="adoptable"> The state Adoptable is being changed to </param>
        /// <param name="animalID"> The primary key identifying the animal </param>
        /// <returns> Boolean value representig if the method succeeded or not. True is success. </returns>
        bool SetAnimalAdoptableState(bool adoptable, int animalID);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Changes the animal's CurrentlyHoused state
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="housed"> The state Active is being changed to </param>
        /// <param name="animalID"> The primary key identifying the animal </param>
        /// <returns> Boolean value representig if the method succeeded or not. True is success. </returns>
        bool SetAnimalHousedState(bool housed, int animalID);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/13/2020
        /// Approver: Carl Davis, 3/18/2020  
        /// 
        /// Interface to add an animal species
        /// </summary>
        /// <param name="animalSpecies"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        bool AddNewAnimalSpecies(string animalSpecies, string description);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020  
        /// 
        /// Interface to delete an animal species
        /// </summary>
        /// <param name="animalSpeciesID"></param>
        /// <returns></returns>
        bool DeleteAnimalSpecies(string animalSpeciesID);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020  
        /// 
        /// Interface to update an animal species
        /// </summary>
        /// <param name="oldAnimalSpeciesID"></param>
        /// <param name="newAnimalSpeciesID"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        bool EditAnimalSpecies(string oldAnimalSpeciesID, string newAnimalSpeciesID, string description);
    }
}
