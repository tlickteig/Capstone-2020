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

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/12/2020
        /// Approver: Austin Gee, 3/12/2020  
        /// 
        /// Logic method to update an Animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>Bool of whether or not the value was successfully updated</returns>
        public bool EditAnimal(Animal oldAnimal, Animal newAnimal)
        {
            try
            {
                return 1 == _animalAccessor.UpdateAnimal(oldAnimal, newAnimal);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update Failed!", ex);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Calls either the ActivateAnimal or DeactivateAnimal method based on the boolean value supplied
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="active"> Boolean value representing the value to change the active state to </param>
        /// <param name="animalID"> The primary key identifying the animal </param>
        /// <returns> Boolean value representing if the method succeeded or not. True = success. </returns>
        public bool SetAnimalActiveState(bool active, int animalID)
        {
            bool result = false;
            try
            {
                if (active)
                {
                    result = 1 == _animalAccessor.ActivateAnimal(animalID);
                }
                else
                {
                    result = 1 == _animalAccessor.DeactivateAnimal(animalID);
                }
                if (result == false)
                {
                    throw new ApplicationException("Error: Active state not changed.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed!", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Calls either the ActivateAnimal or DeactivateAnimal method based on the boolean value supplied
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="adoptable"> Boolean value representing the value to change the adoptable state to </param>
        /// <param name="animalID"> The primary key identifying the animal </param>
        /// <returns> Boolean value representing if the method succeeded or not. True = success. </returns>
        public bool SetAnimalAdoptableState(bool adoptable, int animalID)
        {
            bool result = false;
            try
            {
                if (adoptable)
                {
                    result = 1 == _animalAccessor.ActivateAdoptable(animalID);
                }
                else
                {
                    result = 1 == _animalAccessor.DeactivateAdoptable(animalID);
                }
                if (result == false)
                {
                    throw new ApplicationException("Error: Adoptable state not changed.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed!", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Calls either the ActivateAnimal or DeactivateAnimal method based on the boolean value supplied
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="housed"> Boolean value representing the value to change the Housed state to </param>
        /// <param name="animalID"> The primary key identifying the animal </param>
        /// <returns> Boolean value representing if the method succeeded or not. True = success. </returns>
        public bool SetAnimalHousedState(bool housed, int animalID)
        {
            bool result = false;
            try
            {
                if (housed)
                {
                    result = 1 == _animalAccessor.ActivateCurrentlyHoused(animalID);
                }
                else
                {
                    result = 1 == _animalAccessor.DeactivateCurrentlyHoused(animalID);
                }
                if (result == false)
                {
                    throw new ApplicationException("Error: Housed state not changed.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed!", ex);
            }
            return result;
        }
    }
}
