using _2_BusinessLayer.GenericServices;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _2_BusinessLayer.StudentServices
{
    public class UserService<T> : GenericService<T>, IStudentService<T> where T:User 
    {
        public UserService(IGenericRepository<T> genericRepository) : base(genericRepository)
        {
        }

        public virtual void ExportData(T student)
        {
            var name = $"{student.FirstName}_{student.LastName}.txt";
            var path = @"C:\Users\amar\Desktop\ExportedData\" + name;
            string text = student.ToString();

            File.WriteAllText(path, text);
        }

        public virtual List<T> Search(string filter)
        {
            return null;
        }
       

    }
}