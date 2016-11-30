using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Authentication
{
    public class App : Application
    {
       
        public App()
        {
            var mybutton = new Button();
            mybutton.Text = "Facebook Login";
            mybutton.HorizontalOptions = LayoutOptions.Center;
            mybutton.Clicked += Mybutton_Clicked;

            // The root page of your application
            var content = new ContentPage
            {
                Title = "Authentication",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                            },
                        mybutton

                    }
                }
            };


            MainPage = new NavigationPage(content);
        }

       
        private async void Mybutton_Clicked(object sender, EventArgs e)
        {
          await App.Authenticator.Authenticate();


        }
        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }
        public interface IAuthenticate
        {
            Task<bool> Authenticate();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
