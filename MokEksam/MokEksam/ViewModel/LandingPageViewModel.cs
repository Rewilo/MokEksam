using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Xaml.Interactions.Core;
using MokEksam.Common;
using MokEksam.Handler;

namespace MokEksam.ViewModel
{
    public class LandingPageViewModel
    {
        private string _userName = LogInViewModel.UserNameStatic;
        private ICommand _logOutCommand;
        public LandingPageHandler Handler { get; set; }

        public ICommand LogOutCommand
        {
            get { return _logOutCommand ?? (_logOutCommand = new RelayCommand(Handler.LogOut)); }
            set { _logOutCommand = value; }
        }

        public string UserName
        {
            get { return _userName; }
            
        }

        public LandingPageViewModel()
        {
           Handler = new LandingPageHandler(this);
        }
    }
}