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
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var jobPosts = db.JobPosts.Where(p => p.ExpireDate > System.DateTime.Now).OrderByDescending(x=>x.PublishDate).ToList();
           // var jobPosts = db.JobPosts.OrderByDescending(p => p.ExpireDate > System.DateTime.Now).ToList();
            var cat = db.Categories.OrderByDescending(p => p.CategoryName).ToArray();
            var catDic = new Dictionary<Category, int>();
            var ctytDic = new Dictionary<City, int>();
            foreach (var c in jobPosts)
            {
                if (!catDic.ContainsKey(c.Category))
                {
                    catDic.Add(c.Category, 1);
                }
                else catDic[c.Category]++;
                if (!ctytDic.ContainsKey(c.City))
                {
                    ctytDic.Add(c.City, 1);
                }
                else ctytDic[c.City]++;
            }
            ViewBag.Category = catDic;
            ViewBag.City = ctytDic;
            return View();
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