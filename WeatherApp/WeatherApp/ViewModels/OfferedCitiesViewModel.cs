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

            MessagingCenter.Subscribe<AddNewCityPage, SelectableItem<City>>(this, "AddItem", async (obj, item) =>
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
                        selectedCities.Add(new SelectableItem<City>(data.Data,data.Selected));
                    }
                }
                DataStore.setItems(selectedCities);
        }

        public void saveData()
        {
            updateData();

            String txtData = "";
            foreach (SelectableItem<City> data in Items)
            {
                String txtSelected = "false";
                if (data.Selected)
                {
                    txtSelected = "true";
                }
                
                txtData += (data.Data.Id + '#' + data.Data.Name + '#' + data.Data.District + '#' + txtSelected + '\n');
                System.Diagnostics.Debug.WriteLine(txtData);
            }
            Application.Current.Properties["cities"] = txtData;
        }
    }
}
