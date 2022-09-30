using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace _3_DataAccess.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly UserDBContext db;
        private readonly DbSet<T> dbSet;

        public GenericRepository(UserDBContext db)
        {
            this.db = db;
            this.dbSet = db.Set<T>();
            
        }
        public virtual void Add(T entity)
        {
          
                dbSet.Add(entity);
                db.SaveChanges();
           
        }

        public virtual void Delete(Guid id)
        {
            T entityToDelete = dbSet.Find(id);
            if (entityToDelete != null)
            {
                dbSet.Remove(entityToDelete);
                db.SaveChanges();
            }
        }

        public virtual void Edit(T entity)
        {
            dbSet.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public virtual T Get(Guid id)
        {
            return dbSet.Find(id);
        }

        public virtual List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual T GetUserByCredentials(string email, string password)
        {
            return null;
        }
    }
}