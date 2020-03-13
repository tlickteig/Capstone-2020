﻿using System;
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
        bool AddAnimalPrescriptionRecord(AnimalPrescriptions animalPrescription);

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
        List<AnimalPrescriptions> RetrieveAllAnimalPrescriptions();

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
        List<AnimalPrescriptions> RetrievePrescriptionsByAnimalName(string animalName);
    }
}
