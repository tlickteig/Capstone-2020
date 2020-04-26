using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WPFPresentation.Models;

namespace WPFPresentation.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationUserManager userManager;

        // GET: Admin
        public ActionResult Index()
        {
            userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            return View(userManager.Users.OrderBy(n => n.FamilyName).ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser appUser = userManager.FindById(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }

            var roleMgr = new LogicLayer.ERoleManager();
            var allRoles = roleMgr.RetrieveAllERoles();
            var allRoleIds = new List<string>();

            foreach (var role1 in allRoles)
            {
                allRoleIds.Add(role1.ERoleID);
            }

            var roles = userManager.GetRoles(id);
            var noRoles = allRoleIds.Except(roles);

            ViewBag.Roles = roles;
            ViewBag.NoRoles = noRoles;

            return View(appUser);
        }

        public ActionResult RemoveRole(string id, string role)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.Users.First(u => u.Id == id);

            if (role == "Administrator")
            {
                var adminUsers = userManager.Users.ToList()
                    .Where(u => userManager.IsInRole(u.Id, "Administrator"))
                    .ToList().Count();
                if (adminUsers < 2)
                {
                    ViewBag.Error = "Cannot remove last adminstrator.";
                }
                else
                {
                    userManager.RemoveFromRole(id, role);
                }
            }
            else
            {
                userManager.RemoveFromRole(id, role);
            }

            userManager.RemoveFromRole(id, role);

            var roleMgr = new LogicLayer.ERoleManager();
            var allRoles = roleMgr.RetrieveAllERoles();
            var allRoleIds = new List<string>();
            foreach (var role1 in allRoles)
            {
                allRoleIds.Add(role1.ERoleID);
            }

            var roles = userManager.GetRoles(id);
            var noRoles = allRoleIds.Except(roles);

            ViewBag.Roles = roles;
            ViewBag.NoRoles = noRoles;

            return View("Details", user);
        }

        public ActionResult AddRole(string id, string role)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.Users.First(u => u.Id == id);

            userManager.AddToRole(id, role);

            var roleMgr = new LogicLayer.ERoleManager();
            var allRoles = roleMgr.RetrieveAllERoles();
            var allRoleIds = new List<string>();
            foreach (var role1 in allRoles)
            {
                allRoleIds.Add(role1.ERoleID);
            }
            var roles = userManager.GetRoles(id);
            var noRoles = allRoleIds.Except(roles);

            ViewBag.Roles = roles;
            ViewBag.NoRoles = noRoles;

            return View("Details", user);
        }
    }
}