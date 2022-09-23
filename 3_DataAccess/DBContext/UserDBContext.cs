using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _3_DataAccess
{
    public class UserDBContext : DbContext 
    {
        public UserDBContext() : base("name = MVCStudent")
        {

        }
        public DbSet<User> Users {get; set;}
        public DbSet<HighSchoolStudent> HighschoolStudents { get; set; }
        public DbSet<CollegeStudent> CollegeStudents { get; set; }
        public DbSet<Professor> Professors { get; set; }

        public DbSet<Role> Roles{ get; set; }
        public DbSet<UserRole> UserRoles{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           

            //MAPPING DISCRIMINATOR
            modelBuilder.Entity<HighSchoolStudent>()

               .Map<HighSchoolStudent>(m => m.Requires("Discriminator").HasValue(1));



            modelBuilder.Entity<CollegeStudent>()

               .Map<CollegeStudent>(m => m.Requires("Discriminator").HasValue(2));

            modelBuilder.Entity<Professor>()

               .Map<Professor>(m => m.Requires("Discriminator").HasValue(3));



            //MAPPING ASSOCIATION(MANY TO MANY)
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