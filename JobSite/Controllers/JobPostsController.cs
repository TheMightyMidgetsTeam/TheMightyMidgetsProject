using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobSite.Models;
using PagedList;

namespace JobSite.Controllers
{

    public class JobPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobPosts
        public ActionResult Index(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.Action = "Index";
            return View(db.JobPosts.OrderByDescending(d => d.PublishDate).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CategoryList(string name, int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var tempVal = db.JobPosts.ToList();
            var returnVAlue = new List<JobPost>();
            foreach (var item in tempVal)
            {
                if (item.Category.CategoryName.Equals(name))
                {
                    returnVAlue.Add(item);
                }
            }
            ViewBag.Action = "CategoryList";
            ViewBag.RouteValues = name;

            return View("Index",returnVAlue.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CityList(string name, int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var tempVal = db.JobPosts.ToList();
            var returnVAlue = new List<JobPost>();
            foreach (var item in tempVal)
            {
                if (item.City.CityName.Equals(name))
                {
                    returnVAlue.Add(item);
                }
            }
            ViewBag.Action = "CityList";
            ViewBag.RouteValues = name;

            return View("Index", returnVAlue.ToPagedList(pageNumber, pageSize));
        }

        // GET: JobPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // GET: JobPosts/Create
        [Authorize]
        public ActionResult Create()
        {
            var db = new ApplicationDbContext();
            ViewBag.CityName = new SelectList(db.Cities, "Id", "CityName");
            IEnumerable<SelectListItem> items = db.Categories
              .Select(c => new SelectListItem
              {
                  Value = c.Id.ToString(),
                  Text = c.CategoryName
              });
            ViewBag.Category = items;
            return View();
        }

        // POST: JobPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Heading,PublishDate,ExpireDate,Body")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                var cty = ValueProvider.GetValue("CityName");
                var cat = ValueProvider.GetValue("Category");
                var cityID = int.Parse(cty.AttemptedValue);
                var catID = int.Parse(cat.AttemptedValue);
                jobPost.City = db.Cities.FirstOrDefault(x => x.Id == cityID);
                jobPost.Category = db.Categories.FirstOrDefault(x => x.Id == catID);

                //jobPost.City = ValueProvider.GetValue("1");
                jobPost.UserID = db.Users.FirstOrDefault(x => x.Email == User.Identity.Name);

                // jobPost.City = ctyVal;
                //  jobPost.Category = catVal;

                db.JobPosts.Add(jobPost);


                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobPost);
        }

        // GET: JobPosts/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // POST: JobPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Heading,PublishDate,ExpireDate,Body,City,Category")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobPost);
        }

        // GET: JobPosts/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // POST: JobPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            JobPost jobPost = db.JobPosts.Find(id);
            db.JobPosts.Remove(jobPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
