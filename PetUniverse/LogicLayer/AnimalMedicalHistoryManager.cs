using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 3/13/2020
    /// Approver: 
    /// 
    /// Class for accessing medical history  
    /// </summary>
    public class AnimalMedicalHistoryManager : IAnimalMedicalHistoryManager
    {

        private IAnimalMedicalHistoryAccessor _medHistoryAccessor;


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// no argument constructor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        public AnimalMedicalHistoryManager()
        {
            _medHistoryAccessor = new AnimalMedicalHistoryAccessor();
        }
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// constructor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        ///   /// <param name="animalMedHistoryManager"></param>
        public AnimalMedicalHistoryManager(IAnimalMedicalHistoryAccessor animalMedHistoryManager)
        {
            _medHistoryAccessor = animalMedHistoryManager;
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// Gets an animals medical history
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="AnimalID"></param>
        /// <Returns>
        /// List<NewAnimalChecklist>
        /// </Returns>
        public List<MedicalHistory> RetrieveAnimalMedicalHistoryByAnimalID(int id)
        {
            List<MedicalHistory> records = null;

            try
            {
                records = _medHistoryAccessor.GetAnimalMedicalHistoryByAnimalID(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("records not found", ex);
            }

            return records;
        }
    }
}
