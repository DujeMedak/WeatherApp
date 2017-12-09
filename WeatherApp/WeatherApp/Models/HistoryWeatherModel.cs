using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class HistoryWeatherModel
    {
        public Location location { get; set; }
        public Forecast forecast { get; set; }
    }

    public class Day
    {
        [JsonProperty("maxtemp_c")]
        public double maxtemp_c { get; set; }
        public double maxtemp_f { get; set; }
        [JsonProperty("mintemp_c")]
        public double mintemp_c { get; set; }
        public double mintemp_f { get; set; }
        [JsonProperty("avgtemp_c")]
        public double avgtemp_c { get; set; }
        public double avgtemp_f { get; set; }
        public double maxwind_mph { get; set; }
        [JsonProperty("maxwind_kph")]
        public double maxwind_kph { get; set; }
        [JsonProperty("totalprecip_mm")]
        public double totalprecip_mm { get; set; }
        public double totalprecip_in { get; set; }
        [JsonProperty("avgvis_km")]
        public double avgvis_km { get; set; }
        public double avgvis_miles { get; set; }
        [JsonProperty("avghumidity")]
        public double avghumidity { get; set; }
        public Condition condition { get; set; }
        [JsonProperty("uv")]
        public double uv { get; set; }
    }

    public class Astro
    {

        [JsonProperty("sunrise")]
        public string sunrise { get; set; }
        [JsonProperty("sunset")]
        public string sunset { get; set; }
        public string moonrise { get; set; }
        public string moonset { get; set; }
    }

    public class Hour
    {
        public int time_epoch { get; set; }

        [JsonProperty("time")]
        public string time { get; set; }
        [JsonProperty("temp_c")]
        public double temp_c { get; set; }
        public double temp_f { get; set; }
        public int is_day { get; set; }
        public Condition condition { get; set; }
        public double wind_mph { get; set; }
        [JsonProperty("wind_kph")]
        public double wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mb { get; set; }
        public double pressure_in { get; set; }
        [JsonProperty("precip_mm")]
        public double precip_mm { get; set; }
        public double precip_in { get; set; }
        [JsonProperty("humidity")]
        public int humidity { get; set; }
        public int cloud { get; set; }
        [JsonProperty("feelslike_c")]
        public double feelslike_c { get; set; }
        public double feelslike_f { get; set; }
        public double windchill_c { get; set; }
        public double windchill_f { get; set; }
        public double heatindex_c { get; set; }
        public double heatindex_f { get; set; }
        public double dewpoint_c { get; set; }
        public double dewpoint_f { get; set; }
        public int will_it_rain { get; set; }
        public string chance_of_rain { get; set; }
        public int will_it_snow { get; set; }
        public string chance_of_snow { get; set; }
        public double vis_km { get; set; }
        public double vis_miles { get; set; }
    }

    public class Forecastday
    {
        public string date { get; set; }
        public int date_epoch { get; set; }
        public Day day { get; set; }
        public Astro astro { get; set; }
        public List<Hour> hour { get; set; }
    }

    public class Forecast
    {
        public List<Forecastday> forecastday { get; set; }
    }
}
