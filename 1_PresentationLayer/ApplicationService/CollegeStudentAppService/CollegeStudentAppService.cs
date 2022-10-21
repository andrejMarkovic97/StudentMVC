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

            if(baseValidate == false || userVM.InstitutionName==null ||
                (userVM.InstitutionName!=null && (userVM.InstitutionName.Length == 0 || !userVM.InstitutionName.All(c => char.IsLetter(c)) ||userVM.InstitutionName.Length>50)) ||
                userVM.Generation < 1900 || userVM.Generation > DateTime.Now.Year || userVM.Generation>userVM.BirthDate.Year||
                !userVM.Generation.ToString().Any(c => char.IsDigit(c)))
            {
                return false;
            }
            return true;
        }
    }
}