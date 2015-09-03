using System;
using System.Collections.Generic;

namespace CrossPlatSample
{
    public interface IInformationPage : IPage
    {
        IDictionary<string, Tuple<string, string>> OpeningTime();
    }
}

