using _1_PresentationLayer.ApplicationService.GenericAppService;
using _1_PresentationLayer.ApplicationService.UserAppService;
using _1_PresentationLayer.ViewModels;
using _1_PresentationLayer.ViewModels.QueryViewModels;
using _2_BusinessLayer.GenericService;
using _2_BusinessLayer.RoleServices;
using _2_BusinessLayer.StudentServices;
using _3_DataAccess.QueryModels;
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
        private readonly IGenericAppService<CollegeStudentQueryViewModel, CollegeStudentQueryModel> genericQMService;

        public CollegeStudentController(IUserAppService<CollegeStudentViewModel, CollegeStudent> studentAppService, 
            RoleService roleService, IGenericAppService<CollegeStudentQueryViewModel, CollegeStudentQueryModel> genericQMService,
            IGenericService<ActionLogger> actionLoggerService, IUserAppService<UserViewModel, User> actionLoggerUserAppService) :
            base(studentAppService,actionLoggerService,actionLoggerUserAppService)
        {
            this.studentAppService = studentAppService;
            this.roleService = roleService;
            this.genericQMService = genericQMService;
        }

        [Authorize(Roles = "Professor")]
        public override ActionResult Create(CollegeStudentViewModel cs)
        {
            if (ModelState.IsValid)
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
            AddActionLog(System.Reflection.MethodBase.GetCurrentMethod().Name, cs.UserID);

            return RedirectToAction("Index");
            }
            return RedirectToAction("Create");

        }
        [Authorize(Roles = "Professor,CollegeStudent")]
        public override ActionResult Details(Guid id)
        {
            return base.Details(id);
        }
        [Authorize(Roles = "Professor,CollegeStudent")]
        public override ActionResult Edit(Guid id)
        {
            return base.Edit(id);
        }

        [Authorize(Roles = "Professor,Admin")]
        public override ActionResult Index()
        {

            var list = genericQMService.GetAll();
            return View(list);
        }
        [Authorize(Roles = "Professor,Admin")]
        public override ActionResult Index(string filter)
        {
            if (filter == null || filter == "")
            {
                var list = genericQMService.GetAll();

                return View(list);
            }
            else
            {
                List<CollegeStudentQueryViewModel> list = genericQMService.Search(filter);
                if (list == null || list.Count == 0)
                {
                    TempData["ErrorSearch"] = " No results found";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(list);
                }
            }
        }



      

    }
}
