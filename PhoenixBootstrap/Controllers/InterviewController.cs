namespace PhoenixBootstrap.Controllers
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Web.Mvc;
    using System.Linq;
    using System.Data.Entity;
    using Phoenix.Models;
    using Phoenix.Data;
    using PhoenixBootstrap.ViewModels;
    //using PhoenixBootstrap.ViewModels.Interviews;
    using System.Net;
    using System.Collections.Generic;

   // [Authorize]
    [ValidateInput(false)]
    public class InterviewController : BaseController
    {
        private PhoenixContext db = new PhoenixContext();

        // GET: Tweets
        public InterviewController(IPhoenixData data)
            :base(data)
        {

        }

        public InterviewController()
        {

        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        
        public ActionResult Index()
        {
            // var interviews = this.Data.Interviews
                 
            //    .Select(TweetViewModel.ViewModel)
            //     .OrderByDescending(t => t.TakenDate);
            //.Include(t => t.AuthorId); //.All()
            //.Include(t  => t.Author)
            //.Select(TweetViewModel.ViewModel)
            //.OrderByDescending(t => t.TakenDate);

            List<Interview> interviews = new List<Interview>();
            ViewBag.Message = "Interviews";

            if (interviews == null)
            {
                return this.RedirectToAction("PageNotFound", "Home");

            }
            else
            {
                return this.View(interviews);
            }

        //    //return this.View(tweets);

        //   
        //    return this.View();

            

            //if (this.UserProfile != null)
            //{

                //interviews = this.Data.Interviews.All().ToList();
              
            //}
            //else
            //{
            //   // interviews = this.Data.Interview.All().ToList();
            //}

           
        }

        //GET : Tweets/Details/id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var interview = db.Interviews.Find(id);
                //(from tweet in db.Tweets
                //          where tweet.Id == id
                //         select tweet).Take(1).ToList();


            if (interview == null)
            {
                return RedirectToAction("PageNotFound","Home");
            }

            return View(interview);
        }

        // GET: Tweets/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName");

            //var model = new TweetViewModel();

           return this.View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InterviewViewModel model)
        {
            //return null;
            if (this.ModelState.IsValid)
            {
               // model.AuthorId = this.User.Identity.GetUserId();
                db.Interviews.Add(new Interview()
                {
                    //AuthorId = model.AuthorId,
                    Title = model.Title,
                    Description = model.Description//,
                    //DatePublic = DateTime.Now
                });

                    db.SaveChanges();
   
                this.TempData["message"] = "Interview added successfylly.";
                this.TempData["isMessageSuccess"] = true;

                return RedirectToAction("Index", "Home");
            }

            this.TempData["message"] = "There is a problem with the creation of this interview. Please try again later.";
            this.TempData["isMessageSuccess"] = false;

           // this.ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName", model.AuthorId);
            return View("Interviews/Create", model);
        }

        // GET: Interviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Interview interview = db.Interviews.Find(id);
            if (interview == null)
            {
                return HttpNotFound();
            }

            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName", interview.Author.Id);
            return View(interview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AuthorId,Description,TakenDate")] Interview interview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName", interview.AuthorId);

            return View(interview);
        }

        // GET: Interviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Interview interview = db.Interviews.Find(id);

            if (interview == null)
            {
                return HttpNotFound();
            }

            return View(interview);
        }

    }
}