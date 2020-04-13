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
    /// Creator: Ethan Murphy
    /// Created: 2/16/2020
    /// Approver: Carl Davis 2/21/2020    
    /// 
    /// Creates a fake list of animal prescription records
    /// for testing accessor methods
    /// </summary>
    public class FakeAnimalPrescriptionsAccessor : IAnimalPrescriptionsAccessor
    {

        private List<AnimalPrescriptionVM> AnimalPrescriptionVMs;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020        
        /// 
        /// No argument constructor that creates a list
        /// of fake animal prescription records for testing
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FakeAnimalPrescriptionsAccessor()
        {
            AnimalPrescriptionVMs = new List<AnimalPrescriptionVM>()
            {
                new AnimalPrescriptionVM()
                {
                    AnimalID = 1,
                    AnimalPrescriptionID = 1,
                    AnimalVetAppointmentID = 1,
                    PrescriptionName = "test",
                    Dosage = 2.0M,
                    Interval = "2 times a day",
                    AdministrationMethod = "Oral",
                    StartDate = DateTime.Parse("3/20/2020"),
                    EndDate = DateTime.Parse("4/15/2020"),
                    Description = "test",
                    AnimalName = "fawuief"
                },

                new AnimalPrescriptionVM()
                {
                    AnimalID = 2,
                    AnimalPrescriptionID = 2,
                    AnimalVetAppointmentID = 2,
                    PrescriptionName = "test2",
                    Dosage = 2.0M,
                    Interval = "2 times a day",
                    AdministrationMethod = "Oral",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(2),
                    Description = "test2",
                    AnimalName = "sgadgase"
                },

                new AnimalPrescriptionVM()
                {
                    AnimalID = 3,
                    AnimalPrescriptionID = 3,
                    AnimalVetAppointmentID = 3,
                    PrescriptionName = "test3",
                    Dosage = 2.0M,
                    Interval = "2 times a day",
                    AdministrationMethod = "Oral",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(2),
                    Description = "test3",
                    AnimalName = "hrehara"
                },

                new AnimalPrescriptionVM()
                {
                    AnimalID = 4,
                    AnimalPrescriptionID = 4,
                    AnimalVetAppointmentID = 4,
                    PrescriptionName = "test4",
                    Dosage = 2.0M,
                    Interval = "2 times a day",
                    AdministrationMethod = "Oral",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(2),
                    Description = "test4",
                    AnimalName = "weaagw"
                }
            };
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020        
        /// 
        /// Creates a fake animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="AnimalPrescriptionVM">An AnimalPrescriptionVM object</param>
        /// <returns>Creation succesful</returns>
        public bool CreateAnimalPrescriptionRecord(AnimalPrescriptionVM AnimalPrescriptionVM)
        {
            bool result = false;

            AnimalPrescriptionVMs.Add(AnimalPrescriptionVM);
            if (AnimalPrescriptionVMs[AnimalPrescriptionVMs.Count - 1] == AnimalPrescriptionVM)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Selects all fake animal prescription records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal prescription fakes</returns>
        public List<AnimalPrescriptionVM> SelectAllAnimalPrescriptionRecords()
        {
            return AnimalPrescriptionVMs;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Updates a fake animal prescription record
        /// for testing purposes
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalPrescriptionVM">Existing record</param>
        /// <param name="newAnimalPrescriptionVM">Updated record</param>
        /// <returns>Update successful</returns>
        public bool UpdateAnimalPrescriptionRecord(AnimalPrescriptionVM oldAnimalPrescriptionVM,
            AnimalPrescriptionVM newAnimalPrescriptionVM)
        {
            var foundRecord = AnimalPrescriptionVMs.Find(p =>
            p.AnimalPrescriptionID == oldAnimalPrescriptionVM.AnimalPrescriptionID &&
            p.AnimalID == oldAnimalPrescriptionVM.AnimalID &&
            p.AnimalVetAppointmentID == oldAnimalPrescriptionVM.AnimalVetAppointmentID &&
            p.PrescriptionName == oldAnimalPrescriptionVM.PrescriptionName &&
            p.Dosage == oldAnimalPrescriptionVM.Dosage &&
            p.Interval == oldAnimalPrescriptionVM.Interval &&
            p.AdministrationMethod == oldAnimalPrescriptionVM.AdministrationMethod &&
            p.StartDate == oldAnimalPrescriptionVM.StartDate &&
            p.EndDate == oldAnimalPrescriptionVM.EndDate &&
            p.Description == oldAnimalPrescriptionVM.Description);

            if (foundRecord != null)
            {
                AnimalPrescriptionVMs[AnimalPrescriptionVMs.IndexOf(foundRecord)]
                    = newAnimalPrescriptionVM;
                if (!AnimalPrescriptionVMs.Contains(foundRecord) &&
                    AnimalPrescriptionVMs.Contains(newAnimalPrescriptionVM))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
