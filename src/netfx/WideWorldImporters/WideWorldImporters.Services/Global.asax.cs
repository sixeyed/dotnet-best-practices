using Autofac;
using Autofac.Integration.Wcf;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using log4net;
using log4net.Config;
using System;
using WideWorldImporters.Data;
using WideWorldImporters.Services.Caching;
using WideWorldImporters.Services.Config;

namespace WideWorldImporters.Services
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // logging:
            XmlConfigurator.Configure();

            // config:
            IConfig config = new AppSettingsConfig();

            // DI - core components:
            var builder = new ContainerBuilder();
            builder.RegisterInstance(config).As<IConfig>().SingleInstance();
            builder.Register(c => LogManager.GetLogger(typeof(object))).As<ILog>();
            builder.RegisterType<WideWorldImportersEntities>().InstancePerLifetimeScope();

            // mappers:
            builder.RegisterAutoMapper(typeof(Global).Assembly);

            // cache:
            if (config.UseCache)
            {
                builder.RegisterType<MemoryCache>().As<ICache>().SingleInstance();
            }
            else
            {
                builder.RegisterType<NullCache>().As<ICache>().SingleInstance();
            }

            // services:
            builder.RegisterType<CitiesService>().InstancePerLifetimeScope();

            var container = builder.Build();
            AutofacHostFactory.Container = container;
        }
    }
}