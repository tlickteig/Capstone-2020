using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using LogicLayerInterfaces;
using DataTransferObjects;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace WPFPresentation.Controllers
{
    public class ScheduleSupervisorController : Controller
    {
        private UserManager _userManager = new UserManager();
        private IShiftTimeManager _shiftTimeManager = new ShiftTimeManager();
        private ApplicationUserManager userManager;
        private IShiftManager _shiftManager = new ShiftManager();

        // GET: ScheduleSupervisor
        // GET: ScheduleVolunteer/ShiftCalendar/5
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 04/25/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Creates a calendar for Shifts by viewing employee
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize]
        public ActionResult ShiftCalendarEmployee(int? id)
        {
            //var userId = User.Identity.GetUserId();
            //var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var user = userManager.Users.First(u => u.Id == userId);
            //int employeeID = (int)user.EmployeeID;

            //Uncomment when done with sample code
            int employeeID = 100000;

            //Make sure the user is in the db and is active
            if (_userManager.RetrieveAllActivePetUniverseUsers().Find(pu => pu.PUUserID == employeeID) != null)
            {
                ViewBag.name = _userManager.RetrieveAllActivePetUniverseUsers().Find(pu => pu.PUUserID == employeeID).FirstName + " " + _userManager.RetrieveAllActivePetUniverseUsers().Find(pu => pu.PUUserID == employeeID).LastName;
            }
            else
            {
                ViewBag.name = "Invalid User";
            }



            if (id != null)
            {
                //Make sure ID exists
                if (_shiftManager.RetrieveShiftsByUser(employeeID).Find(shift => shift.ShiftID == id) != null)
                {
                    ViewBag.ShiftID = (int)id;
                    var shiftDetails = _shiftManager.RetrieveShfitDetailsByID((int)id);
                    ViewBag.ShiftDetails = shiftDetails;
                }

            }
            else
            {
                ViewBag.ShiftID = null;
            }
            var shifts = _shiftManager.RetrieveShfitDetailsByUserID(employeeID);
            return View(shifts);

        }

    }
}