using _2_BusinessLayer.GenericService;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ApplicationService.GenericAppService
{
  
    public class GenericAppService<TViewModel, TModel> : IGenericAppService<TViewModel, TModel> where TViewModel : class
                                                                                where TModel : class
    {
        protected readonly IMapper mapper;
        protected readonly IGenericService<TModel> genericService;

        public GenericAppService(IMapper mapper,IGenericService<TModel> genericService)
        {
            this.mapper = mapper;
            this.genericService = genericService;
        }
        public virtual void Add(TViewModel viewModel)
        {
            TModel businessObjectModel = mapper.Map<TModel>(viewModel);
            genericService.Add(businessObjectModel);
            
        }

        public virtual void Delete(Guid id)
        {
            genericService.Delete(id);
        }

        public virtual void Edit(TViewModel viewModel)
        {
            if (viewModel != null)
            {
                TModel businessObjectModel = mapper.Map<TModel>(viewModel);
                genericService.Edit(businessObjectModel);
            }
        }

        public TViewModel Get(Guid id)
        {
            TViewModel viewModel = mapper.Map<TViewModel>(genericService.Get(id));
            return viewModel;
        }

        public List<TViewModel> GetAll()
        {
            List<TModel> models = genericService.GetAll();   
            List<TViewModel> list = mapper.Map<List<TViewModel>>(models);
            
            return list;
        }

        public virtual List<TViewModel> Search(string filter)
        {
            List<TModel> users = genericService.Search(filter);
            List<TViewModel> usersVM = mapper.Map<List<TViewModel>>(users);
            return usersVM;
        }
    }
}