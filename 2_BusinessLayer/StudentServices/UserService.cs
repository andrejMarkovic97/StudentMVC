using _2_BusinessLayer.GenericService;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _2_BusinessLayer.StudentServices
{
    public class UserService<T> : GenericService<T>, IUserService<T> where T:User 
    {
        

        public UserService(IGenericRepository<T> genericRepository) : base(genericRepository)
        {
           
        }

        public virtual bool ExportData(T student)
        {
            try
            {
                if (student != null && student.FirstName != null && student.LastName != null
                    && student.FirstName.Length > 0 && student.LastName.Length > 0)
                {
                    var name = $"{student.FirstName}_{student.LastName}.txt";
                    var path = @"C:\Users\amar\Desktop\ExportedData\" + name;
                    string text = student.ToString();

                    File.WriteAllText(path, text);
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
                return false;
            }
           
        }

        public User GetUserByCredentials(string email, string password)
        {
            if (email != null && password != null && email.Length > 0 && password.Length > 0)
            {
                return genericRepository.GetUserByCredentials(email, password);
            }
            return null;
        }

        public virtual List<T> Search(string filter)
        {
            if(filter!=null || filter.Length!=0)
            {
                filter = filter.ToLower();
                return genericRepository.Search(filter);
               
            }
            return null;
            
        }

        



    }
}