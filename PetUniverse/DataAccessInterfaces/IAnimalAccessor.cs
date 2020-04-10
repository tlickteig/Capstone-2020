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
        /// Creator: Michael Thompson
        /// Created: 2/20/2020
        /// Approver: Austin Gee, 2/21/2020
        /// 
        /// Updates the animal with their forward facing description and image
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
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

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's Active state to 'true'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        int ActivateAnimal(int AnimalID);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's Active state to 'false'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        int DeactivateAnimal(int AnimalID);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's Adoptable state to 'true'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        int ActivateAdoptable(int AnimalID);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's Adoptable state to 'false'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        int DeactivateAdoptable(int AnimalID);


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's CurrentlyHoused state to 'true'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        int ActivateCurrentlyHoused(int AnimalID);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's CurrentlyHoused state to 'False'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        int DeactivateCurrentlyHoused(int AnimalID);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/13/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver:
        /// 
        /// a data access method for creating a new animal species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalSpecies"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        int InsertAnimalSpecies(string animalSpecies, string description);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver:
        /// 
        /// a data access method for deleting an animal species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalSpeciesID"></param>
        /// <returns></returns>
        int DeleteAnimalSpecies(string animalSpeciesID);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020
        /// Approver:
        /// 
        /// a data access method for updating an animal species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalSpeciesID"></param>
        /// <param name="newAnimalSpeciesID"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        int UpdateAnimalSpecies(string oldAnimalSpeciesID, string newAnimalSpeciesID, string description);
    }
}