using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(WeatherApp.MockDataStore))]
namespace WeatherApp
{
    public class MockDataStore : IDataStore<City>
    {
        List<City> items;

        public MockDataStore()
        {
            items = new List<City>();
        }

        public async Task<bool> AddItemAsync(City item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(City item)
        {
            var _item = items.Where((City arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((City arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<City> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<City>> GetItemsAsync(bool forceRefresh = false)
        {
            if (Application.Current.Properties.ContainsKey("cities"))
            {
                String cities = Application.Current.Properties["cities"] as String;
                // do something with id
                items.Clear();
                System.Diagnostics.Debug.WriteLine("--------------" + cities);
                String[] lines = cities.Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    String[] line = lines[i].Split('#');
                    if (line.Length == 4)
                    {
                        if (line[3].Equals("true"))
                        {
                            items.Add(new City(line[0], line[1], line[2]));
                        }

                    }
                    else
                    {
                        break;
                    }
                }
            }
            else {
                System.Diagnostics.Debug.WriteLine("+++++++++++++++++++++++++++++++");
            }
            return await Task.FromResult(items);
        }

        public async Task<bool> setItems(List<SelectableItem<City>> newItems)
        {
            items.Clear();
            foreach (var item in newItems) {
                items.Add(item.Data);
            }
            return await Task.FromResult(true);
        }
    }
}
