using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPFPresentation.Models;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/2
///  APPROVER: Lane Sandburg
///  
///  Controller for Schedule Change Requests
/// </summary>
namespace WPFPresentation.Controllers
{
    public class RequestScheduleChangeController : Controller
    {
        private IRequestManager _requestManager = null;
        private IShiftManager _shiftManager = null;


        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/2
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Constructor for instantiating RequestManager and ShiftManager
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public RequestScheduleChangeController()
        {
            _requestManager = new RequestManager();
            _shiftManager = new ShiftManager();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/2
        ///  APPROVER: Lane Sandburg
        ///  
        ///  View for submitting a new Schedule Change Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        // GET: RequestScheduleChange
        public ActionResult Create(int userID, string selectedDate)
        {
            UserWithShiftList model = new UserWithShiftList();

            ViewBag.Title = "Schedule Change Request";

            if (Convert.ToDateTime(selectedDate) <= DateTime.Now)
            {
                selectedDate = DateTime.Now.AddDays(1).ToShortDateString();
            }

            ViewBag.SelectedDate = selectedDate;

            Session["currentUserID"] = userID;

            if (0 != userID)
            {
                if (null == (List<ShiftVM>)Session["userShiftList"])
                {
                    Session["userShiftList"] = _shiftManager.RetrieveShiftsByUser(userID);
                }

                List<ShiftVM> selectedShiftList = new List<ShiftVM>();

                foreach (var shift in (List<ShiftVM>)Session["userShiftList"])
                {
                    if (Convert.ToDateTime(shift.Date) == Convert.ToDateTime(selectedDate))
                    {
                        selectedShiftList.Add(shift);
                    }
                }


                model.UserShiftList = selectedShiftList;
                model.UserID = userID;
            }

            return View(model);
        }


        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Post method for Create, submits the request if a shift was selected.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            try
            {
                int shiftID = Convert.ToInt32(formCollection["shiftList"]);

                ScheduleChangeRequest request = new ScheduleChangeRequest();
                request.ShiftID = shiftID;

                _requestManager.AddScheduleChangeRequest(request, Convert.ToInt32(Session["currentUserID"]));

                return RedirectToAction("Index", "ChooseRequestType", new { outputMessage = "SUCCESS: Schedule Change Request Submitted!" });
            }
            catch (Exception ex) //Null selection, return to selection page with same date
            {
                return RedirectToAction("Create", "RequestScheduleChange", new { userID = Session["currentUserID"], selectedDate = formCollection["ShiftDate"] });
            }
        }
    }
}