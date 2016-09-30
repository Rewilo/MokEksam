using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using MokEksam.Common;
using MokEksam.Handler;
using MokEksam.Model;
using MokEksam.Properties;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MokEksam.ViewModel
{
    class EndUserViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _confirmPassword;
        private string _email;
        private CreateEndUserHandler _handler;
        private ICommand _navigateToLoginCommand;
        private ICommand _createUserCommand;
        private ICommand _checkUsernameCommand;
        private Visibility _invalidUsername;
        private bool _createUserIsEnabled;

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

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public Visibility InvalidUsername
        {
            get { return _invalidUsername; }
            set
            {
                _invalidUsername = value;
                OnPropertyChanged();
            }
        }

        public bool CreateUserIsEnabled
        {
            get { return _createUserIsEnabled; }
            set
            {
                _createUserIsEnabled = value;
                OnPropertyChanged();
            }
        }

        public CreateEndUserHandler Handler
        {
            get { return _handler; }
            set { _handler = value; }
        }

        public ICommand CheckUsernameCommand
        {
            get { return _checkUsernameCommand ?? (_checkUsernameCommand = new RelayCommand(CheckUsername)); }
            set { _checkUsernameCommand = value; }
        }

        public ICommand NavigateToLoginCommand
        {
            get { return _navigateToLoginCommand ?? (_navigateToLoginCommand = new RelayCommand(NavigateToLogin)); }
            set { _navigateToLoginCommand = value; }
        }

        public ICommand CreateUserCommand
        {
            get { return _createUserCommand ?? (_createUserCommand = new RelayCommand(CreateUser)); }
            set { _createUserCommand = value; }
        }

        public EndUserViewModel()
        {
            Handler = new CreateEndUserHandler(this);
            CheckUsernameCommand = new RelayCommand(CheckUsername);
            CreateUserCommand = new RelayCommand(CreateUser);
            NavigateToLoginCommand = new RelayCommand(NavigateToLogin);

            InvalidUsername = Visibility.Collapsed;
            CreateUserIsEnabled = false;
        }

        private async void CreateUser()
        {
            EndUserModel newEndUserModel = new EndUserModel(Username, Password, Email);
            EndUser endUserDTO = new EndUser(newEndUserModel.Username, newEndUserModel.Password, newEndUserModel.Email);
            var result = await Handler.AddUser(endUserDTO);
            var displayDialog = new MessageDialog(result.ToString());
            var displayDialogResult = await displayDialog.ShowAsync();
            NavigateToLogin();
        }
        private void CheckUsername()
        {
            if (Handler.CheckUsername(Username))
            {
                InvalidUsername = Visibility.Collapsed;
                CreateUserIsEnabled = true;
            }
            else
            {
                InvalidUsername = Visibility.Visible;
                CreateUserIsEnabled = false;
            }
        }

        private void NavigateToLogin()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(View.Login));
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
