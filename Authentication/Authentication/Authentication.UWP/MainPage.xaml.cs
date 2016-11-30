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
            Authentication.App.Init(this);
            LoadApplication(new Authentication.App());
        }


        private MobileServiceUser user;
        MobileServiceClient client = new MobileServiceClient("https://miniHack.azurewebsites.net");
        public async Task<bool> Authenticate()
        {
            string message = string.Empty;
            var success = false;

            try
            {
               // Sign in with Facebook login using a server-managed flow.
                if (user == null)
                {
                    user = await client.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
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
