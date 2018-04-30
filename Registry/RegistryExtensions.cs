using System;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jp.tamagotchi.engine.csharp.Registry
{
    public static class RegistryExtensions
    {
        public static ContainerBuilder PopulateServices(this ContainerBuilder builder, params Action<ServiceCollection>[] actions = [])
        {

            var services = new ServiceCollection();

            Array.ForEach(actions, action => action.Invoke(services));

            builder.Populate(services);

            return builder;

        }

        public static ContainerBuilder RegisterConfiguration(this ContainerBuilder builder)
        {

            builder.Register(c => new ConfigurationBuilder()
                    .AddJsonFile("appSettings.json", true, true)
                    .Build()
                )
                .As<IConfiguration>();

            return builder;

        }

        public static ContainerBuilder RegisterServer(this ContainerBuilder builder)
        {

            builder.RegisterType<Server>().AsSelf();

            return builder;

        }
    }
}