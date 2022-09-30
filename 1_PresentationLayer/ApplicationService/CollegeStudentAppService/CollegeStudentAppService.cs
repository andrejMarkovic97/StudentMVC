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
    }
}