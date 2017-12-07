using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.ViewModels;
using WeatherApp.Views;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class ItemDetailPage : ContentPage
    {
        CurrentWeatherViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();

            //var item = new City(Guid.NewGuid().ToString(),"Item 1", "This is an item description.");

            //viewModel = new ItemDetailViewModel(item);
            viewModel = new CurrentWeatherViewModel();
            BindingContext = viewModel;
        }

        public ItemDetailPage(CurrentWeatherViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void History_Button_Clicked(object sender, EventArgs e)
        {

           // await Navigation.PushAsync(new CityHistoryWeatherView(new WeatherHistoryViewModel()));
        }


    }
}
