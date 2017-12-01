using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    class OfferedCitiesMockDataStore : IDataStore<OfferedCity>
    {
        List<OfferedCity> items;

        public OfferedCitiesMockDataStore()
        {
            items = new List<OfferedCity>();
            var mockItems = new List<OfferedCity>
            {
                new OfferedCity { Id = Guid.NewGuid().ToString(), Name = "City 1", District="City 1 district", IsSelected = false },
                new OfferedCity{ Id = Guid.NewGuid().ToString(), Name = "City 2", District="City 2 district" , IsSelected = true}
               };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(OfferedCity item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(OfferedCity item)
        {
            var _item = items.Where((OfferedCity arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((OfferedCity arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<OfferedCity> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<OfferedCity>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
