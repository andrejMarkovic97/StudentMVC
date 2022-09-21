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

        public override List<HighSchoolStudent> GetAll()
        {
           return db.HighschoolStudents.ToList();

            //var userRoleList = db.UserRoles.Include("User").Include("Role").ToList();
            //List<HighSchoolStudent> highSchoolers = new List<HighSchoolStudent>();
            //foreach (var userRole in userRoleList)
            //{
            //    if (userRole.Role.RoleName == "HighSchoolStudent")
            //    {
            //        highSchoolers.Add((HighSchoolStudent)userRole.User);
            //    }
            //}
            //return highSchoolers;

           
           
        }
    }
}