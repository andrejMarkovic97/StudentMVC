using _1_PresentationLayer.ApplicationService.GenericAppService;
using _1_PresentationLayer.ViewModels;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_PresentationLayer.ApplicationService.UserAppService
{
    public interface IUserAppService<TViewModel, TModel> : IGenericAppService<TViewModel,TModel> where TModel:User 
                                                                                                where TViewModel:UserViewModel
    {
        List<TViewModel> Search(string filter);

        void ExportData(TViewModel student);

        TViewModel GetUserByCredentials(string email, string password);
    }
}
