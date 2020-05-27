using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HostelApp.Models
{
    public class Faculty
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Факультет")]
        [Required(ErrorMessage = "Заполните поле")]
        public string Name { get; set; }

        [Display(Name = "Университет")]
        [Required(ErrorMessage = "Заполните поле")]
        public int UniversityId { get; set; }
        public University University { get; set; }
        public ICollection<Group> Groups { get; set; }
        public Faculty()
        {
            Groups = new List<Group>();
        }
    }
}