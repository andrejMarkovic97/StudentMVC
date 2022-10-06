//using _2_BusinessLayer.GenericService;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace _1_PresentationLayer.Controllers
//{
//    public class GenericController<T> : Controller where T:class
//    {
//        private readonly IGenericService<T> genericService;

//        public GenericController(IGenericService<T> genericService)
//        {
//            this.genericService = genericService;
//        }
//        // GET: Generic
//        public virtual ActionResult Index()
//        {
//            var list = genericService.GetAll();
//            return View(list);
//        }

//        // GET: Generic/Details/5
//        public virtual ActionResult Details(Guid id)
//        {
//            ViewBag.readOnly = true;
//            ViewBag.disabled = "disabled";
//            T entity = genericService.Get(id);
//            return View(entity);
//        }

//        // GET: Generic/Create
//        public virtual ActionResult Create()
//        {
//            return View("Create");
//        }

//        // POST: Generic/Create
//        [HttpPost]
//        public virtual ActionResult Create(T entity)
//        {
//            try
//            {
                
//                genericService.Add(entity); 
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Generic/Edit/5
//        public virtual ActionResult Edit(Guid id)
//        {
//            T entity = genericService.Get(id);
//            if (entity != null)
//            {
//                ViewBag.readOnly = false;
//                ViewBag.disabled = "";
//                return View("Details", entity);
//            }
//            return new HttpNotFoundResult();
//        }

//        // POST: Generic/Edit/5
//        [HttpPost]
//        public virtual ActionResult Edit(T entity)
//        {
//            if(ModelState.IsValid)
//            {
                
//                genericService.Edit(entity);
//                return RedirectToAction("Index");
//            }
//            return View("Details", entity);
//        }

//        // GET: Generic/Delete/5
//        //public virtual ActionResult Delete(Guid id)
//        //{
//        //    T entity = genericService.Get(id);
//        //    ViewBag.readOnly = true;
//        //    if (entity != null)
//        //    {
//        //        ViewBag.readOnly = true;
//        //        return View(entity);
//        //    }
//        //    return new HttpNotFoundResult();
//        //}

//        //POST: Generic/Delete/5
//        [HttpPost]
//        public virtual ActionResult Delete(Guid id)
//        {
            

//            genericService.Delete(id);
            
//            return RedirectToAction("Index");
//        }
//    }
//}
