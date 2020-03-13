using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
   public class AnimalMedicalHistoryManagerTests
    {
        private IAnimalMedicalHistoryAccessor animalMedicalHistoryAccessor;

        public AnimalMedicalHistoryManagerTests()
        {
            animalMedicalHistoryAccessor = new FakeMedicalHistoryAccessor();
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// Test method for RetrieveAnimalMedicalHistoryByAnimalID- tests with correct value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveNewAnimalChecklistByAnimalIDWithCorrectValue()
        {
            // arrange
            List<MedicalHistory> MH;
            IAnimalMedicalHistoryManager _AnimalChecklistManager = new AnimalMedicalHistoryManager(animalMedicalHistoryAccessor);

            // act
            MH = _AnimalChecklistManager.RetrieveAnimalMedicalHistoryByAnimalID(1);

            // assert
            Assert.AreEqual(1, MH.Count);

        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// Test method for RetrieveAnimalMedicalHistoryByAnimalID- tests for throwing the correct exception
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRetrieveAnimalMedicalHistoryByAnimalIDThrowsCorrectException()
        {
            // arrange
            AnimalMedicalHistoryManager MH = new AnimalMedicalHistoryManager(animalMedicalHistoryAccessor);
            int TestValue = -100;

            // act
            MH.RetrieveAnimalMedicalHistoryByAnimalID(TestValue);

        }

    }
}
