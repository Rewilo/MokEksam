using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MokEksam.Common;
using MokEksam.Handler;
using MokEksam.Model;
using MokEksam.Properties;

namespace MokEksam.ViewModel
{
    class EndUserViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _email;
        private CreateEndUserHandler _handler;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                Handler.CheckUsername(value);
                OnPropertyChanged(Username);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(Password);
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(Email);
            }
        }

        public EndUser EndUser { get; set; }

        public CreateEndUserHandler Handler
        {
            get { return _handler; }
            set { _handler = value; }
        }

        public ICommand NavigateToLoginCommand { get; set; }
        public ICommand CreateUserCommand { get; set; }
        
        public EndUserViewModel()
        {
            Handler = new CreateEndUserHandler(this);
            CreateUserCommand = new RelayCommand(CreateUser);
            NavigateToLoginCommand = new RelayCommand(NavigateToLogin);
        } 
        private async void CreateUser()
        {
            EndUser = new EndUser(Username, Password, Email);
            await Handler.AddUser(EndUser);
        }

        private void NavigateToLogin()
        {
            //((Frame)Window.Current.Content).Navigate(typeof(View.Login));
        }
        #region OnPropertyChangedSupport
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
