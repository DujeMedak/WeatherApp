using System;
using System.Collections.Generic;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class AvailableCitiesPage : ContentPage
    {
        OfferedCitiesViewModel viewModel;

        public AvailableCitiesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new OfferedCitiesViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as SelectableItem<City>;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new WeatherViewModel()));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Items.Count == 0) {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            var choosenCity = (sender as MenuItem).CommandParameter as SelectableItem<City>;
            viewModel.Items.Remove(choosenCity);

        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            viewModel.updateData();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel.saveData();
        }
    }
}
