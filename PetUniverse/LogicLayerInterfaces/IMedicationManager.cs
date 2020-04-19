using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/13/2020
    /// Approver: Chuck Baxter, 2/13/2020
    /// 
    /// Interface for medication manager
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>

    public interface IMedicationManager
    {
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
        List<Medication> RetrieveMedicationInventory();

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
        bool CreateMedicationOrder(OutgoingOrders order_);

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/4/2020
        /// Approver: Carl Davis, 3/6/2020
        /// Approver: 
        /// 
        /// Retrieves medications where quantity is below a certain number
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        List<Medication> RetrieveMedicationByLowQauntity();

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/4/2020
        /// Approver: Carl Davis, 3/6/2020
        /// Approver: 
        /// 
        /// Retrieves medications where quantity is zero
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        List<Medication> RetrieveMedicationByEmptyQauntity();


    }
}
