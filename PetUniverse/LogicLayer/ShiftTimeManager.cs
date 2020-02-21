using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// NAME:Lane Sandburg
    /// DATE: 02/07/2019
    /// CHECKED BY:Alex Diers
    /// 
    /// the shift time Manager
    /// </summary>
    /// <remarks>
    /// UPDATED BY:NA
    /// UPDATED DATE:
    /// WHAT WAS CHANGED:
    /// </remarks> 
    public class ShiftTimeManager : IShiftTimeManager
    {
        private IShiftTimeAccessor _shiftTimeAccessor;
        public ShiftTimeManager()
        {
            _shiftTimeAccessor = new ShiftTimeAccessor();
        }

        public ShiftTimeManager(IShiftTimeAccessor shiftTimeAccessor)
        {
            _shiftTimeAccessor = shiftTimeAccessor;
        }


        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:Alex Diers
        /// 
        /// Logic for adding a shift time,
        /// returns true/false if shift time was added
        /// takes a shift time as a parameter.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks> 
        /// <param name="shiftTime"></param>
        public bool AddShiftTime(PetUniverseShiftTime shiftTime)
        {
            bool result = true;
            try
            {
                result = _shiftTimeAccessor.InsertShiftTime(shiftTime) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ShiftTime not added", ex);
            }
            return result;
        }

        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/13/2019
        /// CHECKED BY:Alex Diers
        /// 
        /// Logic for adding a editing time,
        /// returns true/false if shift time was added
        /// takes a shift time as a parameter.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks> 
        /// <param name="newShiftTime"></param>
        /// <param name="oldShiftTime"></param>
        public bool EditShiftTime(PetUniverseShiftTime oldShiftTime, PetUniverseShiftTime newShiftTime)
        {
            bool result = false;
            try
            {
                result = (1 == _shiftTimeAccessor.UpdateShiftTime(oldShiftTime, newShiftTime));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update failed", ex); ;
            }

            return result;
        }

        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/13/2019
        /// CHECKED BY:Alex Diers
        /// 
        /// Logic for retrieveing shift times,
        /// returns true/false if shift time was added
        /// takes a shift time as a parameter.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks> 

        public List<PetUniverseShiftTime> RetrieveShiftTimes()
        {
            List<PetUniverseShiftTime> shiftTimes = null;

            try
            {
                shiftTimes = _shiftTimeAccessor.SelectAllShiftTimes();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ShiftTimes not found", ex);
            }

            return shiftTimes;
        }
    }
}

