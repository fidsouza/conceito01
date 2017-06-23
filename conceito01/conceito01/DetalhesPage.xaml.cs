using conceito01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace conceito01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesPage : ContentPage
    {

        public DetalhesPage(string label)
        {
            InitializeComponent();
            
            CarregaList(label);
            

        }

        private async void  CarregaList(string label)
        {
 
          List<oficinatable> s =  await App.Database.GetLabelAsync(label);
          ListOficinas.ItemsSource = s;




        }
    }
}

 
