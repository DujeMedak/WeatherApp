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
        private const string Key = "3fa9ae410f6f4d7786c222125170412";
        HttpClient _httpClient = new HttpClient();

        public async Task<T> GetCurrentWeather(string city)
        {
            var json = await _httpClient.GetStringAsync(OpenWeatherApi + Key + "&q=" + city);
            var getWeatherModels = JsonConvert.DeserializeObject<T>(json);
            return getWeatherModels;
        }

        public async Task<T> GetCityHistoryDetails(string city, string countryCode, string start, string end)
        {
            //string var = "http://history.openweathermap.org/data/2.5/history/city?q={city ID},{country code}&type=hour&start={start}&end={end}";
            var json = await _httpClient.GetStringAsync(OpenWeatherApi + city + "," + countryCode + "&type=hour&start=" + start + "&end=" + end + "&APPID=" + Key);
            var getWeatherHistoryModels = JsonConvert.DeserializeObject<T>(json);
            return getWeatherHistoryModels;
        }

    }
}
