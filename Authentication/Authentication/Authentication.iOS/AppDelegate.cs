using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using static Authentication.App;

namespace Authentication.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IAuthenticate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            myView.Init((IAuthenticate)this);
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        // Define a authenticated user.
        private MobileServiceUser user;
        MobileServiceClient client = new MobileServiceClient("https://apchin-mobileapp.azurewebsites.net");

        public MobileServiceAuthenticationProvider ServiceProvider { get; private set; }

        public async Task<bool> Authenticate(int Provider)
        {
            var success = false;
            var message = string.Empty;

            switch (Provider)
            {
                case 0:
                    {
                        ServiceProvider = MobileServiceAuthenticationProvider.Google;
                        break;
                    }
                case 1:
                    {
                        ServiceProvider = MobileServiceAuthenticationProvider.Twitter;
                        break;
                    }
                case 2:
                    {
                        ServiceProvider = MobileServiceAuthenticationProvider.MicrosoftAccount;
                        break;
                    }
                case 3:
                    {
                        ServiceProvider = MobileServiceAuthenticationProvider.Facebook;
                        break;
                    }

            }

            try
            {
                // Sign in with Facebook login using a server-managed flow.
                if (user == null)
                {
                    user = await client.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController,
                       ServiceProvider);
                    if (user != null)
                    {
                        message = string.Format("You are now signed-in as {0}.", user.UserId);
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Display the success or failure message.
            UIAlertView avAlert = new UIAlertView("Sign-in result", message, null, "OK", null);
            avAlert.Show();

            return success;
        }

    }
}
