using _2_BusinessLayer.GenericServices;
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
    public class HighSchoolStudentService : GenericService<HighSchoolStudent>, IStudentService<HighSchoolStudent>
    {

        public HighSchoolStudentService(IGenericRepository<HighSchoolStudent> genericRepository) : base(genericRepository)
        {
        }


        public List<HighSchoolStudent> Search(string filter)
        {
            filter = filter.ToLower();
            var list = GetAll();
            return list.FindAll(x => x.FirstName.ToLower() == filter || x.LastName.ToLower() == filter || x.BirthDate.ToString() == filter ||
            x.Email.ToLower() == filter || x.PhoneNumber == filter || x.Adress.ToLower() == filter || x.SchoolName.ToLower() == filter || x.EnrollmentDate.ToString() == filter);



        }
     
        public void ExportData(HighSchoolStudent student)
        {
            var name = $"{student.FirstName}_{student.LastName}.txt";
            var path = @"C:\Users\amar\Desktop\ExportedData\" + name;
            string text = student.ToString();

            File.WriteAllText(path, text);
        }

      
    }
}