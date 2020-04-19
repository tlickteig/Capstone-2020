using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    ///  CREATOR: Ryan Morganti
    ///  CREATED: 2020/04/04
    ///  APPROVER: Matt Deaton
    ///  
    ///   Donation Access class for connection to the database when making donation relation queries
    /// </summary>
    public interface IDonationAccessor
    {
        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/04
        ///  APPROVER: Matt Deaton
        ///  
        ///  Interface method to interact with the Donation Access class when querying about the 
        ///  past year's donation history.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        List<Donation> SelectDonationsFromPastYear();
    }
}
