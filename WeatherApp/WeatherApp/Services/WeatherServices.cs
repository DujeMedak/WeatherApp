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
        //OpenWeatherMap<WeatherMainModel> _openWeatherRest = new OpenWeatherMap<WeatherMainModel>();
        ApixuWeatherMap<CurrentWeatherModel> _openWeatherRest = new ApixuWeatherMap<CurrentWeatherModel>();
        //OpenWeatherMap<WeatherHistoryModel> _openWeatherRest2 = new OpenWeatherMap<WeatherHistoryModel>();

        public async Task<CurrentWeatherModel> GetCurrentWeather(string city)
        {
            var getWeatherDetails = await _openWeatherRest.GetCurrentWeather(city);
            return getWeatherDetails;
        }
        
        /*public async Task<WeatherHistoryModel> GetCityHistoryWeather(string city,string countryCode,string start,string end)
        {
            var getWeatherDetails = await _openWeatherRest2.GetCityHistoryDetails(city,countryCode,start,end);
            return getWeatherDetails;
        }*/
    }
}
