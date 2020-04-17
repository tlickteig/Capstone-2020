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
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/13/2020
    /// Approver: Chuck Baxter, 2/13/2020
    /// 
    /// Medication manager class
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public class MedicationManager : IMedicationManager
    {
        private IMedicationAccessor _activityAccessor;

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// No argument constructor for medication manager
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public MedicationManager()
        {
            _activityAccessor = new MedicationAccessor();


        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Constructor for medication manager
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public MedicationManager(IMedicationAccessor MedicationManager)
        {
            _activityAccessor = MedicationManager;

        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// Approver: Ethan Murphy 2/21/2020
        /// 
        /// Creates a medication order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public bool CreateMedicationOrder(OutgoingOrders order_)
        {
            bool result = false;
            if (order_ == null)
            {
                throw new Exception("Record not added.");
            }
            try
            {
                result = _activityAccessor.InsertMedicationOrder(order_) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Record not added.", ex);
            }

            return result;




        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/3/2020
        /// Approver: Carl Davis, 3/6/2020
        /// Approver: 
        /// 
        /// Retrieve medication list where quantity is eqaul to zero
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public List<Medication> RetrieveMedicationByEmptyQauntity()
        {
            List<Medication> records = null;

            try
            {
                records = _activityAccessor.GetMedicationByEmptyQauntity();
            }
            catch (Exception ex)
            {
                throw new Exception("records not found", ex);
            }

            return records;
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/3/2020
        /// Approver: Carl Davis, 3/6/2020
        /// Approver: 
        /// 
        /// Retrieve medication list where quantity is below a specified number
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public List<Medication> RetrieveMedicationByLowQauntity()
        {
            List<Medication> records = null;

            try
            {
                records = _activityAccessor.GetMedicationByLowQauntity();
            }
            catch (Exception ex)
            {
                throw new Exception("records not found", ex);
            }

            return records;
        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Retrieves the medication inventory
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public List<Medication> RetrieveMedicationInventory()
        {
            List<Medication> records = null;

            try
            {
                records = _activityAccessor.GetCompleteMedicationInventory();
            }
            catch (Exception ex)
            {
                throw new Exception("records not found", ex);
            }

            return records;
        }
    }

}
