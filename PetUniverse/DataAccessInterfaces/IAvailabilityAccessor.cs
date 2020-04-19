using DataTransferObjects;
using System.Collections.Generic;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/15
///  APPROVER: Lane Sandburg
///  
///  Interface for AvailabilityAccessor
/// </summary>
namespace DataAccessInterfaces
{
    public interface IAvailabilityAccessor
    {
        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/14
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for getting a list of all Users' Availabilities
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        List<Availability> SelectAllUsersAvailability();
    }
}
