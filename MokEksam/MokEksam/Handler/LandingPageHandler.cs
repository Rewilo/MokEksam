using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MokEksam.ViewModel;

namespace MokEksam.Handler
{
    public class LandingPageHandler
    {
        public LandingPageViewModel LandingPageViewModel { get; set; }
        public LandingPageHandler(LandingPageViewModel landingPage)
        {
            this.LandingPageViewModel = landingPage;
        }

        public void LogOut()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(View.Login));
        }
    }
}