using DataTransferObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/3/16
///  APPROVER: Lane Sandburg
///  
///  Controller for Time Off Requests
/// </summary>

namespace WPFPresentation.Controllers
{
    public class RequestAvailabilityChangeController : Controller
    {
        private IRequestManager _requestManager = null;

        public RequestAvailabilityChangeController()
        {
            _requestManager = new RequestManager();
        }

        // GET: RequestTimeOff
        public ActionResult Create(PetUniverseUser user)
        {
            ViewBag.Title = "Availability Change Request";

            ViewBag.UserID = user.PUUserID;

            return View();
        }
    }
}