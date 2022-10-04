using _1_PresentationLayer.ApplicationService.GenericAppService;
using _1_PresentationLayer.ViewModels;
using _2_BusinessLayer.GenericServices;
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

        public List<TViewModel> Search(string filter)
        {
            List<TModel> users = userService.Search(filter);
            List<TViewModel> usersVM = mapper.Map<List<TViewModel>>(users);
            return usersVM;
        }
    }
}