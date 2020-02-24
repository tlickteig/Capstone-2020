using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/14/2020
    /// Approver: Chuck Baxter, 2/14/2020
    /// 
    /// Manager class for the animal kennel table
    /// </summary>
    public class AnimalKennelManager : IAnimalKennelManager
    {
        private IAnimalKennelAccessor _kennelAccessor;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Constructor for real data access methods
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalKennelManager()
        {
            _kennelAccessor = new AnimalKennelAccessor();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Constructor for fake data access methods
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennelAccessor"></param>
        public AnimalKennelManager(IAnimalKennelAccessor kennelAccessor)
        {
            _kennelAccessor = kennelAccessor;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Adds a new kennel record to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennel"></param>
        /// <returns> returns True if the method was successful </returns>
        public bool AddKennelRecord(AnimalKennel kennel)
        {
            bool result = false;

            try
            {
                result = _kennelAccessor.InsertKennelRecord(kennel) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Record not added.", ex);
            }

            return result;
        }
    }
}
