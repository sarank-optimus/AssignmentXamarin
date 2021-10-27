using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CrudUsingXamarin.ViewModels
{
    public class LoginPage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string userName;
        private string UserName
        {
            get { return userName; }
            set 
            { 
                userName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        private string password;
        private string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public LoginPage()
        {
            userName = "admin";
            password = "password";
        }
        public Command LoginCommand
        {
            get 
            {
                return new Command(Login);
            }
        }
        private void Login()
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                App.Current.MainPage.DisplayAlert("Empty Values", "Please enter UserName and Password", "Ok");
            else
            {
                if(UserName == "admin" && Password == "password")
                {
                    Application.Current.MainPage = new MainPage();
                }
                else 
                {
                    App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Username and Password", "Ok");
                }
            }
        }
    }
}