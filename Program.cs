using System;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using jp.tamagotchi.engine.csharp.Registry;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jp.tamagotchi.engine
{
    class Program
    {
        static void Main(string[] args)
        {

            var container = new ContainerBuilder()
                .PopulateServices()
                .RegisterConfiguration()
                .RegisterServer()
                .Build();

            using(var scope = container.BeginLifetimeScope("root"))
            {

                var server = scope.Resolve<Server>();

                server.Start();

                server.Stop().Wait();

            }

            Console.ReadLine();

        }
    }
}