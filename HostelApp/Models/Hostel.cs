using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HostelApp.Models
{
    public class Hostel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Корпус")]
        public string Num { get; set; }
        public ICollection<LivingRoom> LivingRooms { get; set; }
        public Hostel()
        {
            LivingRooms = new List<LivingRoom>();
        }
    }
}