using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    class OfferedCitiesMockDataStore : IDataStore<OfferedItem>
    {
        List<OfferedItem> items;

        public OfferedCitiesMockDataStore()
        {
            items = new List<OfferedItem>();
            var mockItems = new List<OfferedItem>
            {
                new OfferedItem { Id = Guid.NewGuid().ToString(), Text = "City 1", Description="City 1 district", Choosen = false },
                new OfferedItem{ Id = Guid.NewGuid().ToString(), Text = "City 2", Description="City 2 district" , Choosen = true}
               };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(OfferedItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(OfferedItem item)
        {
            var _item = items.Where((OfferedItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((OfferedItem arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<OfferedItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<OfferedItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
