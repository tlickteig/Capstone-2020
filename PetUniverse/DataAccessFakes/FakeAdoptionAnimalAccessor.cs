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
    /// Creator: Austin Gee
    /// Created: 3/5/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Adoption Animal Data Access fake used for testing purposes
    /// </summary>
    public class FakeAdoptionAnimalAccessor : IAdoptionAnimalAccessor
    {
        private List<AdoptionAnimalVM> _adoptionAnimalVMs;

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Constructor for the fake accessor, creates a list of 
        /// AdoptionAnimalVMs for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public FakeAdoptionAnimalAccessor()
        {
            _adoptionAnimalVMs = new List<AdoptionAnimalVM>()
            {
                new AdoptionAnimalVM()
                {
                    AnimalID = 000,
                    AnimalName = "Fake",
                    Dob = DateTime.Parse("10/10/2020"),
                    AnimalBreed = "Pit Bull",
                    ArrivalDate = DateTime.Parse("10/10/2020"),
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    AnimalSpeciesID = "Dog",
                    AnimalKennelID = 000,
                    AnimalKennelInfo = "Fake",
                    AnimalMedicalInfoID = 000,
                    IsSpayedorNuetered = true,
                    AdoptionApplicationID = 000,
                    CustomerID = 000,
                    UserID = 000,
                    UserFirstName = "Fake",
                    UserLastName = "Fake",
                    AnimalHandlingNotesID = 000,
                    AnimalHandlingNotes = "Fake",
                    TempermentWarning = "Fake",

                },

                new AdoptionAnimalVM()
                {
                    AnimalID = 001,
                    AnimalName = "Fake",
                    Dob = DateTime.Parse("10/10/2020"),
                    AnimalBreed = "Pit Bull",
                    ArrivalDate = DateTime.Parse("10/10/2020"),
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    AnimalSpeciesID = "Dog",
                    AnimalKennelID = 000,
                    AnimalKennelInfo = "Fake",
                    AnimalMedicalInfoID = 000,
                    IsSpayedorNuetered = true,
                    AdoptionApplicationID = 000,
                    CustomerID = 000,
                    UserID = 000,
                    UserFirstName = "Fake",
                    UserLastName = "Fake",
                    AnimalHandlingNotesID = 000,
                    AnimalHandlingNotes = "Fake",
                    TempermentWarning = "Fake",

                },

                new AdoptionAnimalVM()
                {
                    AnimalID = 002,
                    AnimalName = "Fake",
                    Dob = DateTime.Parse("10/10/2020"),
                    AnimalBreed = "Pit Bull",
                    ArrivalDate = DateTime.Parse("10/10/2020"),
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    AnimalSpeciesID = "Dog",
                    AnimalKennelID = 000,
                    AnimalKennelInfo = "Fake",
                    AnimalMedicalInfoID = 000,
                    IsSpayedorNuetered = true,
                    AdoptionApplicationID = 000,
                    CustomerID = 000,
                    UserID = 000,
                    UserFirstName = "Fake",
                    UserLastName = "Fake",
                    AnimalHandlingNotesID = 000,
                    AnimalHandlingNotes = "Fake",
                    TempermentWarning = "Fake",

                }
            };
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Selects Animals by active
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public List<AdoptionAnimalVM> SelectAdoptionAnimalsByActive(bool active)
        {
            return (from a in _adoptionAnimalVMs
                    where a.Active == active
                    select a).ToList();
        }
    }
}
