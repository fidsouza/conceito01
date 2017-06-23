using conceito01.Model;
using conceito01.Services;
using Plugin.ExternalMaps;
using Plugin.ExternalMaps.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace conceito01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private Pin selectedPin ;
        

        public MapPage()
        {
            InitializeComponent();
           
        }

        protected async override void OnAppearing()
        {




            base.OnAppearing();


            List<oficinatable> oficinas = new List<oficinatable>();

            oficinas = await App.Database.GetItemsAsync();


            for (int i = 0; i < oficinas.Count; i++)
            {
                var pin = new Pin
                {

                    Position = new Position(Double.Parse(oficinas[i].positiona), Double.Parse(oficinas[i].positionb)),
                    Label = oficinas[i].label,
                    Address = oficinas[i].address,



                };

                   

                pin.Clicked += Pin_Clicked;

                MapOficine.Pins.Add(pin);
            }



        }

        private async void Pin_Clicked(object sender, EventArgs e)
        {

            
            selectedPin = sender as Pin;
            lblLabel.Text = selectedPin.Label;
            lblEndereco.Text = selectedPin.Address;

            await Navigation.PushAsync(new DetalhesPage(selectedPin.Label));

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
            CrossExternalMaps.Current.NavigateTo(selectedPin.Label,
                                                 selectedPin.Position.Latitude,
                                                 selectedPin.Position.Longitude,
                                                 NavigationType.Driving);
        }

  
    }

  
}