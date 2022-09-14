using _2_BusinessLayer.StudentServices;
using _3_DataAccess.Repository;
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
			//container.RegisterType(typeof(IStudentService<>), typeof(StudentService<>));
			//container.RegisterType(typeof(IStudentRepository<>), typeof(StudentRepository<>));
			container.RegisterType<IStudentService<HighSchoolStudent>, HighSchoolStudentService>();
			container.RegisterType<IStudentService<CollegeStudent>, CollegeStudentService>();

			container.RegisterType<IStudentRepository<HighSchoolStudent>, HighSchoolStudentRepository>();
			container.RegisterType<IStudentRepository<CollegeStudent>, CollegeStudentRepository>();


			// e.g. container.RegisterType<ITestService, TestService>();

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
			}
		}
	
}