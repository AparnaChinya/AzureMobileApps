using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Authentication
{
    public partial class myView : ContentPage
    {

        public static string ApplicationURL = @"https://apchin-mobileapp.azurewebsites.net";
        MobileServiceClient client;
        IMobileServiceTable<TableList> myList;

        string serviceProvider = "";

        int Provider;
        public myView()
        {
            InitializeComponent();
        }
        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }
        private async void OnAdd(object sender, EventArgs e)
        {
            var b = sender as Button;
            bool result = false;
            switch(b.Text.ToString())
            {
                case "Google":
                    {
                        Provider = 0;
                        serviceProvider = "Google";
                        result = await Authenticator.Authenticate(Provider);
                        break;
                    }
                case "Twitter":
                    {
                        Provider = 1;
                        serviceProvider = "Twitter";
                        result = await Authenticator.Authenticate(Provider);
                        break;
                    }
                case "Microsoft":
                    {
                        Provider = 2;
                        serviceProvider = "Microsoft";
                        result = await Authenticator.Authenticate(Provider);
                        break;
                    }
                case "Facebook":
                    {
                        Provider = 3;
                        serviceProvider = "Facebook";
                        result = await Authenticator.Authenticate(Provider);
                        break;
                    }
            }

           
            
            if (result)
            {
                this.client = new MobileServiceClient(ApplicationURL);
                this.myList = client.GetTable<TableList>();
                
                DisplayList.ItemsSource = await myList.Where(myList => myList.Name == serviceProvider).ToEnumerableAsync();
            }
                 

        }
    }
}
