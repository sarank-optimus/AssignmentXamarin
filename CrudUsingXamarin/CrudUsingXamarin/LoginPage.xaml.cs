using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudUsingXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginPage loginVM;
        public LoginPage()
        { 
            InitializeComponent();
            loginVM = new LoginPage();
            BindingContext = loginVM;
            //image.Source = ImageSource.FromResource("CrudUsingXamarin.Images.login.png");
        }
    }
}