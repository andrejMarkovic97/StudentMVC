using _1_PresentationLayer.ApplicationService.UserAppService;
using _1_PresentationLayer.ViewModels;
using _2_BusinessLayer.GenericService;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_PresentationLayer.Controllers
{
    public class UserAppController<TViewModel, TModel> : GenericAppController<TViewModel,TModel> where TModel:User
                                                                                                 where TViewModel:UserViewModel,new()
    {
        protected readonly IUserAppService<TViewModel, TModel> userAppService;
        protected readonly IGenericService<ActionLogger> actionLoggerService;
        protected readonly IUserAppService<UserViewModel, User> actionLoggerUserAppService;

        public UserAppController(IUserAppService<TViewModel, TModel> userAppService , IGenericService<ActionLogger> actionLoggerService, 
            IUserAppService<UserViewModel, User> actionLoggerUserAppService) :base(userAppService)
        {
            this.userAppService = userAppService;
            this.actionLoggerService = actionLoggerService;
            this.actionLoggerUserAppService = actionLoggerUserAppService;
        }

        public override ActionResult Create()
        {
            TViewModel tvm = new TViewModel
            {
                Title = "Create",
                IsReadOnly = false,
                BirthDate = new DateTime(1990, 1, 1)
                
                
            };
            return View("Create",tvm);
        }

        public override ActionResult Create(TViewModel entity)
        {
            if (ModelState.IsValid)
            {

                if (userAppService.Validate(entity))
                {
                    genericAppService.Add(entity);
                    AddActionLog(System.Reflection.MethodBase.GetCurrentMethod().Name,entity.UserID);
                  

                    return RedirectToAction("Index");
                }
        }
            return View();
        }

        public override ActionResult Delete(Guid id)
        {
            userAppService.Delete(id);
            AddActionLog(System.Reflection.MethodBase.GetCurrentMethod().Name,Guid.Empty);
            return RedirectToAction("Index");
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

        public override ActionResult Edit(TViewModel entity)
        {
            //if (ModelState.IsValid)
            //{
            entity.UserRoles = userAppService.Get(entity.UserID).UserRoles;
            if (userAppService.Validate(entity))
                {
                    userAppService.Edit(entity);
                    AddActionLog(System.Reflection.MethodBase.GetCurrentMethod().Name,entity.UserID);
                    return RedirectToAction("Details", new { id = entity.UserID });
                }
                TempData["ErrorValidate"] = "Invalid information";
            //}
            return View("Details", entity);
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

        public ActionResult UserProfile()
        {

            var email = User.Identity.Name;
            if (email != null && email.Length > 0) {
              
                var user = userAppService.GetUserByEmail(email);
                user.IsReadOnly = true;
                user.IsDisabled = true;
                return View(user);
            }
            return new HttpNotFoundResult();
            
        }
       protected void AddActionLog(string actionName,Guid alteredUserID)
        {
            var email = User.Identity.Name;
            UserViewModel user = actionLoggerUserAppService.GetUserByEmail(email);
            
            ActionLogger al = new ActionLogger()
            {
                UserID = user.UserID,
                Action = actionName,
                TimeOfAction = DateTime.Now,
                AlteredUserID = alteredUserID
            };
            actionLoggerService.Add(al);
        }
    }
}