using System;
using System.Collections;
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
    /// Created: 2/21/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver: Chuck Baxter, 2/21/2020
    /// 
    /// Fake data access class for the animal handling notes
    /// </summary>
    public class FakeAnimalHandlingAccessor : IAnimalHandlingAccessor
    {
        private List<AnimalHandlingNotes> notes;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// A constructor that makes a list of animal handling notes records for editing.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FakeAnimalHandlingAccessor()
        {
            notes = new List<AnimalHandlingNotes>()
            {
                new AnimalHandlingNotes()
                {
                    HandlingNotesID = 100000,
                    UserID = 100000,
                    AnimalID = 100000,
                    HandlingNotes = "notes",
                    TemperamentWarning = "calm",
                    UpdateDate = DateTime.Now
                }
            };
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// simulates the presence of a method to return a list of animal notes
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns></returns>
        public List<AnimalHandlingNotes> SelectAllHandlingNotesByAnimalID(int animalID)
        {
            if ((from a in notes
                 where a.AnimalID == animalID
                 select a).Count() >= 1)
            {
                return notes;
            }

            else
            {
                throw new ApplicationException("data not found");
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Simulates a method to return a single Animal Handling Notes record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="handlingNotesID"></param>
        /// <returns></returns>
        public AnimalHandlingNotes SelectHandlingNotesByID(int handlingNotesID)
        {
            if ((from a in notes
                 where a.HandlingNotesID == handlingNotesID
                 select a).Count() >= 1)
            {
                return notes[0];
            }
            else
            {
                throw new ApplicationException("data not found");
            }
        }
    }
}
