using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{
    /// <summary>
    ///  CREATOR: Ryan Morganti
    ///  CREATED: 2020/04/05
    ///  APPROVER: Matt Deaton
    ///  
    ///  Fake Donation Accessor Class for Unit Testing
    /// </summary>
    public class FakeDonationAccessor : IDonationAccessor
    {
        
        private List<Donation> _donations = new List<Donation>()
        {
            new Donation {
                DonationID = 1,
                DateOfDonation = DateTime.Now.AddYears(-2)
            },
            new Donation {
                DonationID = 2,
                DateOfDonation = DateTime.Now.AddMonths(-11)
            },
            new Donation {
                DonationID = 3,
                DateOfDonation = DateTime.Now.AddMonths(-4)
            },
            new Donation {
                DonationID = 4,
                DateOfDonation = DateTime.Now
            }
        };

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/05
        ///  APPROVER: Matt Deaton
        ///  
        ///  Fake Donation Accessor Method to test retrieval of donation history
        ///  for the past year.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<Donation> SelectDonationsFromPastYear()
        {
            var donations = (from d in _donations
                             where d.DateOfDonation > DateTime.Now.AddYears(-1)
                             select d).ToList();
            return donations;
        }
    }
}
