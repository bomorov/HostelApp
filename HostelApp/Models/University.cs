using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace HostelApp.Models
{
    public class University
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Университет")]
        [Required(ErrorMessage = "Заполните поле")]
        public string Name { get; set; }


        public ICollection<Faculty> Faculties { get; set; }
        public University()
        {
            Faculties = new List<Faculty>();
        }
    }
}