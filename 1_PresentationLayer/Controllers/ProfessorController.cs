using _1_PresentationLayer.ApplicationService.GenericAppService;
using _1_PresentationLayer.ApplicationService.UserAppService;
using _1_PresentationLayer.ViewModels;
using _2_BusinessLayer.GenericService;
using _2_BusinessLayer.RoleServices;
using _3_DataAccess.QueryModels;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_PresentationLayer.Controllers
{
    [Authorize]
    public class ProfessorController : UserAppController<ProfessorViewModel, Professor>
    {
        private readonly IUserAppService<ProfessorViewModel, Professor> professorAppService;
        private readonly RoleService roleService;
        private readonly IGenericAppService<ProfessorViewModel, ProfessorQueryModel> genericQMService;

        public ProfessorController(IUserAppService<ProfessorViewModel, Professor> professorAppService,RoleService roleService, 
            IGenericAppService<ProfessorViewModel, ProfessorQueryModel> genericQMService) : base(professorAppService)
        {
            this.professorAppService = professorAppService;
            this.roleService = roleService;
            this.genericQMService = genericQMService;
        }


        [Authorize(Roles = "Admin")]
        public override ActionResult Create(ProfessorViewModel professor)
        {

            professor.UserID = Guid.NewGuid();
            professor.UserRoles = new List<UserRole>();
            UserRole roleUser = new UserRole
            {
                UserID = professor.UserID,
                RoleID = roleService.GetAll().FirstOrDefault(r => r.RoleName == "User").RoleID

            };
            UserRole roleProfessor = new UserRole
            {
                UserID = professor.UserID,
                RoleID = roleService.GetAll().FirstOrDefault(r => r.RoleName == "Professor").RoleID

            };
            professor.UserRoles.Add(roleUser);
            professor.UserRoles.Add(roleProfessor);

            professor.Password = System.Web.Security.Membership.GeneratePassword(8, 1);
            professorAppService.Add(professor);

            return RedirectToAction("Index");

        }

        public override ActionResult Index()
        {
            var list = genericQMService.GetAll();
            return View(list);
        }
    }
}