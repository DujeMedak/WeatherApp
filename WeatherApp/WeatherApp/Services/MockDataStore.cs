using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

[assembly: Xamarin.Forms.Dependency(typeof(WeatherApp.MockDataStore))]
namespace WeatherApp
{
    public class MockDataStore : IDataStore<City>
    {
        List<City> items;

        public MockDataStore()
        {
            items = new List<City>();
            var mockItems = new List<City>
            {
                new City { Id = Guid.NewGuid().ToString(), Name = "First item", District="This is an item description." },
                new City { Id = Guid.NewGuid().ToString(), Name = "Second item", District="This is an item description." },
                new City { Id = Guid.NewGuid().ToString(), Name = "Third item", District="This is an item description." },
                new City { Id = Guid.NewGuid().ToString(), Name = "Fourth item", District="This is an item description." },
                new City { Id = Guid.NewGuid().ToString(), Name = "Fifth item", District="This is an item description." },
                new City { Id = Guid.NewGuid().ToString(), Name = "Sixth item", District="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
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
