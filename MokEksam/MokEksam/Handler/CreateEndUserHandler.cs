using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.UI.Popups;
using MokEksam.Common;
using MokEksam.Model;
using MokEksam.Model.DTO;
using MokEksam.ViewModel;

namespace MokEksam.Handler
{
    class CreateEndUserHandler
    {
        private EndUserViewModel EndUserViewModel { get; set; }
        
        public CreateEndUserHandler(EndUserViewModel endUserViewModel)
        {
            EndUserViewModel = endUserViewModel;
        }
        
        public bool CheckUsername(string username)
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
                         client.GetAsync("api/EndUsers/" + username).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return false;
                    }
                    if (result.StatusCode == HttpStatusCode.NotFound)
                    {
                        return true;
                    }
                    throw new ArgumentException("Something went wrong along the way... Try another day");
                }
            }
            catch (Exception ex)
            {
                //TODO: Implement an appropiate exceptionhandling code.
                var displayExceptionMessage = new MessageDialog(ex.Message);
                var displayExceptionMessageResult = displayExceptionMessage.ShowAsync();
                return false;
            }
        }

        public async Task<EndUser> AddUser(EndUser endUser)
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
                var displayExceptionMessageResult = await displayExceptionMessage.ShowAsync();
                return new EndUser("DerSketeEnFejl","abcdef1!", "abc@abc.dk");
            }
        }
    }
}
