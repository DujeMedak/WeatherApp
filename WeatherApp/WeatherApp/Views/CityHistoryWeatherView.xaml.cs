using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CityHistoryWeatherView : ContentPage
    {
        WeatherServices ws;
        WeatherHistoryViewModel viewModel;

        public CityHistoryWeatherView()
        {
            InitializeComponent();
            ws = new WeatherServices();
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            Int32 unixTimestamp2 = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 2))).TotalSeconds;

            //var s = ws.GetCityHistoryWeather("Porto","PT", unixTimestamp.ToString(), unixTimestamp.ToString());
            //System.Diagnostics.Debug.WriteLine("???????????????"+s);
        }

        public CityHistoryWeatherView(WeatherHistoryViewModel vm)
        {
            InitializeComponent();
            ws = new WeatherServices();

            BindingContext = this.viewModel = vm;
        }

    }
}