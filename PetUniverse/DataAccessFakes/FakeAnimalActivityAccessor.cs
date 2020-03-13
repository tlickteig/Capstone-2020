using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObjects;

namespace DataAccessFakes
{

    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// 
    /// Class to provide fake animal activity data
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public class FakeAnimalActivityAccessor : IAnimalActivityAccessor
    {
        private List<AnimalActivity> _animalActivity;

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// fake animal activity records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FakeAnimalActivityAccessor()
        {
            _animalActivity = new List<AnimalActivity>()
            {
                new AnimalActivity() {
                    AnimalID = 1,

                    ActivityDateTime = DateTime.Now,

                     AnimalActivityTypeID = "Routine feeding",

                   



                },

                new AnimalActivity() {
                    AnimalID = 2,

                    ActivityDateTime = DateTime.Now,

                     AnimalActivityTypeID = "Routine feeding",

                    



                }




            };
        }
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Retrieves a list of fake animal activity records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public List<AnimalActivity> GetAnimalFeedingRecords()
        {
            return _animalActivity.ToList();



        }
    }
}
