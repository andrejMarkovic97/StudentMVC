using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _3_DataAccess
{
    public class StudentDBContext<T> : DbContext where T:Student
    {
        public StudentDBContext() : base("name = MVCStudent")
        {

        }
        public DbSet<T> Students {get; set;}
    }
}