using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/13/2020
    /// Approver: Chuck Baxter, 2/13/2020
    /// 
    /// interface for medication accessor
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>

    public interface IMedicationAccessor
    {

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Gets the complete medication inventory
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        List<Medication> GetCompleteMedicationInventory();

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// Approver: Ethan Murphy 2/21/2020
        /// 
        /// inserts a fake medication order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        int InsertMedicationOrder(OutgoingOrders order_);
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/3/2020
        /// Approver: Carl Davis, 3/6/2020
        /// Approver: 
        /// 
        /// Get medication list where quantity is below a specified number
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        List<Medication> GetMedicationByEmptyQauntity();

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/3/2020
        /// Approver: Carl Davis, 3/6/2020
        /// Approver: 
        /// 
        /// Get medication list where quantity is eqaul to zero
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        List<Medication> GetMedicationByLowQauntity();


    }


}
