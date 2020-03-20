using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/16/2020
    /// Approver: Carl Davis 2/21/2020
    /// Approver:
    /// 
    /// Interface for the animal prescription manager
    /// </summary>
    public interface IAnimalPrescriptionManager
    {
        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver:
        /// 
        /// Creates an animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalPrescription">An AnimalPrescription object</param>
        /// <returns>Creation succesful</returns>
        bool AddAnimalPrescriptionRecord(AnimalPrescriptionVM animalPrescription);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Retrieves all animal prescription records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal prescriptions</returns>
        List<AnimalPrescriptionVM> RetrieveAllAnimalPrescriptions();

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Retrieves all animal prescription records for a
        /// specific animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal prescriptions</returns>
        List<AnimalPrescriptionVM> RetrievePrescriptionsByAnimalName(string animalName);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Edits an existing animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalPrescription">Existing record</param>
        /// <param name="newAnimalPrescription">Updated record</param>
        /// <returns>Edit successful</returns>
        bool EditAnimalPrescriptionRecord(AnimalPrescriptionVM oldAnimalPrescription,
            AnimalPrescriptionVM newAnimalPrescription);
    }
}
