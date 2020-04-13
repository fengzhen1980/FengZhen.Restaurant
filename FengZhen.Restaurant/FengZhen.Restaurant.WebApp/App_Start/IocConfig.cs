using Autofac;
using Autofac.Integration.Mvc;
using FengZhen.Restaurant.Domain.Abstract;
using FengZhen.Restaurant.Domain.Concrete;
using FengZhen.Restaurant.WebApp.Abstract;
using FengZhen.Restaurant.WebApp.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FengZhen.Restaurant.WebApp
{
    public class IocConfig
    {
        public static void ConfigIoc()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            ////////////////////////////////
            // My added RegisterInstance //
            ///////////////////////////////
            builder.RegisterInstance<IFoodsRepository>(new EFFoodsRepository()).PropertiesAutowired();

            builder.RegisterInstance<IOrderProcessor>(new EmailOrderProcessor(new EmailSettings())).PropertiesAutowired();

            builder.RegisterType<EFDbContext>();

            builder.RegisterType<EFAuthProvider>().PropertiesAutowired().As<IAuthProvider>().PropertiesAutowired();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}