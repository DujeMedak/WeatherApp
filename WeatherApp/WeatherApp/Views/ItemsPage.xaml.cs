using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            Int32 unixTimestamp2 = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 2))).TotalSeconds;

            System.Diagnostics.Debug.WriteLine("##############"+unixTimestamp.ToString() +"\n"+ unixTimestamp2.ToString());

        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as City;
            if (item == null)
                return;

            // Manually deselect item
            ItemsListView.SelectedItem = null;
            var wvm = new CurrentWeatherViewModel();
            wvm.City = item.Name;

            await Navigation.PushAsync(new ItemDetailPage(wvm));

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            var choosenCity = (sender as MenuItem).CommandParameter as City;
            viewModel.Items.Remove(choosenCity);
            
        }
    }
}