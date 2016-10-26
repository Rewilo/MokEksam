using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MokEksam.Annotations;
using MokEksam.Common;
using MokEksam.Handler;
using MokEksam.Model.DTO;

namespace MokEksam.ViewModel
{
    class ForgotPasswordViewModel : INotifyPropertyChanged
    {
        private ICommand _navigateToLogInCommand;
        private ICommand _changePasswordCommand;
        // TODO: Remember to bind properties to elements of ForgotPassword.xaml
        public string Email { get; set; }
        public string Username { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        private ForgotPasswordHandler _handler { get; set; }

        public ICommand NavigateToLogInCommand
        {
            get { return _navigateToLogInCommand ?? (_navigateToLogInCommand = new RelayCommand(NavigateToLogIn)); }
            set { _navigateToLogInCommand = value; }
        }

        public ICommand ChangePasswordCommand
        {
            get { return _changePasswordCommand ?? (_changePasswordCommand = new RelayCommand(ChangePassword)); }
            set { _changePasswordCommand = value; }
        }

        public ForgotPasswordViewModel()
        {
            _handler = new ForgotPasswordHandler(this);
        }

        private void ChangePassword()
        {
            try
            {
                // TODO: Implement the calling of _handler's methods
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void NavigateToLogIn()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(View.Login));
        }
        
        #region PropertyChangedSupport
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
