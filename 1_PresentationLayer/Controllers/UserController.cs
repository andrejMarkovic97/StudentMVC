//using _2_BusinessLayer.GenericService;
//using _4_BusinessObjectModel.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace _1_PresentationLayer.Controllers
//{
//    [Authorize]
//    public class UserController : GenericController<User>
//    {
//        private readonly IGenericService<User> userService;
//        private readonly IGenericService<Role> roleCentralQuestionService;

//        public UserController(IGenericService<User> userService, IGenericService<Role> roleCentralQuestionService) : base(userService)
//        {
//            this.userService = userService;
//            this.roleCentralQuestionService = roleCentralQuestionService;
//        }

//        [Authorize(Roles = "Admin")]
//        public override ActionResult Create(User user)
//        {
//            user.UserID = Guid.NewGuid();
//            Role role = roleCentralQuestionService.GetAll().FirstOrDefault(r => r.RoleName == "User");
//            UserRole ur = new UserRole
//            {
//                UserID = user.UserID,
//                RoleID = role.RoleID
//            };
//            user.UserRoles.Add(ur);
//            userService.Add(user);
//            return View("AdminArea");
//        }

//        public ActionResult AdminArea()
//        {
//            var list = userService.GetAll();
//            return View(list);
//        }
//        [Authorize(Roles = "User")]
//        public ActionResult UserArea(User user)
//        {
//            return View(user);

//        }
//    }
//}