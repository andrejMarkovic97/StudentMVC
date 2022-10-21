using _3_DataAccess.GenericRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.Repository
{
    public class HighSchoolStudentRepository :GenericRepository<HighSchoolStudent>
    {
  

        public HighSchoolStudentRepository(UserDBContext db) :base(db)
        {
            
        }

        public override void Add(HighSchoolStudent hs)
        {
            db.Users.Add(hs);
            db.UserRoles.AddRange(hs.UserRoles);
            db.SaveChanges();
        }

        public override void Delete(Guid id)
        {
            var userRoles = db.UserRoles.ToList().Where(ur => ur.UserID == id);
            db.UserRoles.RemoveRange(userRoles);
            db.Users.Remove(Get(id));
            db.SaveChanges();
        }

        public override HighSchoolStudent Get(Guid id)
        {
            var user = db.HighschoolStudents.AsNoTracking().FirstOrDefault(s => s.UserID == id);
            if (user != null)
            {
                user.UserRoles = db.UserRoles.Include("Role").Where(ur => ur.UserID == id).ToList();
            }
            return user;
        }

        public override List<HighSchoolStudent> GetAll()
        {
            return db.HighschoolStudents.Include("UserRoles").ToList();

            
           
           
        }

        public override HighSchoolStudent GetUserByEmail(string email)
        {
            var user = db.HighschoolStudents.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                user.UserRoles = db.UserRoles.Include("Role").Where(ur => ur.UserID == user.UserID).ToList();
            }
            return user;
        }

        public override List<HighSchoolStudent> Search(string filter)
        {
            return db.HighschoolStudents.ToList().
                FindAll(x => x.FirstName.ToLower().Contains(filter) || x.LastName.ToLower().Contains(filter)|| x.BirthDate.ToString().Contains(filter) ||
                x.Email.ToLower().Contains(filter) || x.PhoneNumber.Contains(filter) || x.Adress.ToLower().Contains(filter) ||
                x.SchoolName.ToLower().Contains(filter) || x.EnrollmentDate.ToString().Contains(filter));
        }
    }
}