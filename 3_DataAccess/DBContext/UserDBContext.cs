using _4_BusinessObjectModel.Models;
using Microsoft.AspNet.Identity.EntityFramework;
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



            //MAPPING USER PROPERTIES
            var user = modelBuilder.Entity<User>();

            user.ToTable("t_user");
            user.HasKey(u => u.UserID);
            user.Property(u => u.UserID).HasColumnName("user_id").IsRequired();
            user.Property(u => u.Email).HasColumnName("email").IsRequired();
            user.Property(u => u.Password).HasColumnName("password").IsRequired();
            user.Property(u => u.FirstName).HasColumnName("first_name").IsRequired();
            user.Property(u => u.LastName).HasColumnName("last_name").IsRequired();
            user.Property(u => u.BirthDate).HasColumnName("birth_date").IsRequired();
            user.Property(u => u.PhoneNumber).HasColumnName("phone_number");
            user.Property(u => u.Adress).HasColumnName("adress");

            //MAPPING HIGHSCHOOL STUDENT 
            
            modelBuilder.Entity<HighSchoolStudent>().Property(hs => hs.SchoolName).HasColumnName("school_name");
            modelBuilder.Entity<HighSchoolStudent>().Property(hs => hs.EnrollmentDate).HasColumnName("enrollment_date").IsRequired();

            //MAPPING COLLEGE STUDENT
            
            modelBuilder.Entity<CollegeStudent>().Property(cs => cs.InstitutionName).HasColumnName("institution_name");
            modelBuilder.Entity<CollegeStudent>().Property(cs => cs.Generation).HasColumnName("generation");

            //MAPPING PROFESSOR
           
            modelBuilder.Entity<Professor>().Property(p => p.Subject).HasColumnName("subject");
            modelBuilder.Entity<Professor>().Property(p => p.Cabinet).HasColumnName("cabinet");

            //MAPPING ROLE
            var role = modelBuilder.Entity<Role>();
            role.ToTable("t_roles");
            role.HasKey(r => r.RoleID);
            role.Property(r => r.RoleID).HasColumnName("role_id");
            role.Property(r => r.RoleName).HasColumnName("role_name");

            //MAPPING USERROLES
            var userRole = modelBuilder.Entity<UserRole>();
            userRole.ToTable("t_user_roles");
            userRole.Property(ur => ur.UserID).HasColumnName("user_id");
            userRole.Property(ur => ur.RoleID).HasColumnName("role_id");
            



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