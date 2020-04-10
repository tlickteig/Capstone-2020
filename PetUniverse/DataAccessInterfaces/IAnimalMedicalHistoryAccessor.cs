using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;


namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 3/13/2020
    /// Approver: Chuck Baxter
    /// 
    /// An interface for AnimalMedicalHistoryAccessor
    /// </summary>
    public interface IAnimalMedicalHistoryAccessor
    {

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: Chuck Baxter      
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
        List<MedicalHistory> GetAnimalMedicalHistoryByAnimalID(int id);
    }
}