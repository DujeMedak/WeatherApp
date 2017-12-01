using System;
using System.Collections.Generic;
using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class NewItemPage : ContentPage
    {
        public OfferedCity OfferedCity { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            OfferedCity = new OfferedCity
            {
                Name = "City",
                District = "City district",
                IsSelected = false,
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", OfferedCity);
            await Navigation.PopToRootAsync();
        }
    }
}
