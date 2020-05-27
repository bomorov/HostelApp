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


      
        public ActionResult Hostel_List()  ///Список общежитий!!!
        {
            return View(db.Hostels.ToList());

        }

        public ActionResult Rooms_Hostel(int id = 0)   ///Команаты выбираемого общежития!!!
        {
            Hostel hostel = db.Hostels.Include(s=>s.LivingRooms).FirstOrDefault(s=>s.Id==id);
            if (hostel == null)
            {
                return HttpNotFound();
            }
            return View(hostel);
        }

        
        public ActionResult Room_List()
        {
            return View(db.LivingRooms.Include(p=>p.Hostel).ToList());
        }

        public ActionResult Room_List_Student(int id=0)
        {
            LivingRoom livingRoom = db.LivingRooms.Include(p => p.Students).Include(p=>p.Employees).FirstOrDefault(s => s.Id == id);
            if (livingRoom == null)
            {
                return HttpNotFound();
            }
            return View(livingRoom);
        }


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