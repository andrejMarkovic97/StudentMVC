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
    public class UserService : GenericService<User>, IStudentService<User> 
    {
        public UserService(IGenericRepository<User> genericRepository) : base(genericRepository)
        {
        }

        public virtual void ExportData(User student)
        {
            var name = $"{student.FirstName}_{student.LastName}.txt";
            var path = @"C:\Users\amar\Desktop\ExportedData\" + name;
            string text = student.ToString();

            File.WriteAllText(path, text);
        }

        public List<User> Search(string filter)
        {
            return null;
        }
       

    }
}