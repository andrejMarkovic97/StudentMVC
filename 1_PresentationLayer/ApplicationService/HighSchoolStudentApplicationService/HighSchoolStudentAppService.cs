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
            if(baseValidate == false ||
                (userVM.SchoolName!=null && (userVM.SchoolName.Length==0 || userVM.SchoolName.Length>50||!userVM.SchoolName.All(c => char.IsLetter(c)))) ||
                userVM.EnrollmentDate == null || userVM.EnrollmentDate.Value.Year < 1900 ||
                userVM.EnrollmentDate.Value.Year > DateTime.Now.Year ||
                userVM.EnrollmentDate.Value.Month > 12 || userVM.EnrollmentDate.Value.Month < 1 ||
                userVM.EnrollmentDate.Value.Day < 1 || userVM.EnrollmentDate.Value.Day > 31)
            {
                return false;
            }
            return true;
        }
    }
}