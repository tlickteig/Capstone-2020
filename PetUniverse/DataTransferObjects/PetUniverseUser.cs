using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{   
    /// <summary>
     /// NAME: Zach Behrensmeyer
     /// CREATED: 2/3/20
     /// CHECKED BY: Steven Cardona
     /// 
     /// This class is where we create the properties of a user
     /// </summary>
    public class PetUniverseUser
    {
        public int PUUserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        
        public List<string> PURoles { get; set; }

        public bool Active { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

    }
}
