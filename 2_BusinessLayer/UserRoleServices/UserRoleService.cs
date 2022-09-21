using _2_BusinessLayer.GenericServices;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_BusinessLayer.UserRoleServices
{
    public class UserRoleService : GenericService<UserRole>
    {
        public UserRoleService(IGenericRepository<UserRole> genericRepository) : base(genericRepository)
        {
        }
    }
}