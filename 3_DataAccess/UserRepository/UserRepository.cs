
using _3_DataAccess.GenericRepository;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.UserRepository
{
    public class UserRepository : GenericRepository<User>,IGenericRepository<User>
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
        

        public override User GetUserByCredentials(string email, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                user.UserRoles = db.UserRoles.Include("Role").Where(ur => ur.UserID == user.UserID).ToList();
            }
            return user;
        }

        public override User GetUserByEmail(string email)
        {
            if(email!=null && email.Length > 0)
            {
                return db.Users.ToList().FirstOrDefault(u => u.Email == email);
            }
            return null;
        }
    }
        
}