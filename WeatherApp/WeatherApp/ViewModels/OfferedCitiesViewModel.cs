using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using WeatherApp.Models;
using Xamarin.Forms;


namespace WeatherApp.ViewModels
{
    class OfferedCitiesViewModel : BaseViewModel
    {
        public ObservableCollection<OfferedItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public OfferedCitiesViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<OfferedItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as OfferedItem;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore2.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
