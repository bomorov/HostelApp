using HostelApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HostelApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {


        // GET: Admin

        HostelContext db = new HostelContext();
        public ActionResult Index()
        {
            return View();
        }



        /// Добавление и редактирование Студентов!!!!
        #region  
        [HttpGet]
        public ActionResult Add_Student(int id = 0)
        {

            SelectList group = new SelectList(db.Groups, "Id", "Name");
            ViewBag.Groups = group;
            SelectList region= new SelectList(db.Regions, "Id", "Name");
            ViewBag.Regions = region;
            SelectList livingRoom = new SelectList(db.LivingRooms, "Id", "Num");
            ViewBag.LivingRooms = livingRoom;
            return View();
        }
        [HttpPost]
        public ActionResult Add_Student(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit_Student(int? id)  /// Изменение данных студента
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Student student = db.Students.Find(id);
            if (student != null)
            {
                SelectList groups = new SelectList(db.Groups, "Id", "Name");
                ViewBag.Groups = groups;
                SelectList regions = new SelectList(db.Regions, "Id", "Name");
                ViewBag.Regions = regions;
                SelectList livingRoom = new SelectList(db.LivingRooms, "Id", "Num");
                ViewBag.LivingRooms = livingRoom;

                return View(student);
            }
            return RedirectToAction("Student_List");
        }

        [HttpPost]
        public ActionResult Edit_Student(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Student_List");
        }


        public ActionResult Delete_Student(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Student student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
            return RedirectToAction("Student_List");
        }


        public ActionResult Student_List()
        {
            var student = db.Students.Include(p => p.Group).Include(p => p.Group.Faculty).Include(p => p.LivingRoom).Include(p => p.Region);
            return View(student.ToList());
        }

        [HttpPost]
        public ActionResult Student_Search(string name)
        {
            var student = db.Students.Where(a => a.Name.Contains(name)).Include(p => p.LivingRoom).Include(p => p.Group).ToList();

            if (student.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(student);
        }

        public ActionResult Student_Search_Tittle()
        {
            return View();
        }


        public ActionResult Student_Details(int? id)  ///Детальное описание студентов
        {
            var student = db.Students.Include(p => p.Group).Include(p => p.Group.Faculty).Include(p => p.Group.Faculty.University).Include(p => p.LivingRoom).Include(p => p.Region).FirstOrDefault(s => s.Id == id);
           
            return View(student);
        }



         

        #endregion     /// Добавление и редактирование Студентов!!!!





        /// Добавление и редактирование Сотрудников!!!!
        #region
        [HttpGet]
        public ActionResult Add_Employee()
        {
            SelectList livingRoom = new SelectList(db.LivingRooms, "Id", "Num");
            ViewBag.LivingRooms = livingRoom;
            return View();
        }

        [HttpPost]
        public ActionResult Add_Employee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult Edit_Employee(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Employee employee = db.Employees.Find(id);
            if (employee != null)
            {
                
                SelectList livingRoom = new SelectList(db.LivingRooms, "Id", "Num");
                ViewBag.LivingRooms = livingRoom;
                return View(employee);
            }
            return RedirectToAction("Employee_List");
        }

        [HttpPost]
        public ActionResult Edit_Employee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Employee_List");
        }

        public ActionResult Employee_Details(int id=0)  ///Детальное описание сотрудника
        {
            var employee = db.Employees.Include(p => p.LivingRoom).FirstOrDefault(s=>s.Id==id);
            return View(employee);
        }



        public ActionResult Employee_List()
        {
            var employee = db.Employees.Include(p => p.LivingRoom);
            return View(employee.ToList());
        }


        [HttpPost]
        public ActionResult Employee_Search(string name)
        {
            var employee = db.Employees.Where(a => a.Name.Contains(name)).Include(p => p.LivingRoom).ToList();

            if (employee.Count <= 0)
            {
                return HttpNotFound();
                
            }
            return PartialView(employee);
        }

    

        public ActionResult Employee_Search_Tittle()
        {
            return View();
        }


        public ActionResult Delete_Employee(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Employee employee = db.Employees.Find(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            return RedirectToAction("Employee_List");
        }

        #endregion      /// Добавелние и редактирование сотрудников    



        

    }
}