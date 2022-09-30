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

        public override void Delete(Guid id)
        {
            var role = db.Roles.FirstOrDefault(r => r.RoleID == id);
            if (role != null) {
            var userRoles = db.UserRoles.ToList().Where(ur => ur.RoleID == id);
            db.UserRoles.RemoveRange(userRoles);
            db.Roles.Remove(role);
            db.SaveChanges();
            }
        }
    }
}