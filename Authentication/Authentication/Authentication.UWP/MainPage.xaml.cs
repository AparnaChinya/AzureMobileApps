using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Authentication;
using static Authentication.App;

namespace Authentication.UWP
{
    public sealed partial class MainPage:IAuthenticate
    {
        public MainPage()
        {
            InitializeComponent();
            Authentication.myView.Init(this);
            LoadApplication(new Authentication.App());
        }


        private MobileServiceUser user;
        MobileServiceClient client = new MobileServiceClient("https://miniHack.azurewebsites.net");

        public MobileServiceAuthenticationProvider ServiceProvider { get; private set; }

        public async Task<bool> Authenticate(int Provider)
        {
            string message = string.Empty;
            var success = false;

            switch(Provider)
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
               // Sign in with the respective Service Provider login using a server-managed flow.
                if (user == null)
                {
                    user = await client.LoginAsync(ServiceProvider);
                    if (user != null)
                    {
                        success = true;
                        message = string.Format("You are now signed-in as {0}.", user.UserId);
                    }
                }

            }
            catch (Exception ex)
            {
                message = string.Format("Authentication Failed: {0}", ex.Message);
            }

          //  Display the success or failure message.
            await new MessageDialog(message, "Sign-in result").ShowAsync();

            return success;
        }
    }
}
