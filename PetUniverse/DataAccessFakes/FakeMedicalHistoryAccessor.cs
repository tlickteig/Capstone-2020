using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{

    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 3/13/2020
    /// Approver: Chuck Baxter
    /// 
    /// Fake medical record class
    /// </summary>    
    public class FakeMedicalHistoryAccessor : IAnimalMedicalHistoryAccessor
    {
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: Chuck Baxter
        /// 
        /// Fake medical history records
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private List<MedicalHistory> MH;

        public FakeMedicalHistoryAccessor()
        {
            MH = new List<MedicalHistory>()
            {
                new MedicalHistory()
                {
                    AnimalID = 1,
                    AnimalName = "Cujo",
                    AnimalSpeciesID  = "doge",
                    Vaccinations = "Unknown",
                    Spayed_Neutered = true,
                    MostRecentVaccinationDate = DateTime.Now,
                    AdditionalNotes = "Prefers to be called 'Randy', likes trapp music, vapes constantly",
                }
            };
        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: Chuck Baxter
        /// 
        /// Fake method to an animals medical history
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <Returns>
        /// int
        /// </Returns>
        public List<MedicalHistory> GetAnimalMedicalHistoryByAnimalID(int id)
        {
            try
            {
                return (from b in MH
                        where b.AnimalID == id
                        select b).ToList();
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Animal with ID " + id + " not found", ex);
            }
        }
    }
}