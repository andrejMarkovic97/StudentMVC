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

        public override List<CollegeStudent> GetAll()
        {
            return db.CollegeStudents.Include("UserRoles").ToList();
        }
    }
}