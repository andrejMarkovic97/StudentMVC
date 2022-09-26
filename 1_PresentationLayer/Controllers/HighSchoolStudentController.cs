using _2_BusinessLayer.StudentServices;
using _4_BusinessObjectModel;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_PresentationLayer.Controllers
{
    [Authorize(Roles="Admin","User")]
    public class HighSchoolStudentController : StudentController<HighSchoolStudent>
    {
        private readonly IUserService<HighSchoolStudent> highSchoolStudentService;

        public HighSchoolStudentController(IUserService<HighSchoolStudent> highSchoolStudentService) : base(highSchoolStudentService)
        {
            this.highSchoolStudentService = highSchoolStudentService;
        }

        public override ActionResult Create(HighSchoolStudent hs)
        {
            try
            {
                hs.UserID = Guid.NewGuid();
                //hs.Discriminator = Discriminator.HighSchoolStudent;
                highSchoolStudentService.Add(hs);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        public override ActionResult Edit(HighSchoolStudent hs)
        {
            if (ModelState.IsValid)
            {
                //hs.Discriminator = Discriminator.HighSchoolStudent;
                highSchoolStudentService.Edit(hs);
                return RedirectToAction("Index");
            }
            return View("Details", hs);

        }


    }
}
