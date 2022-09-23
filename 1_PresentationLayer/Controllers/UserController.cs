using _2_BusinessLayer.GenericServices;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_PresentationLayer.Controllers
{
    public class UserController : GenericController<User>
    {
        private readonly IGenericService<User> centralQuestionService;
        private readonly IGenericService<Role> roleCentralQuestionService;

        public UserController(IGenericService<User> centralQuestionService, IGenericService<Role> roleCentralQuestionService) : base(centralQuestionService)
        {
            this.centralQuestionService = centralQuestionService;
            this.roleCentralQuestionService = roleCentralQuestionService;
        }

        public override ActionResult Create(User user)
        {
            user.UserID = Guid.NewGuid();
            Role role = roleCentralQuestionService.GetAll().FirstOrDefault(r => r.RoleName == "User");
            UserRole ur = new UserRole
            {
                UserID = user.UserID,
                RoleID = role.RoleID
            };
            user.UserRoles.Add(ur);
            centralQuestionService.Add(user);
            return View("AdminArea");
        }

        public ActionResult AdminArea()
        {
            var list = centralQuestionService.GetAll();
            return View(list);
        }

        public ActionResult UserArea(User user)
        {
            return View(user);
        }
    }
}