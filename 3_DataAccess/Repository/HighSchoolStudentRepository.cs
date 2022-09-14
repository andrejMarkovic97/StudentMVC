using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.Repository
{
    public class HighSchoolStudentRepository : StudentRepository<HighSchoolStudent>,IStudentRepository<HighSchoolStudent>
    {
  

        public HighSchoolStudentRepository(StudentDBContext<HighSchoolStudent> db) :base(db)
        {
            
        }

     
    }
}