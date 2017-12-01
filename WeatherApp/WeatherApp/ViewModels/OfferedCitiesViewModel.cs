﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using WeatherApp.Models;
using Xamarin.Forms;


namespace WeatherApp.ViewModels
{
    class OfferedCitiesViewModel : BaseViewModel
    {
        public ObservableCollection<OfferedCity> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public OfferedCitiesViewModel()
        {
            Title = "Available cities";
            Items = new ObservableCollection<OfferedCity>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, OfferedCity>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as OfferedCity;
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
    }
}
