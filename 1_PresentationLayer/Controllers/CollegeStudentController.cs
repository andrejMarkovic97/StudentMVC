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
    [Authorize(Roles="User")]
    public class CollegeStudentController : StudentController<CollegeStudent>
    {
        private readonly IUserService<CollegeStudent> collegeStudentService;

      
        public CollegeStudentController(IUserService<CollegeStudent> collegeStudentService) : base(collegeStudentService)
        {
            this.collegeStudentService = collegeStudentService;
        }

        public override ActionResult Create(CollegeStudent cs)
        {
            try
            {
                cs.UserID = Guid.NewGuid();
                //cs.Discriminator = Discriminator.CollegeStudent;
                collegeStudentService.Add(cs);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        public override ActionResult Edit(CollegeStudent cs)
        {
            if (ModelState.IsValid)
            {
                //cs.Discriminator = Discriminator.CollegeStudent;
                collegeStudentService.Edit(cs);
                return RedirectToAction("Index");
            }
            return View("Details", cs);
        }

    }
}
