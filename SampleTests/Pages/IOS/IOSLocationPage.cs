using System;
using System.Collections.Generic;
using Xamarin.UITest;

namespace CrossPlatSample
{
    public class IOSLocationPage : ILocationsPage
    {
        #region ILocationsPage implementation

        public IEnumerable<string> Locations()
        {
            throw new NotImplementedException();
        }

        public void SelectLoaction(string location)
        {
            AppManager.App.Tap(e => e.Marked(location));
        }

        #endregion
    }
}

