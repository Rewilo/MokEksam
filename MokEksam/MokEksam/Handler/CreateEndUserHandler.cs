using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MokEksam.Common;
using MokEksam.Model;
using MokEksam.ViewModel;

namespace MokEksam.Handler
{
    class CreateEndUserHandler
    {
        public EndUserViewModel EndUser { get; set; }

        public CreateEndUserHandler(EndUserViewModel endUser)
        {
            EndUser = endUser;
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
                         client.GetAsync("Api/EndUser" + username).Result;
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
            catch (Exception e)
            {
                //TODO: Implement an appropiate exceptionhandling code.
                throw new NotImplementedException();
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
                        client.PostAsJsonAsync("api/EndUser", EndUser).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return await result.Content.ReadAsAsync<EndUser>();
                    }
                    throw new UnSuccesfulRequest();
                }
            }
            catch (UnSuccesfulRequest ex)
            {
                //TODO: Implement an appropiate exceptionhandling code.
                throw new NotImplementedException();
            }
        }
    }
}
