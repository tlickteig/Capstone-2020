using System.Web.Mvc;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/3/15
///  APPROVER: Lane Sandburg
///  
///  Controller for Selecting a Request Type to submit
/// </summary>

namespace WPFPresentation.Controllers
{
    public class ChooseRequestTypeController : Controller
    {
        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///  View that allows you to pick from scheduling Request Types to submit
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [Authorize]
        // GET: ChooseRequestType
        public ActionResult Index(string outputMessage = null)
        {
            ViewBag.Title = "Choose a Request Type";

            ViewBag.OutputMessage = outputMessage;

            return View();
        }
    }
}