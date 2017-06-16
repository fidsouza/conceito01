using conceito01.Services;
using conceito01.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace conceito01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel ViewModel => BindingContext as LoginViewModel;
        //readonly AzureService azureService = new AzureService();
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new NavigationPage(new DefaultPage());
           // LoginButton.Clicked += async (sender, args) =>
           // {
           //     var user = await azureService.LoginAsync();
           //     await App.Current.MainPage.DisplayAlert("Ok", "Logado","Ok");
           // };

        }
    }
}