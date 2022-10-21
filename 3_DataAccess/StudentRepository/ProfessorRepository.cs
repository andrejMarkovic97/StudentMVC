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
            var professor = db.Professors.Find(id);
            db.Users.Remove(professor);
            db.SaveChanges();
        }

        public override Professor Get(Guid id)
        {
            var user = db.Professors.AsNoTracking().FirstOrDefault(s => s.UserID == id);
            if (user != null)
            {
                user.UserRoles = db.UserRoles.Include("Role").Where(ur => ur.UserID == id).ToList();
            }
            return user;
        }

        public override List<Professor> GetAll()
        {
            return db.Professors.Include("UserRoles").ToList();
        }

        public override Professor GetUserByEmail(string email)
        {
            var user = db.Professors.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                user.UserRoles = db.UserRoles.Include("Role").Where(ur => ur.UserID == user.UserID).ToList();
            }
            return user;
        }

        public override List<Professor> Search(string filter)
        {
            return db.Professors.ToList().FindAll(x => x.FirstName.ToLower().Contains(filter) || x.LastName.ToLower().Contains(filter) || x.BirthDate.ToString().Contains(filter) ||
           x.Email.ToLower().Contains(filter) || x.PhoneNumber.Contains(filter) || x.Adress.ToLower().Contains(filter) || x.Subject.ToLower().Contains(filter) || x.Cabinet.ToString().Contains(filter));
        }
    }
}