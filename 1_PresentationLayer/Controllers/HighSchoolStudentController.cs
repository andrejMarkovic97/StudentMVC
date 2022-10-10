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
    public class HighSchoolStudentController : UserAppController<HighSchoolStudentViewModel,HighSchoolStudent>
    {
        private readonly IUserAppService<HighSchoolStudentViewModel, HighSchoolStudent> studentService;
        
        private readonly RoleService roleService;
        private readonly IGenericAppService<HighSchoolStudentQueryViewModel, HighSchoolStudentQueryModel> genericQMService;

        public HighSchoolStudentController
            (IUserAppService<HighSchoolStudentViewModel, HighSchoolStudent> studentService,
            RoleService roleService,IGenericAppService<HighSchoolStudentQueryViewModel,HighSchoolStudentQueryModel> genericQMService)
            :base(studentService)
        {
            this.studentService = studentService;
            this.roleService = roleService;
            this.genericQMService = genericQMService;
        }

        
        [Authorize(Roles = "Professor")]
        public override ActionResult Create(HighSchoolStudentViewModel hs)
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
                studentService.Add(hs);

                return RedirectToAction("Index");
            
        }

        public override ActionResult Index()
        {
            var list = genericQMService.GetAll();
            return View(list);
        }

        public override ActionResult Index(string filter)
        {
            if (filter == null || filter == "")
            {
                var list = genericQMService.GetAll();

                return View(list);
            }
            else
            {
                List<HighSchoolStudentQueryViewModel> list = genericQMService.Search(filter);
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
