using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    class OfferedCitiesMockDataStore : IDataStore<SelectableItem<City>>
    {
        List<SelectableItem<City>> items;

        public OfferedCitiesMockDataStore()
        {
            items = new List<SelectableItem<City>>();
            
            var mockItems = new List<SelectableItem<City>>
            {
                new SelectableItem<City> {Data =  new City { Id = Guid.NewGuid().ToString(), Name = "City 1", District = "This is an item description." },Selected = false  },
                new SelectableItem<City> {Data =  new City { Id = Guid.NewGuid().ToString(), Name = "City 2", District = "This 2 is an item description." },Selected = false  },
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
            return await Task.FromResult(items);
        }

        public Task<bool> setItems(List<SelectableItem<SelectableItem<City>>> items)
        {
            throw new NotImplementedException();
        }
    }
}
