namespace PhoenixBootstrap.Controllers
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Phoenix.Models;
    using Phoenix.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        public HomeController(IPhoenixData data)
            : base(data)
        {

        }

        public HomeController()
        {

        }

        public ActionResult Index()
        {
            ViewBag.Title="Phoenix Inspire";
            return View();
        }

        public ActionResult History()
        {
            ViewBag.Title = "History";
            return View();
        }

        public ActionResult Board()
        {
            ViewBag.Title = "Board";
            return View();
        }

        public ActionResult Staff()
        {
            ViewBag.Title = "Staff";
            return View();
        }

        public ActionResult CodeConduct()
        {
            ViewBag.Title = "Code of Conduct";
            return View();
        }

        public ActionResult AnualReports()
        {
            ViewBag.Title = "Anual Reports";
            return View();
        }

        public ActionResult FocusAreas()
        {
            ViewBag.Title = "Focus Areas";
            return View();
        }

        public ActionResult VacationTraining()
        {
            ViewBag.Title = "Vacation Trainings";
            return View();
        }

        public ActionResult SocialEnterprise()
        {
            ViewBag.Title = "Social Enterprise";
            return View();
        }

        public ActionResult Donors()
        {
            ViewBag.Title = "Donors";
            return View();
        }

        public ActionResult Sponsors()
        {
            ViewBag.Title = "Sponsors";
            return View();
        }

        public ActionResult Partnerships()
        {
            ViewBag.Title = "Partnerships";
            return View();
        }

        public ActionResult Cash()
        {
            ViewBag.Title = "Cash";
            return View();
        }

        public ActionResult Stocks()
        {
            ViewBag.Title = "Stocks";
            return View();
        }

        public ActionResult BitCoins()
        {
            ViewBag.Title = "Bit Coins";
            return View();
        }

        //public ActionResult Other()
        //{
        //    ViewBag.Title = "Other";
        //    return View();
        //}

        public ActionResult Blog()
        {
            ViewBag.Title = "Blog";
            return View();
        }

        public ActionResult Surveys()
        {
            ViewBag.Title = "Surveys";
            return View();
        }

        public ActionResult Events()
        {
            ViewBag.Title = "Events";
            return View();
        }

        public ActionResult Subscription()
        {
            ViewBag.Title = "Subscription";
            return View();
        }

        public ActionResult CurrentOpportunities()
        {
            ViewBag.Title = "Current Opportunities";
            return View();
        }

        public ActionResult ApplyOnline()
        {
            ViewBag.Title = "Apply Online";
            return View();
        }

         [HttpGet]
        public ActionResult Interviews()
        {
            ViewBag.Title = "Interviews";
            return View();
        }

         public ActionResult ContactInfo()
        {
            ViewBag.Title = "Contact us";
            return View();
        }

         [HttpGet]
        public ActionResult Newsletters()
        {
            ViewBag.Title = "Newsletters";
            return View();
        }

        [HttpGet]
        public ActionResult News()
        {
            ViewBag.Message = "News";
            return this.View();
        }

        [HttpGet]
        public ActionResult PageNotFound()
        {
            ViewBag.Message = "Sory, this page doesn't exist!";
            return this.View();
        }

        [HttpGet]
        public ActionResult PageError()
        {
            ViewBag.Message = "Ooops, sorry something went wrong! Please, try to connect again.";
            return this.View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult CreateAdminRole()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new PhoenixContext()));
            var roleCreateResult = roleManager.Create(new IdentityRole("Administrator"));

            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new User() { UserName = "admin", Email = "admin@admin.com", DateRegister = DateTime.Now };
            var createUserResult = userManager.Create(user, "Admin123!");

            if (!createUserResult.Succeeded)
            {
                throw new Exception(string.Join("; ", createUserResult.Errors));
            }

            userManager.AddToRole(user.Id, "Administrator");

            return View();

        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AdminPage()
        {
            ViewBag.Message = "For administrators only: welcome";

            return View();
        }

    }
}