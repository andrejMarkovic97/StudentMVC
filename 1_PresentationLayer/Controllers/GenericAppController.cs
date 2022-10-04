using _1_PresentationLayer.ApplicationService.GenericAppService;
using _1_PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_PresentationLayer.Controllers
{
    public class GenericAppController<TViewModel,TModel> : Controller where TViewModel:class
                                                                      where TModel:class
    {
        protected readonly IGenericAppService<TViewModel, TModel> genericAppService;

        public GenericAppController(IGenericAppService<TViewModel,TModel> genericAppService)
        {
            this.genericAppService = genericAppService;
        }
        public virtual ActionResult Index()
        {
            
            var list = genericAppService.GetAll();
            return View(list);
        }

        // GET: Generic/Details/5
        public virtual ActionResult Details(Guid id)
        {
            //ViewBag.readOnly = true;
            //ViewBag.disabled = "disabled";
            TViewModel entity = genericAppService.Get(id);
            return View(entity);
        }

        // GET: Generic/Create
        public virtual ActionResult Create()
        {
            
            
            return View("Create");
        }

        // POST: Generic/Create
        [HttpPost]
        public virtual ActionResult Create(TViewModel entity)
        {
            try
            {

                genericAppService.Add(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Generic/Edit/5
        public virtual ActionResult Edit(Guid id)
        {
            TViewModel entity = genericAppService.Get(id);
            if (entity != null)
            {
                //ViewBag.readOnly = false;
                //ViewBag.disabled = "";
                return View("Details", entity);
            }
            return new HttpNotFoundResult();
        }

        // POST: Generic/Edit/5
        [HttpPost]
        public virtual ActionResult Edit(TViewModel entity)
        {
            if (ModelState.IsValid)
            {

                genericAppService.Edit(entity);
                return RedirectToAction("Index");
            }
            return View("Details", entity);
        }

        
        

        // POST: Generic/Delete/5
        [HttpPost]
        public virtual ActionResult Delete(Guid id)
        {


            genericAppService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}