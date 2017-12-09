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
        bool clicked = false;
        DatePicker datePicker;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();

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
            
            if (!clicked)
            {
                datePicker = new DatePicker
                {
                    Format = "D",
                    VerticalOptions = LayoutOptions.CenterAndExpand

                };
                datePicker.MaximumDate = DateTime.Now;

                datePicker.MinimumDate = DateTime.Now.AddMonths(-1);

                sl.Children.Add(datePicker);
                button_show_history.Text = "SHOW";
                clicked = true;

            }
            else {
                WeatherHistoryViewModel whvm = new WeatherHistoryViewModel();
                whvm.City = viewModel.City;
                whvm.Date = datePicker.Date;
                await Navigation.PushAsync(new CityHistoryWeatherView(whvm));
            }

            

        }


    }
}
