
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
        public UserRepository(StudentDBContext db) : base(db)
        {

        }

        public override List<User> GetAll()
        {
            //var userRoles = db.UserRoles.Include("Role").Include("User").ToList();
            //List<User> users = db.Users.ToList();
            //foreach (var user in users)
            //{
            //    foreach (var ur in userRoles)
            //    {
            //        if (ur.UserID == user.UserID)
            //        {
            //            user.UserRoles.Add(ur);
            //        }
            //    }
            //}
            //return users;
           return db.Users.Include("UserRoles").ToList();
        }
        
    }
}