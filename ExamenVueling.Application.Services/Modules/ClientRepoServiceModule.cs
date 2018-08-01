using Autofac;
using ExamenVueling.Domain.Entities;
using ExamenVueling.Infrastructure.Repository.Contracts;
using ExamenVueling.Infrastructure.Repository.Modules;
using ExamenVueling.Infrastructure.Repository.Repository;
using ExamenVueling.Common.Layer.Log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Services.Modules
{
    public class ClientRepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ClientRepository>()
                .As<IClientRepository>()
                .InstancePerRequest();

            builder
                .RegisterType<ClientsFileManager>()
                .As<FileManager>()
                .InstancePerRequest();

            builder
                .RegisterType<LogAdapter>()
                .As<ICustomLogger>()
                .InstancePerRequest();

            builder.RegisterModule(new ClientRepositoryModule());
            base.Load(builder);
        }

    }
}
