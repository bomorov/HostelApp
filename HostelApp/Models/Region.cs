using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace HostelApp.Models
{
    public class Region
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Регион")]
        [Required(ErrorMessage = "Заполните поле")]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public Region()
        {
            Students = new List<Student>();
        }
    }
}