using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DigitalResourcesLibrary.Attribute;
using DigitalResourcesLibrary.Controllers;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Services;

namespace DigitalResourcesLibrary
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalFilters.Filters.Add(new HandleAllErrorAttribute());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(typeof(ContainerControllerFactory));


            /*CreateDB bd = new CreateDB();
            bd.RunScript();*/
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session != null)
            {
                CultureInfo ci = (CultureInfo)this.Session["Culture"];
                if (ci == null)
                {
                    string langName = Language.ru.ToString(); // Default culture
                    ci = new CultureInfo(langName);
                    this.Session["Culture"] = ci;
                }
                //Establish a culture for each request
                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            }
        }
    }

    public class ContainerControllerFactory : DefaultControllerFactory
    {
        private readonly WindsorContainer container;

        public ContainerControllerFactory()
        {
            container = new WindsorContainer();

#pragma warning disable 618
            container.Register(AllTypes.Of(typeof (IController)).FromAssembly(typeof (HomeController).Assembly));
            container.Register(
                AllTypes.Pick().FromAssembly(typeof(SearchService).Assembly)
                .If(s => s.Name.EndsWith("Service"))
                .WithService.FirstInterface()
                );
        }

        protected override IController GetControllerInstance(
        RequestContext requestContext,
        Type controllerType)
        {
            return (IController)container.Resolve(controllerType);
        }
    }
}