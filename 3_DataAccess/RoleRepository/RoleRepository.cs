using _3_DataAccess.GenericRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.RoleRepository
{
    public class RoleRepository : GenericRepository<Role>
    {
        public RoleRepository(UserDBContext db) : base(db)
        {
        }
    }
}