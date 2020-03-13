using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/12/2020
    /// Approver: Chuck Baxter, 2/21/2020
    /// Approver: 
    /// 
    /// class for medication order data objects
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public class MedicationOrder
    {
        public int ItemID { get; set; }
        public int ItemQuantity { get; set; }
        public string ItemName { get; set; }

    }
}
