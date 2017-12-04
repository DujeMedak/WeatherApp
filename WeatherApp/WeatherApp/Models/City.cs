using System;

namespace WeatherApp
{
    public class City
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }

        public City(string id, string name, string district) {
            this.Id = id;
            this.Name = name;
            this.District = district;
        }
    }
}
