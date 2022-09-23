using _3_DataAccess.GenericRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.StudentRepository
{
    public class ProfessorRepository : GenericRepository<Professor>
    {
        public ProfessorRepository(UserDBContext db) :base(db)
        {

        }

        public override List<Professor> GetAll()
        {
            return db.Professors.Include("UserRoles").ToList();
        }
    }
}