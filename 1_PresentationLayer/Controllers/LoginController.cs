using _1_PresentationLayer.ApplicationService.UserAppService;
using _1_PresentationLayer.ViewModels;
using _2_BusinessLayer.GenericService;
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
        private readonly IUserAppService<UserViewModel, User> userAppService;
        private readonly IGenericService<Login> loginLoggerService;

        public LoginController(IUserAppService<UserViewModel,User> userAppService, IGenericService<Login> loginLoggerService)
        {
            this.userAppService = userAppService;
            this.loginLoggerService = loginLoggerService;
        }
        public ActionResult Login()
        {
            if (User.Identity != null)
            {
                FormsAuthentication.SignOut();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel user)
        {
            if (user != null && user.Email != null && user.Password != null)
            {
                var existingUser = userAppService.GetUserByCredentials(user.Email, user.Password);
                
                if (existingUser != null)
                {
                    AddLoginCookie(user.Email);

                    AddLogin(existingUser.UserID, existingUser.Email, existingUser.Password);
                  
                    if (existingUser.UserRoles.FirstOrDefault(ur => ur.Role.RoleName == "Admin") != null)
                    {

                        return RedirectToAction("AdminArea", "Home");
                    }

                    if (existingUser.UserRoles.FirstOrDefault(ur => ur.Role.RoleName == "CollegeStudent") != null)
                    {
                        return RedirectToAction("UserProfile", "CollegeStudent");
                    }

                    if (existingUser.UserRoles.FirstOrDefault(ur => ur.Role.RoleName == "HighSchoolStudent") != null)
                    {
                        return RedirectToAction("UserProfile", "HighSchoolStudent");
                    }
                   
                    if (existingUser.UserRoles.FirstOrDefault(ur=>ur.Role.RoleName=="Professor")!=null)
                    {
                        return RedirectToAction("UserProfile", "Professor");
                    }
                }

                TempData["LoginMessage"] = "Invalid credentials";
                
            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


        private void AddLoginCookie(string email)
        {
            var Ticket = new FormsAuthenticationTicket(email, true, 3000);
            string Encrypt = FormsAuthentication.Encrypt(Ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt)
            {
                Expires = DateTime.Now.AddHours(3000),
                HttpOnly = true
            };
            Response.Cookies.Add(cookie);
        }

        private void AddLogin(Guid id , string password)
        {
            Login login = new Login()
            {
                UserID = id,
                
                LoginDate = System.DateTime.Now
            };
            if (loginLoggerService.Get(id) == null)
            {
                loginLoggerService.Add(login);
                return;
            }
            loginLoggerService.Edit(login);
        }
    }
}
