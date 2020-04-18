using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/15
///  APPROVER: Lane Sandburg
///  
///  Interface for ActiveTimeOffAccessor
/// </summary>
namespace DataAccessInterfaces
{
    public interface IActiveTimeOffAccessor
    {
        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/14
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for getting a list of all Active Time Off
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        List<ActiveTimeOff> SelectAllUsersActiveTimeOff();
    }
}
