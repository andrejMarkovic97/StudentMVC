using _2_BusinessLayer.GenericServices;
using _2_BusinessLayer.StudentServices;
using _4_BusinessObjectModel;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_PresentationLayer.Controllers
{
    [Authorize]
    public class HighSchoolStudentController : StudentController<HighSchoolStudent>
    {
        private readonly IUserService<HighSchoolStudent> highSchoolStudentService;
        private readonly IGenericService<Role> roleService;

        public HighSchoolStudentController(IUserService<HighSchoolStudent> highSchoolStudentService, IGenericService<Role> roleService) : base(highSchoolStudentService)
        {
            this.highSchoolStudentService = highSchoolStudentService;
            this.roleService = roleService;
        }
        [Authorize(Roles = "Professor")]
        public override ActionResult Create(HighSchoolStudent hs)
        {
            try
            {
                hs.UserID = Guid.NewGuid();
                hs.UserRoles = new List<UserRole>();
                UserRole roleUser = new UserRole
                
                {
                    UserID = hs.UserID,
                    RoleID = roleService.GetAll().FirstOrDefault(r => r.RoleName == "User").RoleID

                };
                UserRole roleHS = new UserRole
                {
                    UserID = hs.UserID,
                    RoleID = roleService.GetAll().FirstOrDefault(r => r.RoleName == "HighSchoolStudent").RoleID

                };
                hs.UserRoles.Add(roleUser);
                hs.UserRoles.Add(roleHS);
               
                hs.Password = System.Web.Security.Membership.GeneratePassword(8, 1);
                highSchoolStudentService.Add(hs);
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        public override ActionResult Edit(HighSchoolStudent hs)
        {
            if (ModelState.IsValid)
            {
                
                highSchoolStudentService.Edit(hs);
                return RedirectToAction("Index");
            }
            return View("Details", hs);

        }


    }
}
