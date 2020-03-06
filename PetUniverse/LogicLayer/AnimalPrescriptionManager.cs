using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/16/2020
    /// Approver: Carl Davis 2/21/2020
    /// Approver:
    /// 
    /// Manager class for animal prescription records
    /// </summary>
    public class AnimalPrescriptionsManager : IAnimalPrescriptionManager
    {
        private IAnimalPrescriptionsAccessor _animalPrescriptionsAccessor;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver:
        /// 
        /// Constructor that accepts an instance of the animal
        /// prescription accessor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalPrescriptionsAccessor">An AnimalPrescription accessor</param>
        public AnimalPrescriptionsManager(IAnimalPrescriptionsAccessor animalPrescriptionsAccessor)
        {
            _animalPrescriptionsAccessor = animalPrescriptionsAccessor;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver:
        /// 
        /// No argument constructor that initializes an instance 
        /// of the animal prescriptions accessor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalPrescriptionsManager()
        {
            _animalPrescriptionsAccessor = new AnimalPrescriptionAccessor();
        }

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
        public bool AddAnimalPrescriptionRecord(AnimalPrescriptions animalPrescription)
        {
            try
            {
                return _animalPrescriptionsAccessor.CreateAnimalPrescriptionRecord(animalPrescription);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to create record", ex);
            }
        }
    }
}
