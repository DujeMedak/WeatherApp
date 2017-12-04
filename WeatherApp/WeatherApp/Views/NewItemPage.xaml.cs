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

            OfferedCity = new SelectableItem<City>(new City(Guid.NewGuid().ToString(),"City name","City district"),false );


            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", OfferedCity);
            await Navigation.PopToRootAsync();
        }
    }
}
