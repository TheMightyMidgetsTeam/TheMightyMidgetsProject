using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobSite.Models;

namespace JobSite.Controllers
{
    [Authorize]
    public class ApplyJobController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplyJob
        public ActionResult Index()
        {
            return View();
        }

        // POST: ApplyJob / ApplyForJob       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Phone,Message")] ApplyJob applyJob)
        {
            if (ModelState.IsValid)
            {
                db.ApplayJobs.Add(applyJob);
                applyJob.ApplyDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applyJob);
        }
    }
}