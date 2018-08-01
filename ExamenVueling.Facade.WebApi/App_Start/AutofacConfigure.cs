using Autofac;
using Autofac.Integration.WebApi;
using ExamenVueling.Facade.WebApi.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ExamenVueling.Facade.WebApi.App_Start
{
    public class AutofacConfigure
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ClientApiModule());

            var container = builder.Build();

            // El que resuelve todas las clases registradas -> AutofacWebApiDependencyResolver
            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            return container;
        }
    }
}