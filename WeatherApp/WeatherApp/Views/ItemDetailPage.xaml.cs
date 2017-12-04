using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class ItemDetailPage : ContentPage
    {
        WeatherViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new City(Guid.NewGuid().ToString(),"Item 1", "This is an item description.");

            //viewModel = new ItemDetailViewModel(item);
            viewModel = new WeatherViewModel();
            BindingContext = viewModel;
        }

        public ItemDetailPage(WeatherViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
