using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HostelApp.Models
{
    public class Student
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "ФИО")]
        [Required(ErrorMessage = "Заполните поле")]
        public string Name { get; set; }


        [Display(Name = "Группа")]
        [Required(ErrorMessage = "Заполните поле")]
        public int GroupId { get; set; }
        public Group Group { get; set; }


        [Display(Name = "Дату рождения")]
        [Required(ErrorMessage = "Заполните поле")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Место прописки")]
        [Required(ErrorMessage = "Заполните поле")]
        public string ResidencePlace { get; set; }


        [Display(Name = "Регион")]
        [Required(ErrorMessage = "Заполните поле")]
        public int RegionId { get; set; }
        public Region Region { get; set; }


        [Display(Name = "Дата подачи заявки")]
        [Required(ErrorMessage = "Заполните поле")]
        public DateTime FillinDate { get; set; }

        [Display(Name = "Дата заселения")]
        [Required(ErrorMessage = "Заполните поле")]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Дата окончания срока")]
        [Required(ErrorMessage = "Заполните поле")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Оплата")]
        [Required(ErrorMessage = "Заполните поле")]
        public int Pay { get; set; }


        [Display(Name = "Комната")]
        [Required(ErrorMessage = "Заполните поле")]
        public int LivingRoomId { get; set; }
        public LivingRoom LivingRoom { get; set; }

       
        
    }
}