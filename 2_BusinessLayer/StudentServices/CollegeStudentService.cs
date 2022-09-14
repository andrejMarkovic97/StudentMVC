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
    public class CollegeStudentService : StudentService<CollegeStudent>, IStudentService<CollegeStudent>
    {
    
        private readonly IStudentRepository<CollegeStudent> studentRepository;

        public CollegeStudentService(IStudentRepository<CollegeStudent> studentRepository) :base(studentRepository)
        {
            this.studentRepository = studentRepository;
        }

    

        public override List<CollegeStudent> GetAll()
        {
            return studentRepository.GetAll().FindAll(x => x.Discriminator == Discriminator.CollegeStudent);
        }

        public override List<CollegeStudent> Search(string filter)
        {
            filter = filter.ToLower();
            var list = GetAll();
            return list.FindAll(x => x.FirstName.ToLower() == filter || x.LastName.ToLower() == filter || x.BirthDate.ToString() == filter ||
            x.Email.ToLower() == filter || x.PhoneNumber == filter || x.Adress.ToLower() == filter || x.InstitutionName.ToLower() == filter || x.Generation.ToString() == filter);

        }

    }
}