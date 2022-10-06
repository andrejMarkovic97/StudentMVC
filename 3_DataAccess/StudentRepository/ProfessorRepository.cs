using _3_DataAccess.GenericRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace _3_DataAccess.StudentRepository
{
    public class ProfessorRepository : GenericRepository<Professor>
    {
        public ProfessorRepository(UserDBContext db) :base(db)
        {

        }

        public override void Add(Professor professor)
        {
            if (professor != null)
            {
                db.Professors.Add(professor);
                if (professor.UserRoles != null && professor.UserRoles.Count > 0)
                {
                    db.UserRoles.AddRange(professor.UserRoles);
                }

                db.SaveChanges();
            }
        }
        
        public override void Delete(Guid id)
        {
            var userRoles = db.UserRoles.ToList().Where(ur => ur.UserID == id);
            if (userRoles != null)
            {
                db.UserRoles.RemoveRange(userRoles);
            }
            db.Users.Remove(Get(id));
            db.SaveChanges();
        }

        public override List<Professor> GetAll()
        {
            return db.Professors.Include("UserRoles").ToList();
        }
    }
}