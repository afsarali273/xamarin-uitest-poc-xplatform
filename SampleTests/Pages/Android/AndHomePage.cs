using System;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace CrossPlatSample
{
    public class AndHomePage : IHomePage
    {
        #region IHomePage implementation

        public ILocationsPage ViewLocations()
        {
            AppManager.App.Tap(e => e.Marked("Locations"));
            return PageResolver.LocationPage();
        }
        #endregion
    }
}

