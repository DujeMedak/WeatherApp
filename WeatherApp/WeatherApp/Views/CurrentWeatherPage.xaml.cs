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
    public partial class CurrentWeatherPage : ContentPage
    {
        CurrentWeatherViewModel viewModel;
        bool clicked = false;
        DatePicker datePicker;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public CurrentWeatherPage()
        {
            InitializeComponent();

            viewModel = new CurrentWeatherViewModel();
            BindingContext = viewModel;
        }

        public CurrentWeatherPage(CurrentWeatherViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        private async void History_Button_Clicked(object sender, EventArgs e)
        {
            
            if (!clicked && !IsBusy)
            {
                datePicker = new DatePicker
                {
                    Format = "D",
                    VerticalOptions = LayoutOptions.CenterAndExpand

                };
                datePicker.MaximumDate = DateTime.Now;
                datePicker.MinimumDate = DateTime.Now.AddMonths(-1);

                //datePicker.Format = "dd.MM.yyyy";

                sl.Children.Add(datePicker);
                button_show_history.Text = "SHOW";
                clicked = true;

            }
            else {
                WeatherHistoryViewModel whvm = new WeatherHistoryViewModel();
                whvm.City = viewModel.City;

                whvm.Date = new DateTime(datePicker.Date.Year,datePicker.Date.Month,datePicker.Date.Day);
                System.Diagnostics.Debug.WriteLine(".................." + viewModel.City +" " + whvm.Date);
                await Navigation.PushAsync(new HistoryWeatherPage(whvm));
            }

            

        }


    }
}
