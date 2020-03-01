using System;
using Autofac;

namespace Tests.Autofac
{
    static partial class Injection
    {
        private static readonly IContainer Container;

        static Injection()
        {
            Container = BuildContainer();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static T ResolveKeyed<T>(object serviceKey)
        {
            return Container.ResolveKeyed<T>(serviceKey);
        }

        public static ILifetimeScope BeginLifetimeScope()
        {
            return Container.BeginLifetimeScope();
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            CreateClassMap(builder);

            return builder.Build();
        }
    }
}
