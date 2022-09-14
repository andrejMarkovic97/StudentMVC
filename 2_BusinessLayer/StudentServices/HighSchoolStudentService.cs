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
    public class HighSchoolStudentService : StudentService<HighSchoolStudent>,IStudentService<HighSchoolStudent>
    {
        private readonly IStudentRepository<HighSchoolStudent> studentRepository;

        public HighSchoolStudentService(IStudentRepository<HighSchoolStudent> studentRepository) : base(studentRepository)
        {
            this.studentRepository = studentRepository;
        }


        public override List<HighSchoolStudent> GetAll()
        {
            return studentRepository.GetAll().FindAll(x => x.Discriminator == Discriminator.HighSchoolStudent);
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