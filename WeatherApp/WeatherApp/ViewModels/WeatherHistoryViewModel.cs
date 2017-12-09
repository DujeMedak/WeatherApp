using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class WeatherHistoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private async Task InitializeGetWeatherAsync()
        {
            try
            {
                IsBusy = true; // set the ui property "IsRunning" to true(loading) in Xaml ActivityIndicator Control
                System.Diagnostics.Debug.WriteLine("llllllllllllllllllllllllllllllllllllll" + City + " " + _date);
                WeatherHistoryModel = await _weatherServices.GetCityHistoryWeather(City, "PT", _date);
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

        private HistoryWeatherModel _weatherHistroyModel;  // for xaml binding

        public string Title
        {
            get { return "Weather history"; }
        }

        public HistoryWeatherModel WeatherHistoryModel
        {
            get { return _weatherHistroyModel; }
            set
            {
                _weatherHistroyModel = value;
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

        public String FormattedDate{
            get{ return _date.Day + "." + _date.Month + "." + _date.Year ; }
        }

        private DateTime _date;   // for entry binding and for method parameter value
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                Task.Run(async () => {
                    await InitializeGetWeatherAsync();
                });
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