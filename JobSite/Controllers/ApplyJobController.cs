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
    [Authorize]
    public class ApplyJobController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplyJob
        [Authorize(Roles = "Users")]
        public ActionResult Index(int? id)
        {
            return View();
        }

        // POST: ApplyJob / ApplyForJob       
        [HttpPost]
        [Authorize(Roles = "Users")]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "JobPostId,Phone,Message")] ApplyJob applyJob, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser ap = db.Users.FirstOrDefault(x => x.Email == User.Identity.Name);
                applyJob.UserId = ap;
                db.ApplayJobs.Add(applyJob);
                applyJob.ApplyDate = DateTime.Now;
                var id = ValueProvider.GetValue("Id");
                var idInt = int.Parse(id.AttemptedValue);
                applyJob.JobPostId = db.JobPosts.FirstOrDefault(x => x.Id == idInt);

                ap.AddFileToUser(upload, FileType.CV, applyJob);

                db.SaveChanges();
                return RedirectToAction("Index", "Jobposts");
            }

            return View(applyJob);
        }
               
        public ActionResult ListCandidates(int? page)
        {           
            int PAGE_SIZE = 3;
            if (page == null)
            {
                page = 1;
            }
            int pageNumber = (page ?? 1);
            var filtring = from r in db.ApplayJobs                                                   
                           select r;
            return View(filtring.OrderByDescending(d => d.ApplyDate).ToPagedList(pageNumber, PAGE_SIZE));
        }
    }
}