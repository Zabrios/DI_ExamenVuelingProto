using Autofac;
using Autofac.Integration.WebApi;
using ExamenVueling.Application.DTO;
using ExamenVueling.Application.Services;
using ExamenVueling.Application.Services.Contracts;
using ExamenVueling.Application.Services.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ExamenVueling.Facade.WebApi.Modules
{
    public class ClientApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.
                RegisterType<ClientService>()
                .As<IClientService>()
                //.As<ClientDTO>()
                .InstancePerRequest();

            builder.RegisterModule(new ClientRepoServiceModule());
            base.Load(builder);
        }
    }
}