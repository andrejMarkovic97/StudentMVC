using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_BusinessLayer.StudentServices
{
    public interface IStudentService<T> where T:Student
    {
        void Add(T student);
        List<T> GetAll();
        T Get(Guid id);
        void Edit(T student);
        void Delete(Guid id);

        List<T> Search(string filter);

        void ExportData(T student);

    }
}