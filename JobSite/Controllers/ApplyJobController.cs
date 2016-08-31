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
            ViewBag.JobPost = id;
            foreach (var appJ in filtring)
            {
                userList.Add(appJ.UserId);
            }
            return View(userList);

        }

        public ActionResult ViewCandidate(string userId, int jobpostId)
        {
            //picture
            //name phone 
            //email
            //message
            //status
            var currentUser = db.Users.FirstOrDefault(x => x.Id == userId);
            var photo = currentUser.GetImage();
            var appJob = db.ApplayJobs.OrderByDescending(x => x.ApplyDate).FirstOrDefault(x => x.UserId.Id == userId && x.JobPostId.Id == jobpostId);

            ViewBag.ApplyJob = appJob;
            var file = appJob.File;
            if (photo != null)
            {
                var photoText = Convert.ToBase64String(JobSite.Models.File.imageToByteArray(photo));
                ViewBag.Photo = String.Format("data:image/gif;base64,{0}", photoText);
            }
            if (file != null)
            {
                var cv = Convert.ToBase64String(file.Content);
                ViewBag.CV = String.Format("data:image/gif;base64,{0}", cv);
            }

            return View("ViewCandidate", currentUser);
        }

        public ActionResult ListAppliedJobs()
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            List<ApplyJob> appliedJobs = db.ApplayJobs.Where(x => x.UserId.Id == user.Id).ToList();

            List<JobPost> jobs = new List<JobPost>();
            foreach (var item in appliedJobs)
            {
                JobPost currentJob = db.JobPosts.FirstOrDefault(x => x.Id == item.JobPostId.Id);
                jobs.Add(currentJob);
            }

            ViewBag.Jobs = jobs;

            return View();
        }
    }
}