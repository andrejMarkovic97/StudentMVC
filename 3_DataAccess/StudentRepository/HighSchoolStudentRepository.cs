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

        public override List<HighSchoolStudent> GetAll()
        {
            return db.HighschoolStudents.Include("UserRoles").ToList();

            
           
           
        }
    }
}