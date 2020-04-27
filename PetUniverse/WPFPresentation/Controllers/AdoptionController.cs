using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WPFPresentation.Models;

namespace WPFPresentation.Controllers
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/3/7
    /// Approver: Mohamed Elamin 
    /// controlling Adoption Application and questionnair
    /// </summary>
    public class AdoptionController : Controller
    {
        private AdoptionApplication adoptionApplication;
        private IAdoptionManager adoptionApplicationManager;
        private Questionnair questionnair;
        private IAdoptionCustomerManager _adoptionCustomerManager;
        private IAdoptionApplicationManager _adoptionApplicationManager;
        private AdoptionAnimalManager _adoptionAnimalManager;

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/3/7
        /// Approver: Mohamed Elamin 
        /// default constructor assgined intial values
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA 
        /// </remarks>
        public AdoptionController()
        {
            adoptionApplication = new AdoptionApplication();
            adoptionApplicationManager = new ReviewerManager();
            questionnair = new Questionnair();
            _adoptionCustomerManager = new AdoptionCustomerManager();
            _adoptionApplicationManager = new AdoptionApplicationManager();
            _adoptionAnimalManager = new AdoptionAnimalManager();
        }


        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/3/7
        /// Approver: Mohamed Elamin 
        /// main page of the adoption section
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Michael Thompson
        /// UPDATE DATE: 04/7/20
        /// Approver Thomas Dupuy
        /// CHANGE: Adding the correct ActionResult to show all animals
        /// </remarks>
        /// <returns ActionResult></returns>
        // GET: Adoption
        [HttpGet]
        public ActionResult Index()
        {
            bool active = true;
            var animalProfiles = _adoptionAnimalManager.RetrieveAdoptionAnimalsByActive(active);
            return View(animalProfiles);
        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 04/7/20
        /// Approver Thomas Dupuy
        ///
        /// Action result to for the profiles page. 
        /// Takes a user to a new appliction with the selected animal ID and their profile
        /// </summary>
        /// <param name="model"></param>
        /// <param name="animalID"></param>
        /// <returns>New adoption application page</returns>
        public ActionResult Start(LoginViewModel model, int animalID)
        {
            this.adoptionApplication.AnimalID = animalID;
            this.adoptionApplication.CustomerEmail = model.Email;

            return View(this.adoptionApplication);
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/3/7
        /// Approver: Mohamed Elamin
        /// controlling Adoption Application and questionnair
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA 
        /// </remarks>
        /// <param name="model"></param>
        /// <returns ActionResult></returns> 
        //GET:AdoptionApplication
        [HttpGet]
        //[Authorize]
        public ActionResult AdoptionApplication(LoginViewModel model)
        {
            //var user = new ApplicationUser
            //{
            //    UserName = model.Email,
            //    Email = model.Email,

            //};
            this.adoptionApplication.CustomerEmail = model.Email;
            this.adoptionApplication.Status = "Reviewer";
            this.adoptionApplication.RecievedDate = DateTime.Today;
            //if (adoptionApplication != null)
            //{                
            this.adoptionApplication.qusetionnair = adoptionApplicationManager.retrieveCustomerQuestionnar(this.adoptionApplication.CustomerEmail);
            //}
            return View(this.adoptionApplication);
        }


        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/3/7
        /// Approver: Mohamed Elamin, 2020/10/3
        /// controlling Adoption Application and questionnair
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA 
        /// </remarks>
        /// <param name="adoptionApplication"></param>
        /// <returns ActionResult></returns>
        //Post:AdoptionApplication
        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult AdoptionApplication(AdoptionApplication adoptionApplication)
        {
            if (adoptionApplicationManager.addAdoptionApplication(adoptionApplication))
            {

                ViewBag.StatusMessage = "update goes right!";
                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.StatusMessage = "Model state is not valid";
                return RedirectToAction("Index");

                //return View();
            }
        }


        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/3/7
        /// Approver: Mohamed Elamin, 20202/10/3
        /// controlling Adoption Application and questionnair
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA 
        /// </remarks>
        /// <param name="model"></param>
        /// <returns ActionResult></returns>
        //GET:Questionnair
        [HttpGet]
        public ActionResult Questionnair(LoginViewModel model)
        {
            List<String> questions = new List<String>();
            questions = adoptionApplicationManager.retrieveAllQuestions();
            if (model.Email == "")
            {
                questionnair = new Questionnair();

            }
            questionnair.Question1 = questions[0];
            questionnair.Question2 = questions[1];
            questionnair.Question3 = questions[2];
            questionnair.Question4 = questions[3];
            questionnair.Question5 = questions[4];
            questionnair.Question6 = questions[5];
            questionnair.Question7 = questions[6];
            questionnair.Question8 = questions[7];
            questionnair.Question9 = questions[8];
            questionnair.Question10 = questions[9];
            return View(questionnair);
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/3/7
        /// Approver: Mohamed Elamin, 20202/10/3
        /// controlling Adoption Application and questionnair
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA 
        /// </remarks>
        /// <param name="questionnair"></param>
        /// <returns ActionResult></returns>
        //POST:Questionnair
        [HttpPost]
        public ActionResult Questionnair(Questionnair questionnair)
        {
            if (adoptionApplicationManager.addQuestionnair(questionnair))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "You already filled the Questionnair";
                return View(questionnair);
            }
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/11/2020
        /// Approver: Michael Thompson
        /// returns a list view of applications for a particular customer
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="customerEmail"></param>
        /// <returns></returns>
        public ActionResult CustomerApplicationList(string customerEmail = "tdupuy@PetUniverse.com")
        {
            var customer = _adoptionCustomerManager.RetrieveAdoptionCustomerByEmail(customerEmail);
            var applications = _adoptionApplicationManager.RetrieveAdoptionApplicationsByEmailAndActive(customerEmail);
            ViewBag.Title = "Animals you have applied to adopt";


            return View(applications);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/11/2020
        /// Approver: Michael Thompson
        ///
        /// returns a detail view of a customer adoption application
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        public ActionResult CustomerApplicationDetails(int adoptionApplicationID)
        {
            var adoptionApplication = _adoptionApplicationManager.RetrieveAdoptionApplicationByID(adoptionApplicationID);
            ViewBag.CustomerEmail = adoptionApplication.CustomerEmail;
            ViewBag.Title = "Your Adoption Application";
            return View(adoptionApplication);
        }


    }

}