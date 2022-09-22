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
        public DbSet<User> Users {get; set;}
        public DbSet<HighSchoolStudent> HighschoolStudents { get; set; }
        public DbSet<CollegeStudent> CollegeStudents { get; set; }

      
        public DbSet<Role> Roles{ get; set; }
        public DbSet<UserRole> UserRoles{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserRole>()
                .HasKey(c => new { c.UserID, c.RoleID });

            modelBuilder.Entity<User>()
                .HasMany(c => c.UserRoles)
                .WithRequired()
                .HasForeignKey(c => c.UserID);

            modelBuilder.Entity<Role>()
                .HasMany(c => c.UserRoles)
                .WithRequired()
                .HasForeignKey(c => c.RoleID);

        }

    }
}