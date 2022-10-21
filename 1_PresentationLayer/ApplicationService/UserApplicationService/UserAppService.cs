using _1_PresentationLayer.ApplicationService.GenericAppService;
using _1_PresentationLayer.ViewModels;
using _2_BusinessLayer.GenericService;
using _2_BusinessLayer.StudentServices;
using _4_BusinessObjectModel.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ApplicationService.UserAppService
{
    public class UserAppService<TViewModel, TModel> : GenericAppService<TViewModel, TModel>, IUserAppService<TViewModel, TModel> 
                                                                                            where TViewModel : UserViewModel
                                                                                           where TModel : User
    {
        private readonly IUserService<TModel> userService;

        public UserAppService(IMapper mapper,IUserService<TModel> userService) : base(mapper, userService)
        {
            this.userService = userService;
        }

        public void ExportData(TViewModel userVM)
        {
            TModel user = mapper.Map<TModel>(userVM);
            userService.ExportData(user);
            
        }

        public TViewModel GetUserByCredentials(string email, string password)
        {
            var user = userService.GetUserByCredentials(email, password);
            if (user != null)
            {
                TViewModel existingUser = mapper.Map<TViewModel>(user);
                return existingUser;
            }
            return null;
        }

        public TViewModel GetUserByEmail(string email)
        {
            var user = userService.GetUserByEmail(email);
            if (user != null)
            {
                TViewModel existingUser = mapper.Map<TViewModel>(user);
                return existingUser;
            }
            return null;
        }

        public override List<TViewModel> Search(string filter)
        {
            List<TModel> users = userService.Search(filter);
            List<TViewModel> usersVM = mapper.Map<List<TViewModel>>(users);
            return usersVM;
        }

        public virtual bool Validate(TViewModel userVM)
        {
            if (userVM == null ||
                userVM.UserID == null ||
                userVM.FirstName == null || userVM.FirstName.Length==0 ||
                userVM.FirstName.Length>50 || !userVM.FirstName.All(c=>char.IsLetter(c)) ||
                userVM.LastName == null || userVM.LastName.Length == 0 ||
                userVM.LastName.Length>50||!userVM.LastName.All(c => char.IsLetter(c)) ||
                userVM.Password==null || userVM.Password.Length==0|| userVM.Password.Length>50 ||
                userVM.BirthDate==null|| userVM.BirthDate.Year<1900 || userVM.BirthDate.Year>System.DateTime.Now.Year || 
                userVM.BirthDate.Month>12 ||userVM.BirthDate.Month<1 ||
                userVM.BirthDate.Day<1 || userVM.BirthDate.Day>31 ||
                userVM.Email==null|| userVM.Email.Length<7 || !userVM.Email.EndsWith(".com") ||
                userVM.Email.Length>255||!userVM.Email.Contains("@") ||
                userVM.Email.StartsWith("@") || userVM.Email.Contains("@.com") ||
                userVM.Password==null || userVM.Password.Length==0 ||
                userVM.Password.Length>50 ||userVM.PhoneNumber.Any(c => char.IsLetter(c)) ||
                userVM.UserRoles==null && userVM.UserRoles.Count()==0){
                return false;
            }
            return true;
        }
    }
}