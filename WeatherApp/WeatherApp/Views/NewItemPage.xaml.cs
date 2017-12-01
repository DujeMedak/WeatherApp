using System;
using System.Collections.Generic;
using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class NewItemPage : ContentPage
    {
        public OfferedItem OfferedCity { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            OfferedCity = new OfferedItem
            {
                Text = "City",
                Description = "City district",
                Choosen = false,
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
