using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HostelApp.Models
{
    public class LivingRoom
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Номер")]
        [Required(ErrorMessage = "Заполните поле")]
        public string Num { get; set; }


        [Display(Name = "Количество жильцов")]
        [Required(ErrorMessage = "Заполните поле")]
        public int TenantsCount { get; set; }   // количество жильцов!!!


        [Display(Name = "Максимальное количество жильцов")]
        [Required(ErrorMessage = "Заполните поле")]
        public int MaxTenants { get; set; }   // Максимальное количество жильцов!!!

        public int HostelId { get; set; }
        public Hostel Hostel { get; set; }


        public ICollection<Student> Students { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public LivingRoom()
        {
            Students = new List<Student>();
            Employees = new List<Employee>();
        }

    }
}