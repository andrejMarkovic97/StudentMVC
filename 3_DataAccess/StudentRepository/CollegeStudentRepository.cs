using _3_DataAccess.GenericRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace _3_DataAccess.Repository
{
    public class CollegeStudentRepository : GenericRepository<CollegeStudent>
    {

        public CollegeStudentRepository(UserDBContext db):base(db)
        {
           
        }

        public override void Add(CollegeStudent collegeStudent)
        {
                db.Users.Add(collegeStudent);
                db.UserRoles.AddRange(collegeStudent.UserRoles);
                db.SaveChanges();

        }
        public override void Delete(Guid id)
        {
            var userRoles = db.UserRoles.ToList().Where(ur => ur.UserID == id);
            db.UserRoles.RemoveRange(userRoles);
            db.Users.Remove(Get(id));
            db.SaveChanges();
        }

        public override CollegeStudent Get(Guid id)
        {
            var user = db.CollegeStudents.AsNoTracking().FirstOrDefault(s => s.UserID == id);
            if (user != null)
            {
                user.UserRoles = db.UserRoles.Include("Role").Where(ur => ur.UserID == id).ToList();
            }
            return user;
        }

        public override List<CollegeStudent> GetAll()
        {
            return db.CollegeStudents.Include("UserRoles").ToList();
        }

        public override CollegeStudent GetUserByEmail(string email)
        {
            var user = db.CollegeStudents.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                user.UserRoles = db.UserRoles.Include("Role").Where(ur => ur.UserID == user.UserID).ToList();
            }
            return user;
        }

        public override List<CollegeStudent> Search(string filter)
        {
            var list = db.CollegeStudents.ToList();

             return list.FindAll(x => x.FirstName.ToLower() == filter || x.LastName.ToLower() == filter || x.BirthDate.ToString() == filter ||
            x.Email.ToLower() == filter || x.PhoneNumber == filter || x.Adress.ToLower() == filter || x.InstitutionName.ToLower() == filter || x.Generation.ToString() == filter);
        }
    }
}