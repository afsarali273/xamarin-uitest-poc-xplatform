using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.Utils;

namespace CrossPlatSample
{
    public static class AppManager
    {
        private static IApp _app;

        public static IApp App
        {
            get { return _app ?? StartApp(); }
            set { _app = value; }
        }

        public static void CloseAppConnection()
        {
            App = null;
        }

        private static IApp StartApp(AppDataMode mode = default(AppDataMode))
        {
            if (Current.Platform == Platform.Android)
            {
                App = ConfigureApp
					.Android
                    .ApkFile("Apps/com.refractored.myshoppe.apk")
                    .StartApp(mode);
            }
            else
            {
                App = ConfigureApp
                    .iOS
                    .AppBundleZip("Apps/MyShopiOS.zip")
                    .StartApp(mode);
            }

            return App;
        }
    }
}

