using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MokEksam.EndUserDBService;
using MokEksam.ViewModel;

namespace MokEksam.Handler
{
    /// <summary>
    /// Klassen tilbyder EndUserViewModel metoder til View og håndterer logik.
    /// Klassen eksisterer for at følge gode OO-principper 
    /// </summary>
    class CreateEndUserHandler
    {
        // Deklaring af reference for at få adgang til EndUserViewModels properties.
        private EndUserViewModel EndUserViewModel { get; }
        
        // Deklaring af refernce for at få adgang til WCF-Service
        private EndUserDatabaseServiceClient ClientDbService { get; }
        
        // Jeg panikkede og tænkte med det samme alt måtte være statisk. Kan I komme på en bedre løsning?
        // It ain't pretty but it works fine ...
        public static string PasswordToConfirm = string.Empty;

        /// <summary>
        /// Opretter objekter til klassens referencer.
        /// </summary>
        /// <param name="endUserViewModel"></param>
        public CreateEndUserHandler(EndUserViewModel endUserViewModel)
        {
            EndUserViewModel = endUserViewModel;
            ClientDbService = new EndUserDatabaseServiceClient();
        }

        // Samme fremgangsmåde som AddUser() men bruger istedet for WCF-Service.
        /// <summary>
        /// Metoden opretter en række i tabellen EndUser, hvis inputtet fra EndUserViewModel er valideret korrekt.
        /// Hvis det lykkedes at oprette en ny bruger, så navigeres bruger hen til LoginView.
        /// </summary>
        public async void CreateUser()
        {
            try
            {
                if (EndUserViewModel.ValidateProperties())
                {
                    EndUser newEndUser = new EndUser()
                    {
                        user_name = EndUserViewModel.Username,
                        user_password = EndUserViewModel.Password,
                        user_email = EndUserViewModel.Email
                    };
                    await ClientDbService.InsertEndUserAsync(newEndUser);

                    
                    var ms = new MessageDialog("You have create a new User for BirdmonGo\n" +
                                               $"Username:   {EndUserViewModel.Username}\n" +
                                               $"Password:   {EndUserViewModel.Password[0]}***{EndUserViewModel.Password[EndUserViewModel.Password.Length - 1]}\n" +
                                               $"Email:      {EndUserViewModel.Email}");
                    await ms.ShowAsync();
                    NavigateToLogin();
                }
                else
                {
                    throw new ArgumentException("User input is not validated");
                }
            }
            catch (ArgumentException argException)
            {
                var ms = new MessageDialog(argException.Message);
                await ms.ShowAsync();
            }
            catch (Exception exception)
            {
                var ms = new MessageDialog(exception.Message);
                await ms.ShowAsync();
            }
        }

/*
        private async Task<EndUser> AddUser(EndUser endUser)
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
                        client.PostAsJsonAsync("api/EndUsers", endUser).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return await result.Content.ReadAsAsync<EndUser>();
                    }
                    throw new UnSuccesfulRequest("Ran into a problem ...");
                }
            }
            catch (UnSuccesfulRequest ex)
            {
                var displayExceptionMessage = new MessageDialog(ex.Message);
                await displayExceptionMessage.ShowAsync();
                return new EndUser("DerSketeEnFejl", "abcdef1!", "abc@abc.dk");
            }
        }
*/
        /// <summary>
        /// Metoden navigerer til en anden page.xaml kaldet Login.xaml
        /// </summary>
        public void NavigateToLogin()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(View.Login));
        }
    }
}
