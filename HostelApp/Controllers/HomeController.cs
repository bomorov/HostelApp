using HostelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Web.Security;


namespace HostelApp.Controllers
{
    public class HomeController : Controller
    {
        HostelContext db = new HostelContext();
        public ActionResult Index()
        {
            
            return View();
        }


        [Authorize(Roles="Commendant")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}