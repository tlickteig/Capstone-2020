using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME:Lane Sandburg
    /// DATE: 02/05/2019
    /// CHECKED BY:Alex Diers
    /// 
    /// Interface for shift time logic
    /// </summary>
    /// <remarks>
    /// UPDATED BY:NA
    /// UPDATED DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    public interface IShiftTimeManager
    {

        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:Alex Diers
        /// 
        /// defenition for adding a shift time,
        /// returns true/false if shift time was added
        /// takes a shift time as a parameter.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks> 
        /// <param name="shiftTime"></param>
        bool AddShiftTime(PetUniverseShiftTime shiftTime);

        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:Alex Diers
        /// 
        /// defenition for editing a shift time,
        /// returns true/false if shift time was added
        /// takes a shift time as a parameter.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks> 
        /// <param name="oldShiftTime"></param>
        /// <param name="newShiftTime"></param>

        bool EditShiftTime(PetUniverseShiftTime oldShiftTime, PetUniverseShiftTime newShiftTime);

        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:Alex Diers
        /// 
        /// defenition for retrieving all shift times,
        /// returns true/false if shift time was added
        /// takes a shift time as a parameter.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks> 

        List<PetUniverseShiftTime> RetrieveShiftTimes();

    }
}
