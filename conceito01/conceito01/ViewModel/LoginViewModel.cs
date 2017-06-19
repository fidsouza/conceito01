using conceito01.Helpers;
using conceito01.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace conceito01.ViewModel
{
   public class LoginViewModel:BaseViewModel
    {
        AzureService azureService;

        public Command LoginCommand { get; }



        private bool _isBusy;

        public LoginViewModel()
        {
            Settings.AuthToken = string.Empty;
            Settings.UserId = string.Empty;
            azureService = DependencyService.Get<AzureService>();
            LoginCommand = new Command( async () => await ExecuteLoginCommand());
            Title = "Encontre sua Oficina";
        }

        private async Task ExecuteLoginCommand()
        {
            if (_isBusy || !(await LoginAsync()))
                return;
            else
            {
                await App.Current.MainPage.Navigation.PushAsync(new MainPage());

            }

            _isBusy = false;
        }


        public async Task<bool> LoginAsync()
        {
            _isBusy = true;
            if (Settings.IsLoggedIn)
                return await Task.FromResult(true);

            return await azureService.LoginAsync();
        }

    }
}
