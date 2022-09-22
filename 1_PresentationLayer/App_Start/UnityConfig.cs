using _2_BusinessLayer.GenericServices;
using _2_BusinessLayer.RoleServices;
using _2_BusinessLayer.StudentServices;
using _2_BusinessLayer.UserRoleServices;
using _3_DataAccess.Repository;
using _3_DataAccess.RoleRepository;
using _3_DataAccess.UserRepository;
using _3_DataAccess.UserRoleRepository;
using _4_BusinessObjectModel.Models;
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

			container.RegisterType<IGenericRepository<User>, UserRepository>();
			container.RegisterType<IGenericRepository<Role>, RoleRepository>();
			container.RegisterType<IGenericRepository<UserRole>, UserRoleRepository>();
			//SERVICE REGISTRATION
			//container.RegisterType<IGenericService<User>, StudentService<User>>();

			container.RegisterType<IStudentService<HighSchoolStudent>, HighSchoolStudentService>();
			container.RegisterType<IStudentService<CollegeStudent>, CollegeStudentService>();

			container.RegisterType<IStudentService<User>, UserService<User>>();
			container.RegisterType<IGenericService<User>, UserService<User>>();

			container.RegisterType<IGenericService<Role>, RoleService>();
			container.RegisterType<IGenericService<UserRole>, UserRoleService>();


			// e.g. container.RegisterType<ITestService, TestService>();

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
			}
		}
	
}