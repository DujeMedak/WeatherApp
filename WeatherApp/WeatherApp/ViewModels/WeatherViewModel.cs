using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using WeatherApp.Services;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private async Task InitializeGetWeatherAsync()
        {
            try
            {
                IsBusy = true; // set the ui property "IsRunning" to true(loading) in Xaml ActivityIndicator Control
                WeatherMainModel = await _weatherServices.GetWeatherDetails(_city);
            }
            finally
            {
                IsBusy = false;
            }
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        WeatherServices _weatherServices = new WeatherServices();

        private WeatherMainModel _weatherMainModel;  // for xaml binding

        public WeatherMainModel WeatherMainModel
        {
            get { return _weatherMainModel; }
            set
            {
                _weatherMainModel = value;
                IconImageString = "http://openweathermap.org/img/w/" + _weatherMainModel.weather[0].icon + ".png"; // fetch weather icon image
                OnPropertyChanged();
            }
        }

        private string _city;   // for entry binding and for method parameter value
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                Task.Run(async () => {
                    await InitializeGetWeatherAsync();
                });
                OnPropertyChanged();
            }
        }

        private string _iconImageString; // for weather icon image string binding
        public string IconImageString
        {
            get { return _iconImageString; }
            set
            {
                _iconImageString = value;
                OnPropertyChanged();
            }
        }

        private bool _isBusy;
        // for showing loader when the task is initializing
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

    }


}

