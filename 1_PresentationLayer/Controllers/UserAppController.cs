using _1_PresentationLayer.ApplicationService.UserAppService;
using _1_PresentationLayer.ViewModels;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_PresentationLayer.Controllers
{
    public class UserAppController<TViewModel, TModel> : GenericAppController<TViewModel,TModel> where TModel:User
                                                                                                 where TViewModel:UserViewModel
    {
        private readonly IUserAppService<TViewModel, TModel> userAppService;

        public UserAppController(IUserAppService<TViewModel, TModel> userAppService):base(userAppService)
        {
            this.userAppService = userAppService;
        }

        public override ActionResult Details(Guid id)
        {
            
            TViewModel user = userAppService.Get(id);
            
            if (user != null)
            {
                user.IsDisabled = true;
                user.IsReadOnly = true;
                return View(user);
            }
            return new HttpNotFoundResult();
        }

        public override ActionResult Edit(Guid id)
        {
            TViewModel user = userAppService.Get(id);
            if (user != null)
            {
                user.IsDisabled = false;
                user.IsReadOnly = false;
                return View("Details", user);
            }
            return new HttpNotFoundResult();
        }

        public virtual ActionResult Export(Guid id)
        {
            TViewModel user = userAppService.Get(id);
            if (user != null)
            {
                userAppService.ExportData(user);
                TempData["ExportMessage"] = $"Data successfully exported to {user.FirstName}_{user.LastName}.txt";
            }
            return RedirectToAction("Details", new { id = user.UserID });
        }

        [HttpPost]
        public virtual ActionResult Index(string filter)
        {
            if (filter == null || filter == "")
            {
                var list = userAppService.GetAll();

                return View(list);
            }
            else
            {
                List<TViewModel> list = userAppService.Search(filter);
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
    }
}