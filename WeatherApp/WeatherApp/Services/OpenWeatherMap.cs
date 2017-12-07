﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    class OpenWeatherMap<T>
    {

        private const string OpenWeatherApi = "http://api.openweathermap.org/data/2.5/weather?q=";
        private const string Key = "951238315e6f4d7fb5785a3f4b04059a";
        HttpClient _httpClient = new HttpClient();

        public async Task<T> GetAllWeathers(string city)
        {
            var json = await _httpClient.GetStringAsync(OpenWeatherApi + city + "&APPID=" + Key);
            var getWeatherModels = JsonConvert.DeserializeObject<T>(json);
            return getWeatherModels;
        }

        public async Task<T> GetCityHistoryDetails(string city,string countryCode,string start,string end)
        {
            //string var = "http://history.openweathermap.org/data/2.5/history/city?q={city ID},{country code}&type=hour&start={start}&end={end}";
            var json = await _httpClient.GetStringAsync(OpenWeatherApi + city + "," + countryCode + "&type=hour&start="+start+"&end="+end +"&APPID=" + Key);
            var getWeatherHistoryModels = JsonConvert.DeserializeObject<T>(json);
            return getWeatherHistoryModels;
        }
    }
}
