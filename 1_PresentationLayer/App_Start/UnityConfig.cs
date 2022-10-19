using _1_PresentationLayer.ApplicationService.CollegeStudentAppService;
using _1_PresentationLayer.ApplicationService.GenericAppService;
using _1_PresentationLayer.ApplicationService.HighSchoolStudentAppService;
using _1_PresentationLayer.ApplicationService.ProfessorApplicationService;
using _1_PresentationLayer.ApplicationService.RoleAppService;
using _1_PresentationLayer.ApplicationService.UserAppService;
using _1_PresentationLayer.ViewModels;
using _1_PresentationLayer.ViewModels.QueryViewModels;
using _2_BusinessLayer.GenericService;

using _2_BusinessLayer.RoleServices;
using _2_BusinessLayer.StudentServices;
using _3_DataAccess.GenericRepository;
using _3_DataAccess.LoginRepository;
using _3_DataAccess.QueryModelRepository;
using _3_DataAccess.QueryModels;
using _3_DataAccess.Repository;
using _3_DataAccess.RoleRepository;
using _3_DataAccess.StudentRepository;
using _3_DataAccess.UserRepository;

using _4_BusinessObjectModel.Models;
using _5_InfrastructureLayer.Security;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace _1_PresentationLayer.App_Start
{
		public static class UnityConfig
		{
			public static void RegisterComponents()
			{
				var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			//REPOSITORY REGISTRATION
			
			container.RegisterType<IGenericRepository<HighSchoolStudent>, HighSchoolStudentRepository>();
			container.RegisterType<IGenericRepository<CollegeStudent>, CollegeStudentRepository>();
			container.RegisterType<IGenericRepository<Professor>, ProfessorRepository>();

			container.RegisterType<IGenericRepository<User>, UserRepository>();
			container.RegisterType<IGenericRepository<Role>, RoleRepository>();

			container.RegisterType<IGenericRepository<HighSchoolStudentQueryModel>, HighSchoolStudentQueryModelRepository>();
			container.RegisterType<IGenericRepository<CollegeStudentQueryModel>, CollegeStudentQueryModelRepository>();
			container.RegisterType<IGenericRepository<ProfessorQueryModel>, ProfessorQueryModelRepository>();

			container.RegisterType<IGenericRepository<Login>, LoginRepository>();
			container.RegisterType<IGenericRepository<ActionLogger>, GenericRepository<ActionLogger>>();
			//SERVICE REGISTRATION
			//container.RegisterType<IGenericService<User>, StudentService<User>>();

			container.RegisterType<IUserService<HighSchoolStudent>, HighSchoolStudentService>();
			container.RegisterType<IUserService<CollegeStudent>, CollegeStudentService>();
			container.RegisterType<IUserService<Professor>, ProfessorService>();

			container.RegisterType<IUserService<User>, UserService<User>>();
            container.RegisterType<IGenericService<User>, UserService<User>>();

			container.RegisterType<IGenericService<Role>, RoleService>();

			container.RegisterType<IGenericService<HighSchoolStudentQueryModel>, GenericService<HighSchoolStudentQueryModel>>();
			container.RegisterType<IGenericService<CollegeStudentQueryModel>, GenericService<CollegeStudentQueryModel>>();
			container.RegisterType<IGenericService<ProfessorQueryModel>, GenericService<ProfessorQueryModel>>();

			container.RegisterType<IGenericService<Login>, GenericService<Login>>();
			container.RegisterType<IGenericService<ActionLogger>, GenericService<ActionLogger>>();

			//APPLICATION SERVICE REGISTRATION 
			container.RegisterType<IGenericAppService<RoleViewModel,Role>, RoleAppService>();
			container.RegisterType<IGenericAppService<HighSchoolStudentViewModel, HighSchoolStudent>, HighSchoolStudentAppService>();

			container.RegisterType<IGenericAppService<UserViewModel, User>, UserAppService<UserViewModel,User>>();
			container.RegisterType<IUserAppService<UserViewModel, User>, UserAppService<UserViewModel, User>>();

			container.RegisterType<IUserAppService<HighSchoolStudentViewModel,HighSchoolStudent>, HighSchoolStudentAppService>();

			container.RegisterType<IUserAppService<CollegeStudentViewModel, CollegeStudent>, CollegeStudentAppService>();

			container.RegisterType<IUserAppService<ProfessorViewModel, Professor>, ProfessorAppService>();


			container.RegisterType<IGenericAppService<HighSchoolStudentQueryViewModel, HighSchoolStudentQueryModel>, GenericAppService<HighSchoolStudentQueryViewModel, HighSchoolStudentQueryModel>>();
			container.RegisterType<IGenericAppService<CollegeStudentQueryViewModel, CollegeStudentQueryModel>, GenericAppService<CollegeStudentQueryViewModel, CollegeStudentQueryModel>>();
			container.RegisterType<IGenericAppService<ProfessorQueryViewModel, ProfessorQueryModel>, GenericAppService<ProfessorQueryViewModel, ProfessorQueryModel>>();
			//AUTOMAPPER REGISTRATION
			MapperConfiguration config = AutoMappingProfile.Configure();

			IMapper mapper = config.CreateMapper();
			container.RegisterInstance(mapper);



			// e.g. container.RegisterType<ITestService, TestService>();

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
			}
		}
	
}