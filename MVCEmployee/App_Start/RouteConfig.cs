using Microsoft.Extensions.DependencyInjection;
using MVC.Data.Models;
using MVC.Data.Repositories;
using MVC.Data.Repositories.Interfaces;
using MVC.Services;
using MVC.Services.Interfaces;
using MVCEmployee.App_Start;
using MVCEmployee.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCEmployee
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            ConfigureServices();
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton(typeof(Context));
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<ITeacherService, TeacherService>();

            ServiceProviderExtensions.AddControllersAsServices(services, typeof(RouteConfig).Assembly.GetExportedTypes()
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                .Where(t => typeof(IController).IsAssignableFrom(t) || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));

            DependencyResolver.SetResolver(new MyDependencyResolver(services.BuildServiceProvider()));
        }
    }
}
