using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 2/3/20
    /// Approver: Jordan Lindo
    /// 
    /// This class is where we create the properties of a user
    /// </summary>
    /// <remarks>
    /// Updater: Chase Schulte
    /// Updated: 2/29/2020
    /// Update: Inherits ERole
    /// Updater: Lane Sandburg
    /// Updated: 3/17/2020
    /// Update: Added HasViewedPolAndStan
    /// Updater: Chase Schulte
    /// Updated: 04/10/2020
    /// Update: No longer inheirs ERole
    /// Approver: Kaleb Bachert

    /// </remarks>
    public class PetUniverseUser
    {
        public int PUUserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<string> PURoles { get; set; }
        public bool Active { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool HasViewedPolAndStan { get; set; }
    }
}
