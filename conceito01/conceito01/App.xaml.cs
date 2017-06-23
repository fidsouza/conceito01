using conceito01.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace conceito01
{
    public partial class App : Application
    {
        static Data database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new conceito01.LoginPage());
        }

        public static Data Database
        {
            get
            {
                if (database == null)
                {
                    database = new Data(DependencyService.Get<IFileHelper>().GetLocalFilePath("Oficina.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
