using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 3/13/2020
    /// Approver: 
    /// Approver: 
    /// 
    /// An interface for AnimalMedicalHistoryManager
    /// </summary>
    public interface IAnimalMedicalHistoryManager
    {
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// Retrieves an animals medical history
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
        List<MedicalHistory> RetrieveAnimalMedicalHistoryByAnimalID(int id);
    }
}
