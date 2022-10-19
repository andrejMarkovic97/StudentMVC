using _1_PresentationLayer.ApplicationService.UserAppService;
using _1_PresentationLayer.ViewModels;
using _2_BusinessLayer.StudentServices;
using _4_BusinessObjectModel.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ApplicationService.CollegeStudentAppService
{
    public class CollegeStudentAppService : UserAppService<CollegeStudentViewModel, CollegeStudent>
    {
        public CollegeStudentAppService(IMapper mapper, IUserService<CollegeStudent> userService) : base(mapper, userService)
        {
        }

        public override bool Validate(CollegeStudentViewModel userVM)
        {
            var baseValidate =  base.Validate(userVM);

            if(baseValidate == false || userVM.InstitutionName.Length == 0 || userVM.InstitutionName.Any(c => char.IsDigit(c)) ||
                userVM.Generation < 1950 || userVM.Generation > System.DateTime.Now.Year || !userVM.Generation.ToString().Any(c => char.IsDigit(c)))
            {
                return false;
            }
            return true;
        }
    }
}