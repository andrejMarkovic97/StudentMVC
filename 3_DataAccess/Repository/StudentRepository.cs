using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace _3_DataAccess.Repository
{
    public class StudentRepository<T> : IStudentRepository<T> where T: Student
    {
        private readonly StudentDBContext<T> db;

        public StudentRepository(StudentDBContext<T> db)
        {
            this.db = db;
           
        }

        public virtual List<T> GetAll()
        {
            using (db)
            {
                var students = db.Students.ToList();
                return students;


            }
        }



        public virtual T Get(Guid id)
        {
            var student = db.Students.FirstOrDefault(s => s.ID == id);
            
            return student;
        }

        
        public virtual void Add(T student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public virtual void Delete(Guid id)
        {
            var student = db.Students.FirstOrDefault(s => s.ID == id);
            db.Students.Remove(student);
            db.SaveChanges();
        }

        public virtual void Edit(T student)
        {
            var entry = db.Entry(student);
            entry.State = EntityState.Modified;
          
                db.SaveChanges();
            
            //catch(DbEntityValidationException e)
            //{
            //    Console.WriteLine(e);
            //}
            
        }

       
    }
}