using System;
using Autofac;
using Xamarin.UITest;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace CrossPlatSample
{
    public static class PageContainer
    {
        private static IContainer _container;

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static void DisposeContainer()
        {
            Container.Dispose();
            Container = null;
        }

        private static IContainer Container
        {
            get 
            { 
                return _container ?? Initialise();
            }
            set { _container = value; }
        }

        private static IContainer Initialise()
        {
            var builder = new ContainerBuilder(); 
            Container = RegisterAll(builder).Build();
            return Container;
        }

        private static ContainerBuilder RegisterAll(ContainerBuilder builder)
        {
            var prefix = Current.Platform == Platform.Android ? "And" : "IOS";

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(i => i.Name.StartsWith(prefix) && i.Name.EndsWith("Page"))
                .AsImplementedInterfaces();  

            return builder;
        }
    }
}

