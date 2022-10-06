//using _2_BusinessLayer.GenericService;
//using _2_BusinessLayer.StudentServices;
//using _4_BusinessObjectModel.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace _1_PresentationLayer.Controllers
//{
//    [Authorize]
//    public class StudentController<T> : GenericController<T> where T:User
//    {
//        private readonly IUserService<T> userService;

//        public StudentController(IUserService<T> userService) : base(userService)
//        {
//            this.userService = userService;
//        }


       
//        [HttpPost]
//        public virtual ActionResult Index(string filter)
//        {
//            if (filter == null || filter == "")
//            {
//                var list = userService.GetAll();

//                return View(list);
//            }
//            else
//            {
//                List<T> list = userService.Search(filter);
//                if (list == null || list.Count == 0)
//                {
//                    TempData["ErrorSearch"] = " No results found";
//                    return RedirectToAction("Index");
//                }
//                else
//                {
//                    return View(list);
//                }
//            }
//        }

//        //// GET: User/Details/5
//        //public virtual ActionResult Details(Guid id)
//        //{
//        //    T student = collegeStudentService.Get(id);
//        //    ViewBag.readOnly = true;
//        //    ViewBag.disabled = "disabled";
//        //    return View(student);
//        //}

//        //// GET: User/Create
//        //public virtual ActionResult Create()
//        //{
//        //    return View("Create");
//        //}

//        //// POST: User/Create
//        //[HttpPost]
//        //public virtual ActionResult Create(T student)
//        //{
//        //    return View();
//        //}

//        //// GET: User/Edit/5
//        //public virtual ActionResult Edit(Guid id)
//        //{
//        //    T student = collegeStudentService.Get(id);
//        //    if (student != null)
//        //    {
//        //        ViewBag.readOnly = false;
//        //        ViewBag.disabled = "";
//        //        return View("Details",student);
//        //    }
//        //    return new HttpNotFoundResult();
//        //}

//        //// POST: User/Edit/5
//        //[HttpPost]
//        //public virtual ActionResult Edit(T student)
//        //{
//        //    return View("Index");
//        //}

//        //// GET: User/Delete/5
//        //public virtual ActionResult Delete(Guid id)
//        //{
//        //    T student = collegeStudentService.Get(id);
//        //    if (student != null)
//        //    {
//        //        ViewBag.readOnly = true;
//        //        return View(student);
//        //    }
//        //    return new HttpNotFoundResult();
//        //}
//        //// POST: User/Delete/5
//        //[HttpPost]
//        //public virtual ActionResult Delete(T student)
//        //{
//        //    if (student != null)
//        //    {
                
//        //        collegeStudentService.Delete(student.UserID);
//        //    }
//        //    return RedirectToAction("Index");
//        //}

//        public virtual ActionResult Export(Guid id)
//        {
//            T  student = userService.Get(id);
//            if (student != null)
//            {
//                userService.ExportData(student);
//                TempData["ExportMessage"] = $"Data successfully exported to {student.FirstName}_{student.LastName}.txt";
//            }
//            return RedirectToAction("Details", new { id = student.UserID });
//        }

       
//    }
//}

        

