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
        private readonly IUserService<User> userService;

        public LoginController(IUserService<User> userService) 
        {
            this.userService = userService;
        }
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var existingUser = userService.GetUserByCredentials(user.Email, user.Password);
            if (existingUser != null)
            {
                var Ticket = new FormsAuthenticationTicket(user.Email, true, 3000);
                string Encrypt = FormsAuthentication.Encrypt(Ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt)
                {
                    Expires = DateTime.Now.AddHours(3000),
                    HttpOnly = true
                };
                Response.Cookies.Add(cookie);
                if (existingUser.UserRoles.FirstOrDefault(ur => ur.Role.RoleName == "Admin") != null)
                {
                    
                    return RedirectToAction("AdminArea", "User");
                }
                return RedirectToAction("UserArea", "User",existingUser);
            }
            TempData["LoginMessage"] = $"Invalid credentials";
            return View("Login");

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
