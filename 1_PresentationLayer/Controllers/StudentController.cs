using _2_BusinessLayer.GenericServices;
using _2_BusinessLayer.StudentServices;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_PresentationLayer.Controllers
{
    [Authorize]
    public class StudentController<T> : GenericController<T> where T:Student
    {
        private readonly IStudentService<T> centralQuestionService;

        public StudentController(IStudentService<T> centralQuestionService) : base(centralQuestionService)
        {
            this.centralQuestionService = centralQuestionService;
        }


        // GET: Student
        public virtual ActionResult Index(string filter)
        {
            if (filter == null || filter == "")
            {
                var list = centralQuestionService.GetAll();

                return View(list);
            }
            else
            {
                List<T> list = centralQuestionService.Search(filter);
                if (list == null || list.Count == 0)
                {
                    TempData["ErrorSearch"] = " No results found";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(list);
                }
            }
        }

        //// GET: Student/Details/5
        //public virtual ActionResult Details(Guid id)
        //{
        //    T student = centralQuestionService.Get(id);
        //    ViewBag.readOnly = true;
        //    ViewBag.disabled = "disabled";
        //    return View(student);
        //}

        //// GET: Student/Create
        //public virtual ActionResult Create()
        //{
        //    return View("Create");
        //}

        //// POST: Student/Create
        //[HttpPost]
        //public virtual ActionResult Create(T student)
        //{
        //    return View();
        //}

        //// GET: Student/Edit/5
        //public virtual ActionResult Edit(Guid id)
        //{
        //    T student = centralQuestionService.Get(id);
        //    if (student != null)
        //    {
        //        ViewBag.readOnly = false;
        //        ViewBag.disabled = "";
        //        return View("Details",student);
        //    }
        //    return new HttpNotFoundResult();
        //}

        //// POST: Student/Edit/5
        //[HttpPost]
        //public virtual ActionResult Edit(T student)
        //{
        //    return View("Index");
        //}

        //// GET: Student/Delete/5
        //public virtual ActionResult Delete(Guid id)
        //{
        //    T student = centralQuestionService.Get(id);
        //    if (student != null)
        //    {
        //        ViewBag.readOnly = true;
        //        return View(student);
        //    }
        //    return new HttpNotFoundResult();
        //}
        //// POST: Student/Delete/5
        //[HttpPost]
        //public virtual ActionResult Delete(T student)
        //{
        //    if (student != null)
        //    {
                
        //        centralQuestionService.Delete(student.ID);
        //    }
        //    return RedirectToAction("Index");
        //}

        public virtual ActionResult Export(Guid id)
        {
            T  student = centralQuestionService.Get(id);
            if (student != null)
            {
                centralQuestionService.ExportData(student);
                TempData["ExportMessage"] = $"Data successfully exported to {student.FirstName}_{student.LastName}.txt";
            }
            return RedirectToAction("Details", new { id = student.ID });
        }

        public virtual ActionResult ConfirmPopup(Guid id)
        {
            T student = centralQuestionService.Get(id);
            return PartialView("_ModalPopUp", student);
        }
    }
}

        

