using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HostelApp.Models
{
    public class HostelContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Faculty>Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }

        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<LivingRoom> LivingRooms { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}