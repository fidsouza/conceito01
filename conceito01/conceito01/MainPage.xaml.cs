using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace conceito01
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            App.Current.MainPage.DisplayAlert("Mensagem", "Clique sobre as localizações para ver os comentários", "Ok");
        }
    }
}