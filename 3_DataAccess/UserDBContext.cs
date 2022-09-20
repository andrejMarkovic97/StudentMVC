using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _3_DataAccess
{
    public class UserDBContext : DbContext
    {
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}