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
    public class ProfessorController : GenericController<Professor>
    {
        private readonly IGenericService<Professor> professorService;
        private readonly IGenericService<Role> roleService;

        public ProfessorController(IGenericService<Professor> professorService,IGenericService<Role> roleService) : base(professorService)
        {
            this.professorService = professorService;
            this.roleService = roleService;
        }

        [Authorize(Roles="Admin")]
        public override ActionResult Create(Professor p)
        {
           
                p.UserID = Guid.NewGuid();
                p.UserRoles = new List<UserRole>();
                UserRole roleUser = new UserRole
                {
                    UserID = p.UserID,
                    RoleID = roleService.GetAll().FirstOrDefault(r => r.RoleName == "User").RoleID

                };
                UserRole roleProfessor = new UserRole
                {
                    UserID = p.UserID,
                    RoleID = roleService.GetAll().FirstOrDefault(r => r.RoleName == "Professor").RoleID

                };
                p.UserRoles.Add(roleUser);
                p.UserRoles.Add(roleProfessor);
              
                p.Password = System.Web.Security.Membership.GeneratePassword(8, 1);
                professorService.Add(p);

                return RedirectToAction("Index");
           
        }
    }
}