using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessInterfaces;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// Animal manager class that has logic methods for the animal class
    /// </summary>
    public class AnimalManager : IAnimalManager
    {
        private IAnimalAccessor _animalAccessor;

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// constructor for animal manager for real data access
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public AnimalManager()
        {
            _animalAccessor = new AnimalAccessor();
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// constructor for animal manager for the fake data object
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="animalAccessor"></param>
        public AnimalManager(IAnimalAccessor animalAccessor)
        {
            _animalAccessor = animalAccessor;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// logic method that passes an animal object to the accessor method
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool AddNewAnimal(Animal animal)
        {
            bool result = true;
            try
            {
                result = _animalAccessor.InsertAnimal(animal) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Animal not added.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/13/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Daulton Schilling, 2/14/2020
        /// 
        /// logic method that uses an AnimalAccessor method to get a list of all animals
        /// that are marked as active
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of animal objects or an exception if the data wasnt found</returns>
        public List<Animal> RetrieveAnimalsByActive(bool active = true)
        {
            try
            {
                return _animalAccessor.SelectAnimalsByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// logic method that uses an AnimalAccessor method to get a list of all animals
        /// that are marked as inactive
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of animal objects or an exception if the data wasnt found</returns>
        public List<Animal> RetrieveAnimalsByInactive(bool active = false)
        {
            try
            {
                return _animalAccessor.SelectAnimalsByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/28/2020
        /// Approver: Jordan Lindo, 2/28/2020
        /// Approver: 
        /// 
        /// logic method that uses an AnimalAccessor method to get a list of all animal
        /// species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of strings or an exception if the data wasn't found</returns>
        public List<string> RetrieveAnimalSpecies()
        {
            try
            {
                return _animalAccessor.SelectAnimalSpeciesID();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Checked By: Austin Gee  
        /// 
        /// Logic method to update a Animal Profile 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>Bool of whether or not the value was successfully updated</returns>
        public bool UpdatePetProfile(int animalID, string profileDescription, string profileImagePath)
        {
            bool result;

            try
            {
                result = _animalAccessor.UpdateAnimalProfile(animalID, profileDescription, profileImagePath);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update Failed!", ex);
            }
            return result;
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// Approver: 
        /// 
        /// logic method that uses an AnimalAccessor method to get a list of all animal profiles
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of animal objects or an exception if the data was not found</returns>
        public List<Animal> RetrieveAllAnimalProfiles()
        {
            try
            {
                return _animalAccessor.SelectAllAnimnalProfiles();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }
    }
}
