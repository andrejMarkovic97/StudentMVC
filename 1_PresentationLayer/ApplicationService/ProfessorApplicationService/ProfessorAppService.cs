using _1_PresentationLayer.ApplicationService.UserAppService;
using _1_PresentationLayer.ViewModels;
using _2_BusinessLayer.StudentServices;
using _4_BusinessObjectModel.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ApplicationService.ProfessorApplicationService
{
    public class ProfessorAppService : UserAppService<ProfessorViewModel, Professor>
    {
        public ProfessorAppService(IMapper mapper, IUserService<Professor> userService) : base(mapper, userService)
        {
        }
    }
}