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
    //using PhoenixBootstrap.ViewModels.Events;
    using System.Net;
    using System.Collections.Generic;

    // [Authorize]
    [ValidateInput(false)]
    public class EventsController : BaseController
    {
        private PhoenixContext db = new PhoenixContext();

        // GET: Events
        public EventsController(IPhoenixData data)
            : base(data)
        {

        }

        public EventsController()
        {

        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Index()
        {


            List<Events> events = new List<Events>();

            return View(events);
        }

        //GET : Events/Details/id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var events = db.Events.Find(id);
            //(from event in db.Events
            //          where event.Id == id
            //         select event).Take(1).ToList();


            if (events == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return View(events);
        }

        // GET: Events/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName");

            //var model = new EventsViewModel();

            return this.View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventsViewModel model)
        {
            //return null;
            if (this.ModelState.IsValid)
            {
                // model.AuthorId = this.User.Identity.GetUserId();
                db.Events.Add(new Events()
                {
                    //AuthorId = model.AuthorId,
                    Title = model.Title,
                    Description = model.Description//,
                    //DatePublic = DateTime.Now
                });

                db.SaveChanges();

                this.TempData["message"] = "Events added successfylly.";
                this.TempData["isMessageSuccess"] = true;

                return RedirectToAction("Index", "Home");
            }

            this.TempData["message"] = "There is a problem with the creation of this event. Please try again later.";
            this.TempData["isMessageSuccess"] = false;

            // this.ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName", model.AuthorId);
            return View("Events/Create", model);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }

           // ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName", Events.Author.Id);
            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AuthorId,Description,TakenDate")] Events events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName", events.AuthorId);

            return View(events);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Events events = db.Events.Find(id);

            if (events == null)
            {
                return HttpNotFound();
            }

            return View(events);
        }

    }
}