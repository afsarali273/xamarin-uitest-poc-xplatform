using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.iOS;
using Autofac;

namespace CrossPlatSample
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        public Tests(Platform platform)
        {
            Current.Platform = platform;
        }
        [Test]
        public void AppLaunches()
        {
            PageResolver.HomePage()
                .ViewLocations()
                .SelectLoaction("Xamarin Denmark APS");
        }

        [Test]
        public void AppLaunchesTwo()
        {
            var homePage = PageResolver.HomePage();
            homePage.ViewLocations();

            var locationPage = PageResolver.LocationPage();
            locationPage.SelectLoaction("Xamarin Denmark APS");
        }

        [TearDown]
        public void After()
        {
            AppManager.CloseAppConnection();
            PageContainer.DisposeContainer();
        }
    }
}

