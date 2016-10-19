using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Xaml.Interactions.Core;

namespace MokEksam.ViewModel
{
    public class LandingPageViewModel
    {
        private string _userName = LogInViewModel.UserNameStatic;

        public string UserName
        {
            get { return _userName; }
            
        }

        public LandingPageViewModel()
        {
           
        }
    }
}