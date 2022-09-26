
using _3_DataAccess.GenericRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.UserRepository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(UserDBContext db) : base(db)
        {

        }

        public override List<User> GetAll()
        {

            List<User> users = db.Users.ToList();

            foreach (var user in users)
            {
                user.UserRoles = db.UserRoles.Include("Role").Where(ur => ur.UserID == user.UserID).ToList();
            }
            return users;
            
            

        }

    }
        
}