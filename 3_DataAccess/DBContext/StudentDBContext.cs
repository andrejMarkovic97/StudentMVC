using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _3_DataAccess
{
    public class StudentDBContext : DbContext 
    {
        public StudentDBContext() : base("name = MVCStudent")
        {

        }
        public DbSet<Student> Students {get; set;}
        public DbSet<HighSchoolStudent> HighschoolStudents { get; set; }
        public DbSet<CollegeStudent> CollegeStudents { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<UserRole> UserRoles{ get; set; }


    }
}