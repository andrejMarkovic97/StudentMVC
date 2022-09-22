
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
            //return db.Users.Include("UserRoles").ToList();
            return db.Users.Include("UserRoles").ToList();
            //foreach (var user in users)
            //{
            //    List<UserRole> UserRoles = (from UserRole ur in db.UserRoles
            //                                join User u in db.Users on ur.UserID equals u.UserID
            //                                join Role r in db.Roles on ur.RoleID equals r.RoleID
            //                                where ur.UserID == user.UserID
            //                                select new UserRole()
            //                                {
            //                                    UserID = ur.UserID,
            //                                    RoleID = ur.RoleID


            //                                }).ToList();

            //    user.UserRoles = UserRoles;

            //}

        }

    }
        
}