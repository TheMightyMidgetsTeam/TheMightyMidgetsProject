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
        public ActionResult Index(int? id)
        {
            return View();
        }

        // POST: ApplyJob / ApplyForJob       
        [HttpPost]
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


        public ActionResult ListCandidates(int id)
        {
            var userList = new List<ApplicationUser>();
            var filtring = db.ApplayJobs.Where(r => r.JobPostId.Id == id);
            foreach (var appJ in filtring)
            {
                userList.Add(appJ.UserId);
            }
            return View(userList);

        }

        public ActionResult ViewCandidate (string id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == id);

            return View(user);
        }
    }
}