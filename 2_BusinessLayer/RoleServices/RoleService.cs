using _2_BusinessLayer.GenericServices;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_BusinessLayer.RoleServices
{
    public class RoleService : GenericService<Role>
    {
        public RoleService(IGenericRepository<Role> roleRepository) : base(roleRepository)
        {
        }
    }
}