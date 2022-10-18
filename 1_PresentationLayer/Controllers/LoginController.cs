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

        public LoginController(IUserAppService<UserViewModel,User> userAppService)
        {
            this.userAppService = userAppService;
        }
        public ActionResult Login()
        {

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

                    if(User.IsInRole("Admin"))
                    
                    {

                        return RedirectToAction("AdminArea", "Home");
                    }
                   
                    if (User.IsInRole("CollegeStudent"))
                    {
                        return RedirectToAction("UserProfile", "CollegeStudent");
                    }
                   
                    if (User.IsInRole("HighSchoolStudent"))
                    {
                        return RedirectToAction("UserProfile", "HighSchoolStudent");
                    }
                   
                    if (User.IsInRole("Professor"))
                    {
                        return RedirectToAction("UserProfile", "Professor");
                    }
                }
                TempData["LoginMessage"] = "Invalid credentials";
                return View("Login");
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
    }
}
