using _3_DataAccess.GenericRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.Repository
{
    public class CollegeStudentRepository : GenericRepository<CollegeStudent>
    {

        public CollegeStudentRepository(StudentDBContext db):base(db)
        {
           
        }

        //public override List<CollegeStudent> GetAll()
        //{
        //    return db.Users.Include("User").Include("Role");
        //}
    }
}