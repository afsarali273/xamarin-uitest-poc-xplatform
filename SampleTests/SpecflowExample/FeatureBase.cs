using System;
using Xamarin.UITest;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CrossPlatSample
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class FeatureBase
    {
        private Platform _platform;

        public FeatureBase(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void SetUp()
        {
            //FeatureContext.Current.Set<Platform>(_platform , "CurrentPlatform");
            Current.Platform = _platform;
        }
    }
}

