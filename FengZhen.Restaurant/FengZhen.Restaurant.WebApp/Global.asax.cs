using FengZhen.Restaurant.Domain.Entities;
using FengZhen.Restaurant.WebApp.Infrastructure.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FengZhen.Restaurant.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            IocConfig.ConfigIoc();

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
