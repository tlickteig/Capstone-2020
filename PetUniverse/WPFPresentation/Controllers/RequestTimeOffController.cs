using DataTransferObjects;
using LogicLayer;
using System;
using System.Web.Mvc;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/3/2
///  APPROVER: Lane Sandburg
///  
///  Controller for Time Off Requests
/// </summary>

namespace WPFPresentation.Controllers
{
    public class RequestTimeOffController : Controller
    {
        private IRequestManager _requestManager = null;


        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/2
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Constructor for instantiating the Request Manager
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public RequestTimeOffController()
        {
            _requestManager = new RequestManager();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  View for submitting a new Time Off Request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        // GET: RequestTimeOff
        public ActionResult Create(PetUniverseUser user, string startDateError = null, string endDateError = null)
        {
            ViewBag.Title = "Time Off Request";

            ViewBag.StartDateError = startDateError;
            ViewBag.EndDateError = endDateError;

            ViewBag.RequestingUserID = user.PUUserID;

            return View();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Post method for Create, adds request only if it passes validation, redirects to same page with errors otherwise
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        // POST: TimeOffRequest/Create
        [HttpPost]
        public ActionResult Create(string startDate, string endDate, int RequestingUserID)
        {
            if (ModelState.IsValid)
            {
                TimeOffRequest request = new TimeOffRequest()
                {
                    EffectiveStart = Convert.ToDateTime(startDate),
                    EffectiveEnd = Convert.ToDateTime(endDate)
                };

                //If EffectiveStart is after today, and EffectiveEnd is EffectiveStart or later
                if (request.EffectiveStart.CompareTo(DateTime.Now) > 0 &&
                    request.EffectiveEnd >= request.EffectiveStart)
                {
                    // Code to save the TimeOffRequest
                    try
                    {
                        _requestManager.AddTimeOffRequest(request, RequestingUserID);

                        return RedirectToAction("Index", "ChooseRequestType", new { outputMessage = "SUCCESS: Time Off Request Submitted!" });
                    }
                    catch
                    {
                        return RedirectToAction("Index", "ChooseRequestType", new { outputMessage = "ERROR: Could Not Submit Time Off Request" });
                    }
                }
                //One (or two) of the two fields were invalid, sends back error messages
                else
                {
                    return RedirectToAction("Create", "RequestTimeOff",
                        new { startDateError = "Start Date must be AFTER today!", endDateError = "End Date must be ON or AFTER Start Date!" });
                }
            }
            else
            {
                return View();
            }
        }
    }
}