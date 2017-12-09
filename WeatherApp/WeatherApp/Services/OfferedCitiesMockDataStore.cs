using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp.Services
{
    class OfferedCitiesMockDataStore : IDataStore<SelectableItem<City>>
    {
        List<SelectableItem<City>> items;
        List<SelectableItem<City>> mockItems;

        public OfferedCitiesMockDataStore()
        {
            items = new List<SelectableItem<City>>();
            
            mockItems = new List<SelectableItem<City>>
            {
                new SelectableItem<City>(new City(Guid.NewGuid().ToString(),"Porto","Porto"),false),
                 new SelectableItem<City>(new City(Guid.NewGuid().ToString(),"Aveiro","Aveiro"),false),

            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(SelectableItem<City> item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(SelectableItem<City> item)
        {
            var _item = items.Where((SelectableItem<City> arg) => arg.Data.Id == item.Data.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((SelectableItem<City> arg) => arg.Data.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<SelectableItem<City>> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Data.Id == id));
        }

        public async Task<IEnumerable<SelectableItem<City>>> GetItemsAsync(bool forceRefresh = false)
        {
            if (Application.Current.Properties.ContainsKey("cities"))
            {
                String cities = Application.Current.Properties["cities"] as String;
                // do something with id
                items.Clear();
                String[] lines = cities.Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    String[] line = lines[i].Split('#');
                    bool sel = false;
                    if (line.Length == 4)
                    {
                        if (line[3].Equals("true"))
                        {
                            sel = true;
                        }
                        items.Add(new SelectableItem<City>(new City(line[0], line[1], line[2]), sel));

                    }
                    else
                    {
                        break;
                    }
                }
            }

            return await Task.FromResult(items);
        }

        public Task<bool> setItems(List<SelectableItem<SelectableItem<City>>> items)
        {
            throw new NotImplementedException();
        }
    }
}
