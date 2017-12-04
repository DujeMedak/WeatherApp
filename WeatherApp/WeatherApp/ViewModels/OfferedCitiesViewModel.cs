using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Models;
using Xamarin.Forms;


namespace WeatherApp.ViewModels
{
    class OfferedCitiesViewModel : BaseViewModel
    {
        public ObservableCollection<SelectableItem<City>> Items { get; set; }
        public List<SelectableItem<City>> selectedCities { get; }
        public Command LoadItemsCommand { get; set; }

        public OfferedCitiesViewModel()
        {
            Title = "Available cities";
            selectedCities = new List<SelectableItem<City>>();
            Items = new ObservableCollection<SelectableItem<City>>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, SelectableItem<City>>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as SelectableItem<City>;
                Items.Add(_item);
                await DataStore2.AddItemAsync(_item);
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

        public void updateData()
        {
            selectedCities.Clear();
                foreach (SelectableItem<City> data in Items)
                {
                    if (data.Selected)
                    {

                        selectedCities.Add(new SelectableItem<City>() { Data = data.Data, Selected = data.Selected });
                    }
                }
                DataStore.setItems(selectedCities);
        }
    }
}
