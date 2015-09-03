using System;
using Xamarin.UITest.iOS;
using Xamarin.UITest;

namespace CrossPlatSample
{
    public class IOSHomePage : IHomePage
    {
        #region IHomePage implementation

        public ILocationsPage ViewLocations()
        {
            AppManager.App.Tap(e => e.Marked("Locations"));
            return PageResolver.LocationPage();
        }

        #endregion

        public void Title()
        {
            
        }
    }
}

