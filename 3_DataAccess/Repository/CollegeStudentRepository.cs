using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.Repository
{
    public class CollegeStudentRepository : StudentRepository<CollegeStudent>, IStudentRepository<CollegeStudent>
    {

        public CollegeStudentRepository(StudentDBContext<CollegeStudent> db):base(db)
        {
           
        }

        
    }
}