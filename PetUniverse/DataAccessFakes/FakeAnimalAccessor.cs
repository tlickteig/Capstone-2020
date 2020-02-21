using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// The fake animal accessor class, uses a collection of animal objects instead of an actual database
    /// </summary>
    public class FakeAnimalAccessor : IAnimalAccessor
    {
        private List<Animal> animals;
        private List<Animal> activeAnimals;

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// the List of animals to use in tests instead of an actual database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public FakeAnimalAccessor()
        {
            animals = new List<Animal>()
            {
                new Animal()
                {
                    AnimalID = 1,
                    AnimalName = "A",
                    Dob = DateTime.Now.Date,
                    AnimalBreed = "A",
                    ArrivalDate = DateTime.Now.Date,
                    ImageLocation = "A",
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    AnimalSpeciesID = "A",
                    StatusID = "A"
                },

                new Animal()
                {
                    AnimalID = 2,
                    AnimalName = "B",
                    Dob = DateTime.Now.Date,
                    AnimalBreed = "B",
                    ArrivalDate = DateTime.Now.Date,
                    ImageLocation = "B",
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    AnimalSpeciesID = "B",
                    StatusID = "B"
                }
            };
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// The fake data access method for adding a new animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="animal"></param>
        /// <returns></returns>
        public int InsertAnimal(Animal animal)
        {
            try
            {
                animals.Add(animal);
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/13/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Daulton Schilling, 2/14/2020
        /// 
        /// The fake data access method for selecting all of the active animals
        /// in the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<Animal> SelectAnimalsByActive(bool active = true)
        {
            try
            {
                activeAnimals = new List<Animal>();
                foreach (Animal animal in animals)
                {
                    if (animal.Active)
                    {
                        activeAnimals.Add(animal);
                    }
                }
                return activeAnimals;
            }
            catch
            {
                // should be null if there is a failure
                activeAnimals = null;
                return activeAnimals;
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// The fake data access method for selecting all of the inactive animals
        /// in the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<Animal> SelectAnimalsByInactive(bool active = false)
        {
            try
            {
                activeAnimals = new List<Animal>();
                foreach (Animal animal in animals)
                {
                    if (!animal.Active)
                    {
                        activeAnimals.Add(animal);
                    }
                }
                return activeAnimals;
            }
            catch
            {
                // should be null if there is a failure
                activeAnimals = null;
                return activeAnimals;
            }
        }
    }
}
