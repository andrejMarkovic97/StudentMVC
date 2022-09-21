using _2_BusinessLayer.GenericServices;
using _2_BusinessLayer.StudentServices;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _1_PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IStudentService<User> centralQuestionService;

        public LoginController(IStudentService<User> centralQuestionService) 
        {
            this.centralQuestionService = centralQuestionService;
        }
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var existingUser = centralQuestionService.GetAll().FirstOrDefault(s=>s.Email==user.Email && s.Password==user.Password);
            if (existingUser != null)
            {
                var Ticket = new FormsAuthenticationTicket(user.Email, true, 3000);
                string Encrypt = FormsAuthentication.Encrypt(Ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt);
                cookie.Expires = DateTime.Now.AddHours(3000);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                //if (existingUser.Roles != null && existingUser.Roles.FirstOrDefault(ur => ur.Role.RoleName == "Admin") != null)
                //{
                //    return RedirectToAction("AdminArea", "Home", existingUser);

                //}
                //else
                //{
                //    return RedirectToAction("UserArea", "Home", existingUser);
                //}
                return RedirectToAction("UserArea", "Home", existingUser);
            }
            TempData["LoginMessage"] = $"Invalid credentials";
            return View("Login");


        }



    }
}
