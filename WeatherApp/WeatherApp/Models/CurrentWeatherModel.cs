using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class CurrentWeatherModel
    {
        public Location location { get; set; }
        public Current current { get; set; }
    }
    public class Location
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("region")]
        public string region { get; set; }
        [JsonProperty("country")]
        public string country { get; set; }
        [JsonProperty("lat")]
        public double lat { get; set; }
        [JsonProperty("lon")]
        public double lon { get; set; }
        [JsonProperty("tz_id")]
        public string tz_id { get; set; }
        [JsonProperty("localtime_epoch")]
        public int localtime_epoch { get; set; }
        [JsonProperty("localtime")]
        public string localtime { get; set; }
    }

    public class Condition
    {
        [JsonProperty("text")]
        public string text { get; set; }
        [JsonProperty("icon")]
        public string icon { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class Current
    {
        public int last_updated_epoch { get; set; }
        public string last_updated { get; set; }
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
        public double precip_mm { get; set; }
        public double precip_in { get; set; }
        [JsonProperty("humidity")]
        public int humidity { get; set; }
        public int cloud { get; set; }
        [JsonProperty("feelslike_c")]
        public double feelslike_c { get; set; }
        public double feelslike_f { get; set; }
        public double vis_km { get; set; }
        public double vis_miles { get; set; }
    }
}
