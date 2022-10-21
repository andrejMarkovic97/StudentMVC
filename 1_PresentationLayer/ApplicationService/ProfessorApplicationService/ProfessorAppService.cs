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

        public override bool Validate(ProfessorViewModel userVM)
        {
            var baseValidate = base.Validate(userVM);
            if (baseValidate == false ||
                (userVM.Subject!=null && (!userVM.Subject.Any(c=>char.IsLetter(c)) || userVM.Subject.Length==0 || userVM.Subject.Length>50)) ||
                (userVM.Cabinet!=null && (userVM.Cabinet.Length==0 || userVM.Cabinet.Length>50)))
            {
                return false;
            }
            return true;
        }
    }
}