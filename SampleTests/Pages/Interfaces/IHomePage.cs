using System;

namespace CrossPlatSample
{
    public interface IHomePage : IPage
    {
        ILocationsPage ViewLocations();
    }
}

