using JobSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();
            var jobPosts = db.JobPosts.OrderByDescending(p => p.PublishDate).Take(5);
            return View(jobPosts.ToList());           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact pageeeee.";

            return View();
        }
    }
}