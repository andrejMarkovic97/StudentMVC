using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_PresentationLayer.ApplicationService.GenericAppService
{
   public interface IGenericAppService<TViewModel,TModel> where TViewModel : class
                                                          where TModel : class
    {
        void Add(TViewModel entity);
        List<TViewModel> GetAll();
        List<TViewModel> Search(string filter);
        TViewModel Get(Guid id);

       
        void Edit(TViewModel entity);
        void Delete(Guid id);


    }
}
