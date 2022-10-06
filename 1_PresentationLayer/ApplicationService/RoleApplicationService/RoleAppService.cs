using _1_PresentationLayer.ApplicationService.GenericAppService;
using _1_PresentationLayer.ApplicationService.RoleAppService;
using _1_PresentationLayer.ViewModels;
using _2_BusinessLayer.GenericService;
using _2_BusinessLayer.RoleServices;
using _4_BusinessObjectModel.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ApplicationService.RoleAppService
{
    public class RoleAppService : GenericAppService<RoleViewModel, Role>
    {
        public RoleAppService(IMapper mapper, IGenericService<Role> genericService) : base(mapper, genericService)
        {
        }

        //public override void Add(RoleViewModel viewModel)
        //{
        //    Role role = mapper.Map<Role>(viewModel);
        //    role.RoleID = Guid.NewGuid();
        //    genericService.Add(role);
        //}

        //public override void Edit(RoleViewModel viewModel)
        //{
        //    if (viewModel != null)
        //    {
        //        Role role = mapper.Map<Role>(viewModel);
        //        role.RoleID = viewModel.RoleID;
        //        genericService.Edit(role);
        //    }
        //}
    }
}