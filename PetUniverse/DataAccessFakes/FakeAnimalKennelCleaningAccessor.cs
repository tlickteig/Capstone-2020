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
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis, 4/4/2020
    /// 
    /// Fake data access class for unit testing. Replaces the kennel cleaning records accessor.    
    /// </summary>
    public class FakeAnimalKennelCleaningAccessor : IAnimalKennelCleaningAccessor
    {

        private List<AnimalKennelCleaningRecord> cleaningRecords;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Constructor to set up the fake records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FakeAnimalKennelCleaningAccessor()
        {
            cleaningRecords = new List<AnimalKennelCleaningRecord>
            {
                new AnimalKennelCleaningRecord
                {
                    FacilityKennelCleaningID = 1, 
                    AnimalKennelID = 1, 
                    UserID = 1, 
                    Date = new DateTime(2019, 5, 24),
                    Notes = "Notes Notes 1"
                },

                new AnimalKennelCleaningRecord
                {
                    FacilityKennelCleaningID = 2,
                    AnimalKennelID = 2,
                    UserID = 1,
                    Date = new DateTime(2019, 6, 24),
                    Notes = "Notes Notes 2"
                }
            };
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Fake method for testing adding stuff.
        /// </summary>
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/9/2020
        /// Update: Updated return value so we weren't using a magic number
        /// </remarks>
        public int InsertKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord)
        {
            int result;
            if (cleaningRecord.FacilityKennelCleaningID > 0)
            {
                cleaningRecords.Add(cleaningRecord);

                result = 1;
            }
            else
            {
                throw new ApplicationException("test Exception");
            }
            return result;
        }
    }
}
