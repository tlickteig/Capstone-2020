using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    ///  CREATOR: Ryan Morganti
    ///  CREATED: 2020/04/04
    ///  APPROVER: Matt Deaton
    ///  
    ///   Donation Manager class to handle the logic of querying for data about donations
    /// </summary>
    public class DonationManager : IDonationManager
    {
        private IDonationAccessor _donationAccessor;

        public DonationManager()
        {
            _donationAccessor = new DonationAccessor();
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/05
        ///  APPROVER: Matt Deaton
        ///  
        /// Constructor for passing a particular DonationAccessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public DonationManager(IDonationAccessor donationAccessor)
        {
            _donationAccessor = donationAccessor;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/04
        ///  APPROVER: Matt Deaton
        ///  
        ///  Donation Manager method for retrieving a list of donations from the past year.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public List<Donation> RetrieveAllDonationsFromPastYear()
        {
            List<Donation> donations = new List<Donation>();

            try
            {
                donations = _donationAccessor.SelectDonationsFromPastYear();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not locate past donations", ex);
            }

            return donations;
        }
    }
}
