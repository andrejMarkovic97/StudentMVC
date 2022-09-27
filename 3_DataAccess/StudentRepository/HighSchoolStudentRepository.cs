using _3_DataAccess.GenericRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.Repository
{
    public class HighSchoolStudentRepository : GenericRepository<HighSchoolStudent>
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

        public override List<HighSchoolStudent> GetAll()
        {
            return db.HighschoolStudents.Include("UserRoles").ToList();

            
           
           
        }
    }
}