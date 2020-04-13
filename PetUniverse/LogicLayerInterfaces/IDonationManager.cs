using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    ///  CREATOR: Ryan Morganti
    ///  CREATED: 2020/04/04
    ///  APPROVER: Matt Deaton
    ///  
    ///   Donation Manager Interface class
    /// </summary>
    public interface IDonationManager
    {
        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/04
        ///  APPROVER: Matt Deaton
        ///  
        ///  Donation Manager Interface method used when interacting with the logic layer to make requests
        ///  about Donations from the past year.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        List<Donation> RetrieveAllDonationsFromPastYear();
    }
}
