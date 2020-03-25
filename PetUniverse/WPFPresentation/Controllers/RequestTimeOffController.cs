using DataTransferObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public RequestTimeOffController()
        {
            _requestManager = new RequestManager();
        }

        // GET: RequestTimeOff
        public ActionResult Create(PetUniverseUser user)
        {
            ViewBag.Title = "Time Off Request";

            ViewBag.RequestingUserID = user.PUUserID;

            return View();
        }

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

                        return RedirectToAction("Index", "ChooseRequestType"); //Make this redirect to same page with success message
                    }
                    catch
                    {
                        return RedirectToAction("Index", "ChooseRequestType"); //Make this redirect with error message
                    }
                }
                else
                {
                    //START MUST BE AFTER TODAY, END MUST BE EQUAL TO OR LATER THAN START
                    return RedirectToAction("Create");

                }
            }
            return View();
        }
    }
}