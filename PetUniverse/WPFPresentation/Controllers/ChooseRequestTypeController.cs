using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/3/15
///  APPROVER: Lane Sandburg
///  
///  Controller for Time Off Requests
/// </summary>

namespace WPFPresentation.Controllers
{
    public class ChooseRequestTypeController : Controller
    {
        // GET: ChooseRequestType
        public ActionResult Index()
        {
            ViewBag.Title = "Choose a Request Type";

            return View();
        }
    }
}