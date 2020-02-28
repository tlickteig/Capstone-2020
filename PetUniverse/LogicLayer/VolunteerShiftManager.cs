using DataAccessFakes;
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
    ///     AUTHOR: Timothy Lickteig
    ///     CONTRIBUTERS: Kaleb Bachert
    ///     DATE: 2020-02-05
    ///     CHECKED BY: Zoey McDonald
    ///     Class for managing available volunteer shifts
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public class VolunteerShiftManager : IVolunteerShiftManager
    {
        IVolunteerShiftAccessor _accessor;

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <returns>VolunteerShiftManager object</returns>
        public VolunteerShiftManager()
        {
            _accessor = new VolunteerShiftAccessorFake();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="accessor">Data Access object</param>
        /// <returns>VolunteerShiftManager object</returns>
        public VolunteerShiftManager(IVolunteerShiftAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="shift">Shift Object to be passed</param>
        /// <returns>Number of rows affected</returns>
        public int AddVolunteerShift(VolunteerShift shift)
        {
            int rows = 0;
            try
            {
                rows = _accessor.AddShift(shift);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-08
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="shift">ID of shift to remove</param>
        /// <returns>Number of rows affected</returns>
        public int RemoveVolunteerShift(int shiftID)
        {
            int rows = 0;
            try
            {
                rows = _accessor.RemoveShift(shiftID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-10
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="oldShift">Old shift to be replaced</param>
        /// <param name="newShift">Replacement shift</param>
        /// <returns>Number of rows affected</returns>
        public int EditVolunteerShift(VolunteerShift oldShift, VolunteerShift newShift)
        {
            int rows = 0;
            try
            {
                rows = _accessor.UpdateShift(oldShift, newShift);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rows;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-17
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <returns>A list of availible shifts</returns>
        public List<VolunteerShift> ReturnAllVolunteerShifts()
        {
            List<VolunteerShift> shifts = new List<VolunteerShift>();

            try
            {
                shifts = _accessor.SelectAllShifts();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return shifts;
        }
    }
}
