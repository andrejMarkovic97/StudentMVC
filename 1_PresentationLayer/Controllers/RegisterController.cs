using _2_BusinessLayer.GenericService;
using _2_BusinessLayer.StudentServices;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IGenericService<User> userCentralQuestionService;
        private readonly IGenericService<Role> roleCentralQuestionService;
        

        public RegisterController(IGenericService<User> userCentralQuestionService, IGenericService<Role> roleCentralQuestionService)
        {
            this.userCentralQuestionService = userCentralQuestionService;
            this.roleCentralQuestionService = roleCentralQuestionService;
            
        }

        // GET: Register
        public ActionResult Register()
        {
            ViewBag.RoleList = roleCentralQuestionService.GetAll();

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.UserID = Guid.NewGuid();
            Role role = roleCentralQuestionService.GetAll().First();
            UserRole ur = new UserRole();
            ur.User = user;
            ur.UserID = user.UserID;
            ur.Role = role;
            ur.RoleID = role.RoleID;
            userCentralQuestionService.Add(user);
            return RedirectToAction("Index","Home");
        }
    }
}