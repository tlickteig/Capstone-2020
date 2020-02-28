using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// an animal data trasfer object
    /// 
    /// <remarks>
    /// Updater: Chuck Baxter
    /// Updated: 2/28/2020
    /// Update: Removed status and image location
    /// Approver: Austin Gee
    /// 
    /// Updater:
    /// Updated:
    /// Update:
    /// </summary>remarks>
    /// </summary>
    public class Animal
    {
        public int AnimalID { get; set; }
        public string AnimalName { get; set; }
        public DateTime Dob { get; set; }
        public string AnimalBreed { get; set; }
        public DateTime ArrivalDate { get; set; }
        public bool CurrentlyHoused { get; set; }
        public bool Adoptable { get; set; }
        public bool Active { get; set; }
        public string AnimalSpeciesID { get; set; }
    }
}
