using System;
using System.Collections.Generic;
using Xamarin.UITest;

namespace CrossPlatSample
{
    public static class Current
    {
        private static IDictionary<string, object> _cache = new Dictionary<string, object>();

        private static void Put<T>(string key, object value)
        {
            if (!_cache.ContainsKey(key))
                _cache.Add(key, value);
            else
            {
                _cache.Remove(key);
                _cache.Add(key, value);
            }
        }

        private static T Get<T>(string key)
        {
            if (!_cache.ContainsKey(key))
                throw new KeyNotFoundException(String.Format("Key not found in cache: '{0}'", key));

            return (T)_cache[key];
        }

        public static Platform Platform
        {
            get 
            { 
                return Get<Platform>("PLATFORM");
            }
            set
            { 
                Put<Platform>("PLATFORM", value);
            }
        }
    }
}

