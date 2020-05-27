using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace HostelApp.Models
{
    public class LoginModel
    {
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Заполните поле")]
        public string Name { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Заполните поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}