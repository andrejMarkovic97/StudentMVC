using _2_BusinessLayer.GenericServices;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_PresentationLayer.Controllers
{
    [Authorize]
    public class RoleController : GenericController<Role>
    {
        public RoleController(IGenericService<Role> roleService) : base(roleService)
        {
        }
    }
}
