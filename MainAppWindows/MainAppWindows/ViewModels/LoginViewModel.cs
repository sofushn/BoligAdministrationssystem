using MainAppWindows.Helpers;
using MainAppWindows.Models;
using MainAppWindows.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MainAppWindows.Services;

namespace MainAppWindows.ViewModels
{
    public class LoginViewModel : Observable
    {
        private LoginHandler handler;

        public LoginViewModel()
        {
            handler = new LoginHandler(this);


            LoginCommand = new RelayCommand(Login);
            SignoutCommand = new RelayCommand(SignOut);
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { Set(ref _username, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { Set(ref _password, value); }
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand SignoutCommand { get; private set; }



        private void Login()
        {
            bool success = handler.GetAccountForLogin();
            if (success == true)
            {
                NavigationService.Navigate<Views.WelcomeLoginPage>();
            }
        }
        private void SignOut()
        {
            bool success = true;
            if (success == true)
            {
                NavigationService.Navigate<Views.LoginPage>();
            }   
        }
    }
}
