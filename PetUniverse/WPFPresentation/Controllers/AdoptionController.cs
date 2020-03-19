using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTransferObjects;
using LogicLayerInterfaces;
using LogicLayer;
using WPFPresentation.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace WPFPresentation.Controllers
{
    public class AdoptionController : Controller
    {
        private MVCAdoptionApplication adoptionApplication;
        private IAdoptionManager adoptionApplicationManager;

        public AdoptionController()
        {
            adoptionApplication = new MVCAdoptionApplication();
            adoptionApplicationManager = new ReviewerManager();
        }



        // GET: Adoption
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //GET:AdoptionApplication
        [HttpGet]
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

        //Post:AdoptionApplication
        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult AdoptionApplication(MVCAdoptionApplication adoptionApplication)
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

       
        
    }

}