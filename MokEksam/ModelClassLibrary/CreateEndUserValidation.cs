using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ModelClassLibrary
{
    public class CreateEndUserValidation
    {
        private readonly EndUser _endUser;

        public CreateEndUserValidation(EndUser endUser)
        {
            _endUser = endUser;
        }
        
        public bool CheckUsername(string username)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.UseDefaultCredentials = true;

                using (HttpClient client = new HttpClient(clientHandler))
                {
                    //client.BaseAddress = new Uri(Config.ConnectionUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicantion/json"));


                    var result =
                         client.GetAsync("Api/USER" + _endUser.Username).Result;
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
    }
}
