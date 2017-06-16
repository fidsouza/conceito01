using conceito01.UWP.Authentication;
using conceito01.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conceito01.Authentication;
using Microsoft.WindowsAzure.MobileServices;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace conceito01.UWP.Authentication
{
    class SocialAuthentication : IAuthentication

    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(provider);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;
                return user;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
