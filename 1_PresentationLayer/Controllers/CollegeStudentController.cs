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
    public class CollegeStudentController : StudentController<CollegeStudent>
    {
        private readonly IUserService<CollegeStudent> collegeStudentService;
        private readonly IGenericService<Role> roleService;

        public CollegeStudentController(IUserService<CollegeStudent> collegeStudentService, IGenericService<Role> roleService) : base(collegeStudentService)
        {
            this.collegeStudentService = collegeStudentService;
            this.roleService = roleService;
        }

        [Authorize(Roles = "Professor")]
        public override ActionResult Create(CollegeStudent cs)
        {
           
            cs.UserID = Guid.NewGuid();
            cs.UserRoles = new List<UserRole>();
            UserRole roleUser = new UserRole
            {
                UserID = cs.UserID,
                RoleID = roleService.GetAll().FirstOrDefault(r => r.RoleName == "User").RoleID
            };

            UserRole roleCS = new UserRole
                {
                    UserID = cs.UserID,
                    RoleID = roleService.GetAll().FirstOrDefault(r => r.RoleName == "CollegeStudent").RoleID

                };
                cs.UserRoles.Add(roleUser);
                cs.UserRoles.Add(roleCS);
               
                cs.Password= System.Web.Security.Membership.GeneratePassword(8, 1);
                collegeStudentService.Add(cs);
                
                return RedirectToAction("Index");
            
          
        }

        public override ActionResult Edit(CollegeStudent cs)
        {
            if (ModelState.IsValid)
            {
                
                collegeStudentService.Edit(cs);
                return RedirectToAction("Index");
            }
            return View("Details", cs);
        }

    }
}
