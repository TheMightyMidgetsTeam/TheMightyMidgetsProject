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
    }
}