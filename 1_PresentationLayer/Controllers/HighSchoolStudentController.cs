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
    [Authorize]
    public class HighSchoolStudentController : StudentController<HighSchoolStudent>
    {
        private readonly IStudentService<HighSchoolStudent> centralQuestionService;

        public HighSchoolStudentController(IStudentService<HighSchoolStudent> centralQuestionService) : base(centralQuestionService)
        {
            this.centralQuestionService = centralQuestionService;
        }

        public override ActionResult Create(HighSchoolStudent hs)
        {
            try
            {
                hs.UserID = Guid.NewGuid();
                //hs.Discriminator = Discriminator.HighSchoolStudent;
                centralQuestionService.Add(hs);

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
                centralQuestionService.Edit(hs);
                return RedirectToAction("Index");
            }
            return View("Details", hs);

        }


    }
}
