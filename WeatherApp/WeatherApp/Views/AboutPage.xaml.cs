using System;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class AboutPage : ContentPage
    {
        OfferedCitiesViewModel viewModel;

        public AboutPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new OfferedCitiesViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

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

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            var choosenCity = (sender as MenuItem).CommandParameter as OfferedItem;
            viewModel.Items.Remove(choosenCity);

        }
    }
}
