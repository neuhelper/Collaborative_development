using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void CallWebServiceButton_Clicked(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requestUri: "https://v2.jinrishici.com/token");
            var json = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<JinrishiciToken>(json);
            ResultLabel.Text = token.Data;
        }
    }
    public partial class JinrishiciToken
    {
        public string Status { get; set; }

        public string Data { get; set; }
    }
}
