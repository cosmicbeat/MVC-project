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
    //using PhoenixBootstrap.ViewModels.News;
    using System.Net;
    using System.Collections.Generic;

    // [Authorize]
    [ValidateInput(false)]
    public class NewsController : BaseController
    {
        private PhoenixContext db = new PhoenixContext();

        // GET: News
        public NewsController(IPhoenixData data)
            : base(data)
        {

        }

        public NewsController()
        {

        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Index()
        {


            List<NewsArticle> news = new List<NewsArticle>();

            return View(news);
        }

        //GET : News/Details/id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var news = db.NewsArticles.Find(id);
            //(from news in db.News
            //          where news.Id == id
            //         select news).Take(1).ToList();


            if (news == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return View(news);
        }

        // GET: News/Create
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName");

        //    //var model = new NewsViewModel();

        //    return this.View();

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(NewsViewModel model)
        //{
        //    //return null;
        //    if (this.ModelState.IsValid)
        //    {
        //        // model.AuthorId = this.User.Identity.GetUserId();
        //        db.News.Add(new NewsArticle()
        //        {
        //            //AuthorId = model.AuthorId,
        //            Title = model.Title,
        //            Description = model.Description//,
        //            //DatePublic = DateTime.Now
        //        });

        //        db.SaveChanges();

        //        this.TempData["message"] = "News added successfylly.";
        //        this.TempData["isMessageSuccess"] = true;

        //        return RedirectToAction("Index", "Home");
        //    }

        //    this.TempData["message"] = "There is a problem with the creation of this news. Please try again later.";
        //    this.TempData["isMessageSuccess"] = false;

        //    // this.ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName", model.AuthorId);
        //    return View("News/Create", model);
        //}

        // GET: News/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    NewsArticle news = db.News.Find(id);
        //    if (news == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName", news.Author.Id);
        //    return View(news);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,AuthorId,Description,TakenDate")] NewsArticle news)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(news).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName", news.AuthorId);

        //    return View(news);
        //}

        // GET: News/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    NewsArticle news = db.News.Find(id);

        //    if (news == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(news);
        //}

    }
}