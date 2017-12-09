using System;
using System.Collections.Generic;
using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page itemsPage, aboutPage = null;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    itemsPage = new NavigationPage(new ChoosenCitiesPage())
                    {
                        Title = "Choosen cities"
                    };

                    aboutPage = new NavigationPage(new AvailableCitiesPage())
                    {
                        Title = "Available cities"
                    };
                    itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;
                default:
                    itemsPage = new ChoosenCitiesPage()
                    {
                        Title = "Choosen cities"
                    };

                    aboutPage = new AvailableCitiesPage()
                    {
                        Title = "Available cities"
                    };
                    break;
            }
            
            List<SelectableItem<City>> Items = new List<SelectableItem<City>>();

            if (!Application.Current.Properties.ContainsKey("cities")) {

                generateCities();
            }


            Children.Add(itemsPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }

        private void generateCities() {
            String txtData = "";

            List<SelectableItem<City>> Items = new List<SelectableItem<City>>();
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Aveiro", "Norte, Centro"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Beja", "Alentejo"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Braga", "Norte"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Bragança", "Norte"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Castelo Branco", "Centro"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Coimbra", "Centro"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Évora", "Alentejo"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Faro", "Algarve"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Guarda", "Centro"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Leiria", "Centro"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Lisbon", "Lisbon"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Portalegre", "Alentejo"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Porto", "Norte"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Santarém", "Centro"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Setúbal", "Lisbon"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Viana do Castelo", "Norte"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Vila Real", "Norte"), false));
            Items.Add(new SelectableItem<City>(new City(Guid.NewGuid().ToString(), "Viseu", "Centro,Norte"), false));
            foreach (SelectableItem<City> data in Items)
            {
                txtData += (data.Data.Id + '#' + data.Data.Name + '#' + data.Data.District + '#' + "false" + '\n');
                System.Diagnostics.Debug.WriteLine(txtData);
            }
            Application.Current.Properties["cities"] = txtData;
        }

    }
}
