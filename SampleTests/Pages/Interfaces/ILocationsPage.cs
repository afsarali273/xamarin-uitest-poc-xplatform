using System;
using Xamarin.UITest.Queries;
using System.Collections.Generic;

namespace CrossPlatSample
{
    public interface ILocationsPage : IPage
    {
        IEnumerable<string> Locations();
        void SelectLoaction(string location);
    }
}

