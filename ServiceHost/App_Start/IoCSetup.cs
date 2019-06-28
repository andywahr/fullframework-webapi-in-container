using Autofac;
using Autofac.Integration.WebApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace fullframework_webapi_in_container
{
    public static class IoC
    {
        public static void Setup(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            // Register Mediatr

            builder.RegisterType<Mediator>()
                   .As<IMediator>()
                   .InstancePerLifetimeScope();

            // request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            // setup WebApi controllers for IoC
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // register items in other assembly
            builder.RegisterAssemblyModules(typeof(Application.Module).Assembly);

            WebApiApplication.Container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(WebApiApplication.Container);
        }
    }
}