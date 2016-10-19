using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MokEksam.Common;
using MokEksam.ViewModel;

namespace MokEksam.Handler
{
    public class CheckPasswordHandler
    {
        /// <summary>
        /// Operetter en LogInViewModel
        /// Så har vi adgang til properties på runtime
        /// </summary>
        public LogInViewModel LogInViewModel { get; set; }

        /// <summary>
        /// Konstruktør der tager imod et LogInViewModel object
        /// </summary>
        /// <param name="logInViewModel">En loginviewmodel som vi tager this af i view model</param>
        public CheckPasswordHandler(LogInViewModel logInViewModel)
        {
            LogInViewModel = logInViewModel;
        }
        /// <summary>
        /// Vores check password der retunere en bool værdig alt efter om checker er sucessfuldt eller ej
        /// Vi opretter en HttpClientHandler som vi bruger til at gette 
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        private bool CheckPassword(string username, string password)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.UseDefaultCredentials = true;

                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri(Config.ConnectionUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicantion/json"));


                    var result =
                        client.GetAsync("api/Password?endUserName=" + username + "&password=" + password).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    if (result.StatusCode == HttpStatusCode.NotFound)
                    {
                        return false;
                    }
                    throw new ArgumentException("Something went wrong along the way... Try another day");
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Metode der gør brug af handlers checkpassword metode der tager imod 2 strings.
        /// Når dette er gjort gør vi brug af API klassen til at checke om password og username matcher (case sensetive password)
        /// Hvis de matcher opretter vi et static username (TODO: Find en bedre løsning)
        /// Static username bruger vi til at vise hvem der er logget ind i vores LandingPageView
        /// Hvis password ikke matcher viser vi en dialog box med valgmuligheder for at gå til create user eller ignorer
        /// Vi håndtere exception i tilfælde af de bliver smidt og viser fejlen i en dialog box
        /// </summary>

        public async void LogIn()
        {
            
            try
            {
                if (CheckPassword(LogInViewModel.Username, LogInViewModel.Password))
                {
                    var message = new MessageDialog("Log in sucess");
                    await message.ShowAsync();
                    LogInViewModel.UserNameStatic = LogInViewModel.Username;
                    NavigateToLandingPage();
                }
                else
                {
                    var message = new MessageDialog("Username & Password does not match");
                    message.Commands.Add(new UICommand() { Label = "Gå til login", Id = 0 });
                    message.Commands.Add(new UICommand() { Label = "Prøv igen", Id = 1 });
                    var choice = await message.ShowAsync();
                    if ((int)choice.Id == 0)
                    {
                        NavigateToCreateUser();
                    }

                }

                // login success
            }
            catch (Exception e)
            {
                // login fail
                var message = new MessageDialog("An error happend: " + e.Message);
                await message.ShowAsync();

            }
        }
        public void NavigateToCreateUser()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(View.CreateUser));
        }

        public void NavigateToLandingPage()
        {
            ((Frame) Window.Current.Content).Navigate(typeof(View.LandingPage));
        }
    }
}