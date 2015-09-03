using System;
using Autofac;
using Xamarin.UITest;

namespace CrossPlatSample
{
    public static class PageResolver
    {
        private static T ResolvePage<T>() where T : IPage
        {
            return PageContainer.Resolve<T>();
        }

        public static IHomePage HomePage()
        {
            return ResolvePage<IHomePage>();
        }

        public static IInformationPage InformationPage()
        {
            return ResolvePage<IInformationPage>();
        }

        public static ILocationsPage LocationPage()
        {
            return ResolvePage<ILocationsPage>();
        }
    }
}

