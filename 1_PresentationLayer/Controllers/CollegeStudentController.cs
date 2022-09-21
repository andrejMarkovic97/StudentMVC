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
    public class CollegeStudentController : StudentController<CollegeStudent>
    {
        private readonly IStudentService<CollegeStudent> centralQuestionService;

      
        public CollegeStudentController(IStudentService<CollegeStudent> centralQuestionService) : base(centralQuestionService)
        {
            this.centralQuestionService = centralQuestionService;
        }

        public override ActionResult Create(CollegeStudent cs)
        {
            try
            {
                cs.UserID = Guid.NewGuid();
                //cs.Discriminator = Discriminator.CollegeStudent;
                centralQuestionService.Add(cs);

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
                centralQuestionService.Edit(cs);
                return RedirectToAction("Index");
            }
            return View("Details", cs);
        }

    }
}
