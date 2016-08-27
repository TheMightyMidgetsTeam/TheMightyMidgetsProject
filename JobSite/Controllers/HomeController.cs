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
            var jobPosts = db.JobPosts.OrderByDescending(p => p.ExpireDate > System.DateTime.Now).ToList();
            var cat = db.Categories.OrderByDescending(p => p.CategoryName).ToArray();
            var catDic = new Dictionary<Category, int>();
            var ctytDic = new Dictionary<City, int>();
            foreach (var c in jobPosts)
            {
                if (!catDic.ContainsKey(c.Categories))
                {
                    catDic.Add(c.Categories, 1);
                }
                else catDic[c.Categories]++;
                if (!ctytDic.ContainsKey(c.CityId))
                {
                    ctytDic.Add(c.CityId, 1);
                }
                else ctytDic[c.CityId]++;
            }
            ViewBag.Category = catDic;
            ViewBag.City = ctytDic;
            return View(jobPosts.ToList());
        }
        public ActionResult CategoryList(string name)
        {
            var tempVal = db.JobPosts.ToList();
            var returnVAlue = new List<JobPost>();
            foreach (var item in tempVal)
            {
                if (item.Categories.CategoryName.Equals(name))
                {
                    returnVAlue.Add(item);
                }
            }

            return View(returnVAlue);
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