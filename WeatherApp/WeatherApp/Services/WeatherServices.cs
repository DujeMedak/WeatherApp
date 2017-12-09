using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Services
{
    class WeatherServices
    {
        ApixuWeatherMap<CurrentWeatherModel> _openWeatherRest = new ApixuWeatherMap<CurrentWeatherModel>();
        ApixuWeatherMap<HistoryWeatherModel> _openWeatherRest2 = new ApixuWeatherMap<HistoryWeatherModel>();


        public async Task<CurrentWeatherModel> GetCurrentWeather(string city)
        {
            var getWeatherDetails = await _openWeatherRest.GetCurrentWeather(city);
            return getWeatherDetails;
        }
        
        public async Task<HistoryWeatherModel> GetCityHistoryWeather(string city,string countryCode,DateTime date)
        {
            var getWeatherDetails = await _openWeatherRest2.GetCityHistoryDetails(city,countryCode,date);
            return getWeatherDetails;
        }
    }
}
