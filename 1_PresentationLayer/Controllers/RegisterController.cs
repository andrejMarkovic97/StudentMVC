using _2_BusinessLayer.StudentServices;
using _2_BusinessLayer.UserServices;
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
        private readonly IUserService centralQuestionService;

        public RegisterController(IUserService centralQuestionService)
        {
            this.centralQuestionService = centralQuestionService;
        }
        // GET: Register
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {

            centralQuestionService.Add(user);
            return RedirectToAction("Index", "Home");
        }
    }
}