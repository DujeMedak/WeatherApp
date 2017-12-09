using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    class ApixuWeatherMap<T>
    {
        private const string OpenWeatherApi = "http://api.apixu.com/v1/current.json?key=";

        private const string OpenWeatherHistoryApi = "http://api.apixu.com/v1/history.json?key=";
        private const string Key = "3fa9ae410f6f4d7786c222125170412";
        HttpClient _httpClient = new HttpClient();

        public async Task<T> GetCurrentWeather(string city)
        {
            var json = await _httpClient.GetStringAsync(OpenWeatherApi + Key + "&q=" + city);
            var getWeatherModels = JsonConvert.DeserializeObject<T>(json);
            return getWeatherModels;
        }

        public async Task<T> GetCityHistoryDetails(string city, string countryCode,DateTime date)
        {
            var json = await _httpClient.GetStringAsync(OpenWeatherHistoryApi + Key + "&q=" + city + "&dt=" + date.Year + "-" + date.Month + "-" + date.Day);
            System.Diagnostics.Debug.WriteLine("ddddddddddddddddddddddddddddddddddd" + json);
            var getWeatherHistoryModels = JsonConvert.DeserializeObject<T>(json);
            return getWeatherHistoryModels;
        }

    }
}
