using Autofac;
using Autofac.Integration.Mvc;
using MK_KupSkorer.Contracts;
using MK_KupSkorer.Services;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MK_KupSkorer.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // OPTIONAL: Enable action method parameter injection (RARE).
            // builder.InjectActionInvoker();


            builder.RegisterType<PlayerService>().As<IPlayerService>();
            builder.RegisterType<KupService>().As<IKupService>();
            builder.RegisterType<RaceService>().As<IRaceService>();
            builder.RegisterType<ReportKardService>().As<IReportKardService>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
