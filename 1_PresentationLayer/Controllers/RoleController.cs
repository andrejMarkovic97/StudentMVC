using _1_PresentationLayer.ApplicationService.GenericAppService;
using _1_PresentationLayer.ViewModels;
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
    public class RoleController :GenericAppController<RoleViewModel,Role>
    {
        private readonly IGenericAppService<RoleViewModel, Role> roleService;

        public RoleController(IGenericAppService<RoleViewModel,Role> roleService) :base(roleService)
        {
            this.roleService = roleService;
        }

        public override ActionResult Details(Guid id)
        {
            RoleViewModel role = roleService.Get(id);
            role.IsReadOnly = true;
            role.IsDisabled = true;
            role.Title = "Details";
            return View(role);
            
        }

        public override ActionResult Edit(Guid id)
        {
            RoleViewModel role = roleService.Get(id);
            if (role != null)
            {
                role.IsReadOnly = false;
                role.IsDisabled = false;

                return View("Details", role);
            }
            return new HttpNotFoundResult();
        }
    }
}
