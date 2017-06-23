using conceito01.Authentication;
using conceito01.Helpers;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(conceito01.Services.AzureService))]
namespace conceito01.Services
{
   public class AzureService
    {
        static readonly string AppUrl = "https://sociallogin01.azurewebsites.net";

        public MobileServiceClient Client { get; set; } = null;

        public static bool UseAuth { get; set; } = false;






        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);




            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }


        }


        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops..", "Nao conseguimos efetuar seu login", "Ok");
                });

                return false;
            }
            else
            {
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;

            }

            return true;
        }


    }
}
