using _2_BusinessLayer.GenericServices;
using _2_BusinessLayer.RoleServices;
using _2_BusinessLayer.StudentServices;
using _2_BusinessLayer.UserServices;
using _3_DataAccess.Repository;
using _3_DataAccess.RoleRepository;
using _3_DataAccess.UserRepository;
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
			container.RegisterType<IGenericRepository<Student>, StudentRepository>();
			container.RegisterType<IGenericRepository<HighSchoolStudent>, HighSchoolStudentRepository>();
			container.RegisterType<IGenericRepository<Student>, StudentRepository>();

			container.RegisterType<IGenericRepository<User>, UserRepository>();
			container.RegisterType<IGenericRepository<Role>, RoleRepository>();
			
			//SERVICE REGISTRATION
			container.RegisterType<IStudentService<HighSchoolStudent>, HighSchoolStudentService>();
			container.RegisterType<IStudentService<CollegeStudent>, CollegeStudentService>();
			container.RegisterType<IGenericService<User>, UserService>();
			container.RegisterType<IGenericService<Role>, RoleService>();



			// e.g. container.RegisterType<ITestService, TestService>();

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
			}
		}
	
}