using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace APISample
{
    public class QResult
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Desc { get; set; }

        public string Images { get; set; }

    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;

            IDictionary<String, String> d = new Dictionary<String, String>();
            d.Add("Name", button.Content.ToString());


            // IMPORTANT!!!! <Custom API>
            var result = await App.MobileService.InvokeApiAsync<JsonArray>("Check", System.Net.Http.HttpMethod.Post, d);

            var list = JsonConvert.DeserializeObject<List<QResult>>(result.ToString());

            myList.ItemsSource = list;

        }

    }
}
