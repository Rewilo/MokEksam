using System;
using System.Windows.Input;
using MokEksam.Common;
using MokEksam.Handler;

namespace MokEksam.ViewModel
{
    public class LogInViewModel
    {
        private ICommand _logInCommand;

        public string Username { get; set; }
        public string Password { get; set; }
        public CheckPasswordHandler Handler { get; set; }

        public ICommand LogInCommand
        {
            get { return _logInCommand ?? (_logInCommand = new RelayCommand(LogIn)); }
            set { _logInCommand = value; }
        }

        public async void LogIn()
        {
            

            try
            {
                Handler.CheckPassword(Username, Password);


                // login success
            }
            catch (Exception)
            {
                // login fail


            }
        }

        public LogInViewModel()
        {
            LogInCommand = new RelayCommand(LogIn);
            Handler = new CheckPasswordHandler();
        }
    }
}