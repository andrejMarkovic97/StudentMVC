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
  

        public HighSchoolStudentRepository(StudentDBContext db) :base(db)
        {
            
        }

     
    }
}