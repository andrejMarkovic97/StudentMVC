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
    public class CollegeStudentService : GenericService<CollegeStudent>,IStudentService<CollegeStudent>
    {
        public CollegeStudentService(IGenericRepository<CollegeStudent> genericRepository) : base(genericRepository)
        {
        }

        public void ExportData(CollegeStudent student)
        {
            var name = $"{student.FirstName}_{student.LastName}.txt";
            var path = @"C:\Users\amar\Desktop\ExportedData\" + name;
            string text = student.ToString();

            File.WriteAllText(path, text);
        }

        public  List<CollegeStudent> Search(string filter)
        {
            filter = filter.ToLower();
            var list = GetAll();
            return list.FindAll(x => x.FirstName.ToLower() == filter || x.LastName.ToLower() == filter || x.BirthDate.ToString() == filter ||
            x.Email.ToLower() == filter || x.PhoneNumber == filter || x.Adress.ToLower() == filter || x.InstitutionName.ToLower() == filter || x.Generation.ToString() == filter);

        }

    }
}