using LogicLayer;
using LogicLayerInterfaces;
using System.Web.Mvc;

namespace WPFPresentation.Controllers
{
    public class DonationsController : Controller
    {
        private IDonationManager _donationManager;

        public DonationsController()
        {
            _donationManager = new DonationManager();
        }


        // GET: Donations
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DonationFAQ()
        {
            return View();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/05
        /// Approver: Matt Deaton
        ///
        /// ActionResult Method to load a ListView of the Past Donations received by the
        /// PetUniverse Shelter
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        ///
        /// </remarks>
        public ActionResult PastDonations()
        {
            ViewBag.Title = "PastDonations";
            var donations = _donationManager.RetrieveAllDonationsFromPastYear();
            return View(donations);
        }
    }
}