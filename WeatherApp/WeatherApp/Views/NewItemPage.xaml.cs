using System;
using System.Collections.Generic;
using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class NewItemPage : ContentPage
    {
        public SelectableItem<City> OfferedCity { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            OfferedCity = new SelectableItem<City> { Data = new City { Id = Guid.NewGuid().ToString(), Name = "City name", District = "City district" }, Selected = false };


            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", OfferedCity);
            await Navigation.PopToRootAsync();
        }
    }
}
