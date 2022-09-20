using _3_DataAccess.GenericRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace _3_DataAccess.Repository
{
    public class StudentRepository : GenericRepository<Student>
    {
        public StudentRepository(StudentDBContext db):base(db)
        {

        }
        //    private readonly StudentDBContext db;

        //    public StudentRepository(StudentDBContext db)
        //    {
        //        this.db = db;

        //    }

        //    public virtual List<Student> GetAll()
        //    {

        //        return db.Students.ToList();


        //    }



        //    public virtual Student Get(Guid id)
        //    {
        //       return GetAll().FirstOrDefault(s => s.ID == id);


        //    }


        //    public virtual void Add(Student student)
        //    {
        //        db.Students.Add(student);
        //        db.SaveChanges();
        //    }

        //    public virtual void Delete(Guid id)
        //    {
        //        var student = db.Students.FirstOrDefault(s => s.ID == id);
        //        db.Students.Remove(student);
        //        db.SaveChanges();
        //    }

        //    public virtual void Edit(Student student)
        //    {
        //        var entry = db.Entry(student);
        //        entry.State = EntityState.Modified;

        //            db.SaveChanges();

        //    }

        //}
    }
}