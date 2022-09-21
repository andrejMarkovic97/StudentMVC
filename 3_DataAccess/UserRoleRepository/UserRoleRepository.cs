using _3_DataAccess.GenericRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.UserRoleRepository
{
    public class UserRoleRepository : GenericRepository<UserRole>
    {
        public UserRoleRepository(StudentDBContext db) : base(db)
        {
        }
    }
}