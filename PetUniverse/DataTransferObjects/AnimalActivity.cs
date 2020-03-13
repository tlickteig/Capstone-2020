using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// 
    /// Animal Activity class
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>

    public class AnimalActivity 
    {

        public int AnimalID { get; set; }
        public int UserID { get; set; }
        public string AnimalActivityTypeID { get; set; }
        public DateTime ActivityDateTime { get; set; }


      

    }
}

