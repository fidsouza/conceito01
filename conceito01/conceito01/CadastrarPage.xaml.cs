using conceito01.Model;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace conceito01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarPage : ContentPage
    {
        MobileServiceClient Client { get; set; } = null;
        IMobileServiceSyncTable<oficinatable> oficinatables;

        public CadastrarPage()
        {
        
            InitializeComponent();

        }

        async void Button_Clicked(object sender, EventArgs e)
        {




            if (privacidade.IsToggled)
            {

                var selectedValue = ColumnPicker.Items[ColumnPicker.SelectedIndex];

                var oficina = new oficinatable
                {
                    positiona = latitudeentry.Text,
                    positionb = longitudeentry.Text,
                    label = descricaoentry.Text,
                    address = enderecoentry.Text,
                    rating = selectedValue


                };

                await App.Database.SaveItemAsync(oficina);


                List<oficinatable> oficinas = new List<oficinatable>();

                oficinas = await App.Database.GetItemsAsync();
                oficinas.ToArray();

                var s = oficinas.Last();

                var opnion = new Opinion
                {
                       oficinaid = s.id

                };

                await App.Database.SaveItemAsyncOpinion(opnion);

                List<Opinion> feedbacks = new List<Opinion>();

                feedbacks = await App.Database.GetItemsAsyncOpinion();


                await App.Current.MainPage.DisplayAlert("Aviso", "Cadastro Efetuado", "Ok");


                latitudeentry.Text = string.Empty;
                longitudeentry.Text = string.Empty;
                descricaoentry.Text = string.Empty;
                enderecoentry.Text = string.Empty;
               }
            else

            {
                await App.Current.MainPage.DisplayAlert("Aviso", "Voce precisa aceitar os termos de privacidade", "Ok");

            }



        }



    }


}