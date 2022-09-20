using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DataAccess.Repository
{
   public interface IGenericRepository<T> where T:class
    {

        void Add(T entity);
        List<T> GetAll();
        T Get(Guid id);
        void Edit(T entity);
        void Delete(Guid id);
    }
}
