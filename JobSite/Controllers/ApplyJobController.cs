using JobSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSite.Controllers
{
    public class ApplyJobController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplyJob
        public ActionResult ApplyJob()
        {
            return View();
        }

        // POST: ApplyJob        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyJob([Bind(Include = "Id,ApplyDate,Files,Phone,Message,")] ApplyJob applyJob)
        {
            if (ModelState.IsValid)
            {
                applyJob.ApplyDate = DateTime.Now;                                
                db.ApplayJobs.Add(applyJob);
                db.SaveChanges();
                return RedirectToAction("Index","JobPosts");
            }

            return View(applyJob);
        }
    }
}