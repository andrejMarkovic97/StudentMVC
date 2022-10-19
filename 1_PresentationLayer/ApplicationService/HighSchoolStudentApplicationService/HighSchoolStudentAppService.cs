using _1_PresentationLayer.ApplicationService.GenericAppService;
using _1_PresentationLayer.ApplicationService.UserAppService;
using _1_PresentationLayer.ViewModels;
using _2_BusinessLayer.GenericService;
using _2_BusinessLayer.StudentServices;
using _4_BusinessObjectModel.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ApplicationService.HighSchoolStudentAppService
{
    public class HighSchoolStudentAppService:UserAppService<HighSchoolStudentViewModel,HighSchoolStudent>
    {
        public HighSchoolStudentAppService(IMapper mapper,IUserService<HighSchoolStudent> userService):base(mapper,userService)
        {

        }

        public override bool Validate(HighSchoolStudentViewModel userVM)
        {
            var baseValidate = base.Validate(userVM);
            if(baseValidate == false || userVM.SchoolName.Length==0 || userVM.SchoolName.Any(c => char.IsDigit(c)) ||
                userVM.EnrollmentDate.Value.Year<1940 || userVM.EnrollmentDate.Value.Year> System.DateTime.Now.Year)
            {
                return false;
            }
            return true;
        }
    }
}