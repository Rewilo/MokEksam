using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Xaml.Interactions.Core;
using MokEksam.Annotations;
using MokEksam.Common;
using MokEksam.Handler;

namespace MokEksam.ViewModel
{
    public class LogInViewModel : INotifyPropertyChanged
    {
        private ICommand _logInCommand;
        private string _password;
        private string _username;
        private ICommand _navigateToCreateUserCommand;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private CheckPasswordHandler Handler { get; set; }

        public static string UserNameStatic { get; set; }

        /// <summary>
        /// Navigate til andet view via Handler classen som kalder på navigatetocreateuser
        /// </summary>
        public ICommand NavigateToCreateUserCommand
        {
            get
            {
                return _navigateToCreateUserCommand ??
                       (_navigateToCreateUserCommand = new RelayCommand(Handler.NavigateToCreateUser));
            }
            set { _navigateToCreateUserCommand = value; }
        }
        /// <summary>
        /// Sætter Handler login command
        /// </summary>
        public ICommand LogInCommand
        {
            get { return _logInCommand ?? (_logInCommand = new RelayCommand(Handler.LogIn)); }
            set { _logInCommand = value; }
        }


        /// <summary>
        /// Constructor hvor vi sætter en reference til handler's konstruktør som tager imod en LogInViewModel
        /// Efter sætter vi vores Relay Commands
        /// </summary>
        public LogInViewModel()
        {
            Handler = new CheckPasswordHandler(this);
            LogInCommand = new RelayCommand(Handler.LogIn);
            NavigateToCreateUserCommand = new RelayCommand(Handler.NavigateToCreateUser);
        }




        #region OnPropertyChangedHelp
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}