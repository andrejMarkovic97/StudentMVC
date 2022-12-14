using _1_PresentationLayer.ViewModels;
using _1_PresentationLayer.ViewModels.QueryViewModels;
using _3_DataAccess.QueryModels;
using _4_BusinessObjectModel.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.App_Start
{
    public class AutoMappingProfile : Profile
    {
        //public static IMapper Mapper { get; set; } 

        public static MapperConfiguration Configure()
        {
            var mapperConfiguration = new MapperConfiguration(
               config =>
               {
                   config.CreateMap<Role,RoleViewModel>();
                   config.CreateMap<RoleViewModel, Role>();

                   config.CreateMap<User, UserViewModel>();
                   config.CreateMap<UserViewModel, User>();

                   config.CreateMap<HighSchoolStudent, HighSchoolStudentViewModel>();
                   config.CreateMap<HighSchoolStudentViewModel, HighSchoolStudent>();

                   config.CreateMap<CollegeStudent, CollegeStudentViewModel>();
                   config.CreateMap<CollegeStudentViewModel, CollegeStudent>();

                   config.CreateMap<Professor, ProfessorViewModel>();
                   config.CreateMap<ProfessorViewModel, Professor>();

                   

                   config.CreateMap<HighSchoolStudentQueryModel, HighSchoolStudentQueryViewModel>();
                   config.CreateMap<HighSchoolStudentQueryViewModel, HighSchoolStudentQueryModel>();

                   config.CreateMap<CollegeStudentQueryModel, CollegeStudentQueryViewModel>();
                   config.CreateMap<CollegeStudentQueryViewModel, CollegeStudentQueryModel>();

                   config.CreateMap<ProfessorQueryModel, ProfessorQueryViewModel>();
                   config.CreateMap<ProfessorQueryViewModel, ProfessorQueryModel>();



               });


            return mapperConfiguration;
        }

    }
}