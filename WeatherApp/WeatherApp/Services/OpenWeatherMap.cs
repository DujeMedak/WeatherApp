using Newtonsoft.Json;
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
    }
}
