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
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/14/2020
    /// Approver: Chuck Baxter, 2/14/2020
    /// 
    /// Fake data access class for unit testing. Replaces the kennel accessor. 
    /// </summary>
    /// Coded by Ben Hanna - 2/12/2020
    /// Reviewed by Chuck Baxter, 2/14/2020
    /// Reviewed by Carl Davis, 2/14/2020
    /// </remarks>
    public class FakeAnimalKennelAccessor : IAnimalKennelAccessor
    {
        private List<AnimalKennel> records;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Constructor creates a list of kennel records for testing purposes
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FakeAnimalKennelAccessor()
        {
            records = new List<AnimalKennel>()
            {
                new AnimalKennel()
                {
                    AnimalKennelID = 1,
                    AnimalID = 1,
                    UserID = 1,
                    AnimalKennelInfo = "info info info",
                    AnimalKennelDateIn = new DateTime(2019, 5, 24),
                    AnimalKennelDateOut = new DateTime(2020, 2, 24)
                },

                new AnimalKennel()
                {
                    AnimalKennelID = 2,
                    AnimalID = 1,
                    UserID = 1,
                    AnimalKennelInfo = "info info info",
                    AnimalKennelDateIn = new DateTime(2020, 2, 25)
                }
            };
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Simulates adding a kennel record to the database. 
        /// Will intentionally throw an exception if the kennel ID isn't 1.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennel"></param>
        /// <returns> Represents the number of rows effected.</returns>
        public int InsertKennelRecord(AnimalKennel kennel)
        {
            if (kennel.AnimalKennelID == 1)
            {
                records.Add(kennel);

                return 1;
            }
            else
            {
                throw new Exception("Test exception");
            }

        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Gets all kennel records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns></returns>
        public List<AnimalKennel> RetriveAllAnimalKennels()
        {
            return records;
        }
    }
}
