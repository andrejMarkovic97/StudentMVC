using _3_DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_BusinessLayer.GenericService
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IGenericRepository<T> genericRepository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public virtual void Add(T entity)
        {
            if (entity != null)
            {
                genericRepository.Add(entity);
            }
        }

        public virtual void Delete(Guid id)
        {
            genericRepository.Delete(id);
        }

        public virtual void Edit(T entity)
        {
            if (entity != null)
            {
                genericRepository.Edit(entity);
            }
        }

        public virtual T Get(Guid id)
        {
            return genericRepository.Get(id);
        }

        public virtual List<T> GetAll()
        {
            return genericRepository.GetAll();
        }

        public List<T> Search(string filter)
        {
            if (filter != null || filter.Length != 0)
            {
                filter = filter.ToLower();
                return genericRepository.Search(filter);

            }
            return null;
        }
    }
}