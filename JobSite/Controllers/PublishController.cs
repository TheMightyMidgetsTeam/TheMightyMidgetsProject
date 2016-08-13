using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSite.Controllers
{
    public class PublishController : Controller
    {
        //GET: Publish
        public ActionResult PublishJob()
        {
            return View();
        }
    }
}