using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_BusinessLayer.GenericService
{
    public interface IGenericService<T> where T: class
    {
        void Add(T entity);
        List<T> GetAll();
        List<T> Search(string filter);
        T Get(Guid id);
        void Edit(T entity);
        void Delete(Guid id);

        

        
    }
}