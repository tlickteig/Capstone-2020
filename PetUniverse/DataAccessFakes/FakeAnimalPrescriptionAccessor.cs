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
    /// Approver:
    /// 
    /// Creates a fake list of animal prescription records
    /// for testing accessor methods
    /// </summary>
    public class FakeAnimalPrescriptionsAccessor : IAnimalPrescriptionsAccessor
    {
        private List<AnimalPrescriptions> animalPrescriptions;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver:
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
            animalPrescriptions = new List<AnimalPrescriptions>()
            {
                new AnimalPrescriptions()
                {
                    AnimalID = 1,
                    AnimalPrescriptionID = 1,
                    AnimalVetAppointmentID = 1,
                    PrescriptionName = "test",
                    Dosage = 2.0M,
                    Interval = "2 times a day",
                    AdministrationMethod = "Oral",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(2),
                    Description = "test",
                    AnimalName = "fawuief"
                },
                new AnimalPrescriptions()
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
                new AnimalPrescriptions()
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
                new AnimalPrescriptions()
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
        /// Approver:
        /// 
        /// Creates a fake animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalPrescription">An AnimalPrescription object</param>
        /// <returns>Creation succesful</returns>
        public bool CreateAnimalPrescriptionRecord(AnimalPrescriptions animalPrescription)
        {
            bool result = false;

            animalPrescriptions.Add(animalPrescription);
            if (animalPrescriptions[animalPrescriptions.Count - 1] == animalPrescription)
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
        public List<AnimalPrescriptions> SelectAllAnimalPrescriptionRecords()
        {
            return animalPrescriptions;
        }
    }
}
