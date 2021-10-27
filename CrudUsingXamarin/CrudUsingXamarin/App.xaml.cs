using CrudUsingXamarin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudUsingXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
            //MainPage = new LoginPage();
            /*if (loginStatus == "isSuccess")
            {*/
            //MainPage = new NavigationPage(new HomePage());
            /*}
            else
            {
                DisplayAlert("Sorry", "Something went wrong.", "Ok");
            }*/

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
