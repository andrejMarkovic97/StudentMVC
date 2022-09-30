using _1_PresentationLayer.ApplicationService.UserAppService;
using _1_PresentationLayer.ViewModels;
using _2_BusinessLayer.GenericServices;
using _2_BusinessLayer.RoleServices;
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
    public class CollegeStudentController : UserAppController<CollegeStudentViewModel,CollegeStudent>
    {
        private readonly IUserAppService<CollegeStudentViewModel, CollegeStudent> studentAppService;
        private readonly RoleService roleService;

        public CollegeStudentController(IUserAppService<CollegeStudentViewModel, CollegeStudent> studentAppService,  RoleService roleService) : base(studentAppService)
        {
            this.studentAppService = studentAppService;
            this.roleService = roleService;
        }

        [Authorize(Roles = "Professor")]
        public override ActionResult Create(CollegeStudentViewModel cs)
        {
            cs.Title = "Create";
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

            cs.Password = System.Web.Security.Membership.GeneratePassword(8, 1);
            studentAppService.Add(cs);

            return RedirectToAction("Index");


        }

        public override ActionResult Create()
        {
            
            return base.Create();
        }

        public override ActionResult Details(Guid id)
        {
            return base.Details(id);
        }

        public override ActionResult Index()
        {
            return base.Index();
        }
    }
}
