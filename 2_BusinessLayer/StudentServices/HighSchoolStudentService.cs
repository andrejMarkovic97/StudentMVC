using _3_DataAccess.Repository;
using _4_BusinessObjectModel;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _2_BusinessLayer.StudentServices
{
    public class HighSchoolStudentService : StudentService<HighSchoolStudent>
    {
        private readonly IGenericRepository<HighSchoolStudent> studentRepository;

        public HighSchoolStudentService(IGenericRepository<HighSchoolStudent> studentRepository) : base(studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public override List<HighSchoolStudent> GetAll()
        {
            return studentRepository.GetAll();
            //List<HighSchoolStudent> highschoolers = new List<HighSchoolStudent>();
            //foreach (var student in students)
            //{
            //    if (student.User != null && student.User.UserRoles != null)
            //    {
            //        List<UserRole> userRoles = student.User.UserRoles;
            //        foreach (UserRole ur in userRoles)
            //        {
            //            if (ur.Role.RoleName == "HighSchoolStudent")
            //            {
            //                highschoolers.Add(student);
            //            }
            //        }
            //    }
            //}
            //return highschoolers;
        }

        public override List<HighSchoolStudent> Search(string filter)
        {
            filter = filter.ToLower();
            var list = GetAll();
            return list.FindAll(x => x.FirstName.ToLower() == filter || x.LastName.ToLower() == filter || x.BirthDate.ToString() == filter ||
            x.Email.ToLower() == filter || x.PhoneNumber == filter || x.Adress.ToLower() == filter || x.SchoolName.ToLower() == filter || x.EnrollmentDate.ToString() == filter);

           
            
        }
    }
    }