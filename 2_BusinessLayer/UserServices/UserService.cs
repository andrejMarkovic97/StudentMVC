using _2_BusinessLayer.GenericServices;
using _3_DataAccess.Repository;
using _3_DataAccess.UserRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_BusinessLayer.UserServices
{
    public class UserService : GenericService<User>
    {

        public UserService(IGenericRepository<User> userRepository) :base(userRepository)
        {

        }
  
    }
}