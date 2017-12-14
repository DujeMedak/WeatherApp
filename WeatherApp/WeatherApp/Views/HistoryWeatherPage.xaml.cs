using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryWeatherPage : ContentPage
    {
        WeatherServices ws;
        WeatherHistoryViewModel viewModel;

        public HistoryWeatherPage()
        {
            InitializeComponent();
            ws = new WeatherServices();

            viewModel = new WeatherHistoryViewModel();

            BindingContext = viewModel;
        }

        public HistoryWeatherPage(WeatherHistoryViewModel vm)
        {
            InitializeComponent();
            ws = new WeatherServices();

            BindingContext = this.viewModel = vm;
        }

    }
}