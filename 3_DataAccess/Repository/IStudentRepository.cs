using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DataAccess.Repository
{
   public interface IStudentRepository<T> where T:Student
    {

        void Add(T student);
        List<T> GetAll();
        T Get(Guid id);
        void Edit(T student);
        void Delete(Guid id);
    }
}
