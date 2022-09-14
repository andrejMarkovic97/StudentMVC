using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _2_BusinessLayer.StudentServices
{
    public class StudentService<T> : IStudentService<T> where T : Student
    {
        private readonly IStudentRepository<T> studentRepository;

        public StudentService(IStudentRepository<T> studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public virtual void Add(T student)
        {
            if (student != null)
            {
                studentRepository.Add(student);
            }
        }

        public virtual void Delete(Guid id)
        {
            studentRepository.Delete(id);
        }

        public virtual void Edit(T student)
        {
            if (student != null)
            {
                studentRepository.Edit(student);
            }
        }


        public virtual T Get(Guid id)
        {
            var student = studentRepository.Get(id);
            return student;
        }

        public virtual List<T> GetAll()
        {
            var list = studentRepository.GetAll();
            return list;
        }

        public virtual List<T> Search(string filter)
        {
            return null;
        }


        public virtual void ExportData(T student)
        {
            var name = $"{student.FirstName}_{student.LastName}.txt";
            var path = @"C:\Users\amar\Desktop\ExportedData\" + name;
            string text = student.ToString();

            File.WriteAllText(path, text);
        }

    }
}