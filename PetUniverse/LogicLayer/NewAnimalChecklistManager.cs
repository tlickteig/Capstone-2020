using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayerInterfaces;


namespace LogicLayer
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver:
    /// 
    /// Manager class for NewAnimalChecklist
    /// </summary>
    public class NewAnimalChecklistManager : INewAnimalChecklistManager
    {
        private INewAnimalChecklistAccessor _newAnimalChecklistAccessor;



        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver:
        /// 
        /// No argument constructor for NewAnimalChecklistManager
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public NewAnimalChecklistManager()
        {
            _newAnimalChecklistAccessor = new NewAnimalChecklistAccessor();
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        ///  constructor for NewAnimalChecklistManager
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="NewAnimalChecklistManager"></param>
        public NewAnimalChecklistManager(INewAnimalChecklistAccessor NewAnimalChecklistManager)
        {
            _newAnimalChecklistAccessor = NewAnimalChecklistManager;
        }

       


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Retrieves a new animal checklist by AnimalID
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
        public List<NewAnimalChecklist> RetrieveNewAnimalChecklistByAnimalID(int AnimalID)
        {

            List<NewAnimalChecklist> records = null;
            try
            {
                if (AnimalID < 1)
                {
                    throw new ArgumentOutOfRangeException();

                }

                try
                {
                    records = _newAnimalChecklistAccessor.GetNewAnimalChecklistByAnimalID(AnimalID);

                }
                catch (ArgumentOutOfRangeException ex)
                {
                    throw new ArgumentOutOfRangeException("Animal with ID " + AnimalID + " not found", ex);
                }
            }
            catch (Exception ex) { }
            return records;

        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/28/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// Retrieves the number of animals housed
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <Returns>
        /// int
        /// </Returns>
        public int RetrieveNumberOfAnimals(bool active = true)
        {
            int records = 0;

            AnimalAccessor am = new AnimalAccessor();

            records = am.SelectAnimalsByActive().Count;

            return records;
        }
    }

}
